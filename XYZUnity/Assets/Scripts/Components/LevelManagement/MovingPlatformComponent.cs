using UnityEngine;

namespace Scripts.Components
{
    internal class MovingPlatformComponent : MonoBehaviour
    {

        [SerializeField] private float _speed;


        private bool _movingDown = true;

        void FixedUpdate()
        {
            PlatformMoving();
        }

        private void PlatformMoving()
        {
            PlatformMovingDirection();
            if (_movingDown)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - _speed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + _speed * Time.deltaTime);
            }
        }

        private void PlatformMovingDirection()
        {
            if (transform.position.y < -5f)
            {
                _movingDown = false;
            }
            else if (transform.position.y > 5f)
            {
                _movingDown = true;
            }
        }

    }
}
