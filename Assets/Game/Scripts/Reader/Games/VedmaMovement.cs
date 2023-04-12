using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Reader.Games
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VedmaMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Move();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            col
        }

        private void Move()
        {
            _rigidbody.velocity = GetRandomDirection();
        }

        private Vector2 GetRandomDirection()
        {
            Vector2 startDirection = new(Random.Range(-1, 1), Random.Range(-1, 1));
            startDirection.Normalize();
            startDirection *= speed;

            return startDirection;
        }
    }
}
