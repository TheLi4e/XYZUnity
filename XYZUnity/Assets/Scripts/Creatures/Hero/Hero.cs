using Scripts.Model.Data;
using Scripts.Components;
using Scripts.Model;
using Scripts.Utils;
using UnityEditor.Animations;
using UnityEngine;
using System;
using Scripts.Model.Definitions;

namespace Scripts
{
    public class Hero : Creature, ICanAddInInventory
    {
        [SerializeField] private LayerCheck _wallCheck;
        [SerializeField] private CheckCircleOverlap _interactionCheck;

        [SerializeField] private float _fallVelocity;

        [SerializeField] private Cooldown _throwCooldown;
        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;
        [SerializeField] private SpawnComponent _throwSpawner;

        [Space]
        [Header("Particles")]
        [SerializeField] private ParticleSystem _hitParticles;

        private static readonly int ThrowKey = Animator.StringToHash("throw");
        private static readonly int IsOnWallKey = Animator.StringToHash("is-on-wall");

        private bool _allowDoubleJump;
        private bool _isOnWall;
        private HealthComponent _health;

        private GameSession _session;
        private float _defaultGravityScale;

        private const string SwordId = "Sword";
        private int SwordCount => _session.Data.Inventory.Count(SwordId);
        private int CoinsCount => _session.Data.Inventory.Count("Coin");
        private string SelectedItemId => _session.QuickInventory.SelectedItem.Id;

        private bool CanThrow
        {
            get
            {
                if (SelectedItemId == SwordId)
                    return SwordCount > 1;
                var def = DefsFacade.Instance.Items.Get(SelectedItemId);

                return def.HasTag(ItemTag.Throwable);
            }
        }

        protected override void Awake()
        {
            base.Awake();

            _defaultGravityScale = Rigidbody.gravityScale;
        }

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _health = GetComponent<HealthComponent>();
            _session.Data.Inventory.OnChanged += OnInventoryChanged;

            _health.SetHealth(_session.Data.Hp.Value);
            UpdateHeroWeapon();
        }

        private void OnInventoryChanged(string id, int value)
        {
            if (id == SwordId)
            {
                UpdateHeroWeapon();
            }
        }

        public void OnHealthChanged(int currentHealth)
        {
            _session.Data.Hp.Value = currentHealth;
        }

        protected override void Update()
        {
            base.Update();

            var moveToSameDirection = Direction.x * transform.lossyScale.x > 0;

            if (_wallCheck.IsTouchingLayer && moveToSameDirection)
            {
                _isOnWall = true;
                Rigidbody.gravityScale = 0;
            }
            else
            {
                _isOnWall = false;
                Rigidbody.gravityScale = _defaultGravityScale;
            }

            Animator.SetBool(IsOnWallKey, _isOnWall);
        }

        private void OnDestroy()
        {
            _session.Data.Inventory.OnChanged -= OnInventoryChanged;
        }

        protected override float CalculateYVelocity()
        {

            var yVelocity = Rigidbody.velocity.y;
            bool isJumpPressing = Direction.y > 0;


            if (IsGrounded || _isOnWall)
            {
                _allowDoubleJump = true;
            }

            if (!isJumpPressing && _isOnWall)
            {
                return 0f;
            }

            return base.CalculateYVelocity();
        }

        protected override float CalculateJumpVelocity(float yVelocity)
        {
            if (!IsGrounded && _allowDoubleJump && !_isOnWall)
            {
                _allowDoubleJump = false;
                DoJumpVfx();
                return _jumpSpeed;
            }

            return base.CalculateJumpVelocity(yVelocity);
        }

        public void AddInInventory(string id, int value)
        {
            _session.Data.Inventory.Add(id, value);
        }

        public void RemoveCoins()
        {
            _session.Data.Inventory.Remove("Coin", CoinsCount);
        }

        public override void TakeDamage()
        {
            base.TakeDamage();

            if (CoinsCount > 0)
            {
                SpawnCoins();
            }
        }

        private void SpawnCoins()
        {
            var numCoinsToDispose = Mathf.Min(CoinsCount, 5);
            _session.Data.Inventory.Remove("Coin", numCoinsToDispose);

            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);

            _hitParticles.gameObject.SetActive(true);
            _hitParticles.Play();
        }

        public void Inreact()
        {
            _interactionCheck.Check();
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
            if (SwordCount <= 0) return;
            base.Attack();
        }

        private void UpdateHeroWeapon()
        {
            Animator.runtimeAnimatorController = SwordCount > 0 ? _armed : _disarmed;

        }

        public void OnDoThrow()
        {
            Sounds.Play("Range");

            var throwableId = SelectedItemId;
            var throwableDef = DefsFacade.Instance.ThrowableItems.Get(throwableId);
            _throwSpawner.SetPrefab(throwableDef.Projectile);
            _throwSpawner.Spawn();

            _session.Data.Inventory.Remove(throwableId, 1);
        }

        public void Throw()
        {
            if (!_throwCooldown.IsReady || !CanThrow) return;

            Animator.SetTrigger(ThrowKey);
            _throwCooldown.Reset();

        }

        public void AddSword()
        {
            _session.Data.Inventory.Add("Sword", 1);
        }

        public void UsePotion()
        {
            var potions = _session.Data.Inventory.Count("HealthPotion");
            if (potions > 0)
            {
                _health.ModifyHealth(5);
                _session.Data.Inventory.Remove("HealthPotion", 1);

            }
        }

        public void NextItem()
        {
            _session.QuickInventory.SetNextItem();
        }
    }
}