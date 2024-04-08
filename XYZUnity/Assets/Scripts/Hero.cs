using Assets.Scripts;
using Assets.Scripts.Components;
using Assets.Scripts.Utils;
using System;
using System.IO.IsolatedStorage;
using UnityEditor.Animations;
using UnityEngine;

namespace Scripts
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _damageJumpSpeed;
        [SerializeField] private float _fallVelocity;
        [SerializeField] private int _damage;
        [SerializeField] private LayerCheck _groundCheck;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _interActionRadius;
        [SerializeField] private LayerMask _interActionLayer;

        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;

        [SerializeField] private CheckCircleOverlap _attackRange;

        [SerializeField] private SpawnComponent _footStepsParticles;
        [SerializeField] private SpawnComponent _jumpStepsParticles;
        [SerializeField] private ParticleSystem _hitParticles;
        [SerializeField] private SpawnComponent _fallParticles;
        [SerializeField] private SpawnComponent _attackParticles;


        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private bool _isGrounded;
        private bool _allowDoubleJump;
        private Collider2D[] _interActionResult = new Collider2D[1];
        private int _coins = 0;
        private bool _isArmed;

        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int IsRunningKey = Animator.StringToHash("is-running");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int Hit = Animator.StringToHash("hit");
        private static readonly int AttackKey = Animator.StringToHash("attack");

        public int Coins { get { return _coins; } }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            _isGrounded = IsGrounded();
        }

        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            _animator.SetBool(IsGroundKey, _isGrounded);
            _animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);
            _animator.SetBool(IsRunningKey, _direction.x != 0);

            UpdateSpriteDirection();
        }

        private float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            bool isJumpPressing = _direction.y > 0;
            var isGrounded = IsGrounded();

            if (isGrounded) _allowDoubleJump = true;
            if (isJumpPressing)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);

            }

            else if (_rigidbody.velocity.y > 0)
                yVelocity *= 0.5f;

            return yVelocity;
        }

        private void UpdateSpriteDirection()
        {
            if (_direction.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (_direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        private bool IsGrounded()
        {
            return _groundCheck.IsTouchingLayer;
        }

        public void SaySomething()
        {
            Debug.Log("Something!");
        }

        public void AddCoins(int coins)
        {
            _coins += coins;
        }

        public void RemoveCoins()
        {
            _coins = 0;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            var isFalling = _rigidbody.velocity.y <= 0.001f;
            if (!isFalling) return yVelocity;

            if (_isGrounded)
            {
                yVelocity += _jumpSpeed;
                _jumpStepsParticles.Spawn();
            }


            else if (_allowDoubleJump)
            {
                yVelocity = _jumpSpeed;
                _jumpStepsParticles.Spawn();
                _allowDoubleJump = false;
            }

            return yVelocity;
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(Hit);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpSpeed);
            if (_coins > 0)
            {
                SpawnCoins();
            }
        }

        private void SpawnCoins()
        {
            var numCoinsToDispose = Mathf.Min(_coins, 5);
            _coins -= numCoinsToDispose;

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
                if (interactable != null)
                    interactable.Interact();
            }
        }

        public void SpawnFootDust()
        {
            _footStepsParticles.Spawn();
        }

        public void SpawnJumpDust()
        {
            _jumpStepsParticles.Spawn();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.IsInLayer(_groundLayer))
            {
                var contact = collision.contacts[0];
                if (contact.relativeVelocity.y >= _fallVelocity)
                {
                    _fallParticles.Spawn();
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

        internal void Attack()
        {
            if (!_isArmed) return;
            _animator.SetTrigger(AttackKey);
            _attackParticles.Spawn();
          
        }

        private void OnAttack()
        {
            var gos = _attackRange.GetObjectsInRange();
            foreach (var go in gos)
            {
                var hp = go.GetComponent<HealthComponent>();
                if (hp != null && go.CompareTag("Enemy"))
                {
                    hp.ApplyDamage(_damage);
                }
            }
        }

        internal void ArmHero()
        {
            _isArmed = true;
            _animator.runtimeAnimatorController = _armed;
        }
    }
}   



