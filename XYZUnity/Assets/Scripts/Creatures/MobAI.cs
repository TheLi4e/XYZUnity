using Scripts.Components;
using System.Collections;
using UnityEngine;

namespace Scripts.Creatures
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private LayerCheck _vision;
        [SerializeField] private LayerCheck _canAttack;

        [SerializeField] private float _alarmDelay = 0.5f;
        [SerializeField] private float _attackCoolDown = 1f;


        private Coroutine _current;
        private GameObject _target;

        private SpawnListComponent _particles;
        private Creature _creature;


        private void Awake()
        {
            _particles = GetComponent<SpawnListComponent>();
            _creature = GetComponent<Creature>();
        }

        private void Start()
        {
            StartState(Patrolling());
        }

        public void OnHeroInVission(GameObject go)
        {
            _target = go;

            StartState(AgroToHero());
        }

        private IEnumerator AgroToHero()
        {
            _particles.Spawn("Exclamation");
            yield return new WaitForSeconds(_alarmDelay);

            StartState(GoToHero());
        }
        private IEnumerator GoToHero()
        {
            while (_vision.IsTouchingLayer)
            {
                if (_canAttack.IsTouchingLayer)
                {
                    StartState(Attack());
                }
                else
                {
                    SetDirectionToTarget();
                }
                yield return null;
            }
        }

        private IEnumerator Attack()
        {
            while (_canAttack.IsTouchingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackCoolDown);
            }

            StartState(GoToHero());
        }

        private void SetDirectionToTarget()
        {
            var direction = _target.transform.position - transform.position;
            direction.y = 0;
            _creature.SetDirection(direction.normalized);
        }

        private IEnumerator Patrolling()
        {
            yield return null;
        }

        private void StartState(IEnumerator coroutine)
        {
            if (_current != null)
                StopCoroutine(coroutine);

            _current = StartCoroutine(coroutine);
        }
    }
}
