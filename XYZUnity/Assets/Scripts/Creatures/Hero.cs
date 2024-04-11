using Scripts.Components;
using Scripts.Model;
using Scripts.Utils;
using UnityEditor.Animations;
using UnityEngine;

namespace Scripts
{
    public class Hero : Creature
    {
        [SerializeField] private LayerMask _interActionLayer;
        [SerializeField] private LayerCheck _wallCheck;

        [SerializeField] private float _fallVelocity;
        [SerializeField] private float _interActionRadius;

        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;

        [Space]
        [Header("Particles")]
        [SerializeField] private ParticleSystem _hitParticles;


        private bool _allowDoubleJump;
        private Collider2D[] _interActionResult = new Collider2D[1];
        private bool _isOnWall;

        private GameSession _session;
        private float _defaultGravityScale;

        protected override void Awake()
        {
            base.Awake();

            _defaultGravityScale = _rigidbody.gravityScale;
        }

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            var health = GetComponent<HealthComponent>();

            health.SetHealth(_session.Data.HP);
            UpdateHeroWeapon();
        }

        public void OnHealthChanged(int currentHealth)
        {
            _session.Data.HP = currentHealth;
        }

        protected override void Update()
        {
            base.Update();

            if (_wallCheck.IsTouchingLayer && _direction.x == transform.localScale.x)
            {
                _isOnWall = true;
                _rigidbody.gravityScale = 0;
            }
            else
            {
                _isOnWall = false;
                _rigidbody.gravityScale = _defaultGravityScale;
            }
        }

        protected override float CalculateYVelocity()
        {

            var yVelocity = _rigidbody.velocity.y;
            bool isJumpPressing = _direction.y > 0;


            if (_isGrounded || _isOnWall)
            {
                _allowDoubleJump = true;
            }

            if (!isJumpPressing || _isOnWall)
            {
                return 0f;
            }

            return base.CalculateYVelocity();
        }

        protected override float CalculateJumpVelocity(float yVelocity)
        {
            if (!_isGrounded && _allowDoubleJump)
            {
                _particles.Spawn("Jump");
                _allowDoubleJump = false;
                return _jumpSpeed;
            }

            return base.CalculateJumpVelocity(yVelocity);
        }

        public void AddCoins(int coins)
        {
            _session.Data.Coins += coins;
        }

        public void RemoveCoins()
        {
            _session.Data.Coins = 0;
        }

        public override void TakeDamage()
        {
            base.TakeDamage();
            if (_session.Data.Coins > 0)
            {
                SpawnCoins();
            }
        }

        private void SpawnCoins()
        {
            var numCoinsToDispose = Mathf.Min(_session.Data.Coins, 5);
            _session.Data.Coins -= numCoinsToDispose;

            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);

            _hitParticles.gameObject.SetActive(true);
            _hitParticles.Play();
        }

        public void Inreact()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                _interActionRadius,
                _interActionResult,
                _interActionLayer);

            for (int i = 0; i < size; i++)
            {
                var interactable = _interActionResult[i].GetComponent<InteractableComponent>();
                if (interactable != null) interactable.Interact();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.IsInLayer(_groundLayer))
            {
                var contact = collision.contacts[0];
                if (contact.relativeVelocity.y >= _fallVelocity)
                {
                    _particles.Spawn("Fall");
                }
            }
            if (collision.gameObject.tag.Equals("Platform"))
            {
                this.transform.parent = collision.transform;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Platform"))
            {
                this.transform.parent = null;
            }
        }

        public override void Attack()
        {
            if (!_session.Data.IsArmed) return;
            base.Attack();

        }

        public void ArmHero()
        {
            _session.Data.IsArmed = true;
            UpdateHeroWeapon();
        }

        private void UpdateHeroWeapon()
        {
            _animator.runtimeAnimatorController = _session.Data.IsArmed ? _armed : _disarmed;

        }
    }
}