using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Reader.Games
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VedmaMovement : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Vedma vedma;
        
        [Header("Values:")]
        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            vedma.OnDead += SetActive;
        }

        private void OnDisable()
        {
            vedma.OnDead -= SetActive;
        }

        private void Start()
        {
            Move();
        }

        private void OnCollisionStay2D(Collision2D col)
        {
            if (col.collider.CompareTag("Wall"))
            {
                Move();
            }
        }

        private void SetActive()
        {
            enabled = false;
        }

        private void Move()
        {
            _rigidbody.velocity = GetRandomDirection();
        }

        private Vector2 GetRandomDirection()
        {
            Vector2 startDirection = new(Random.Range(-0.95f, 0.95f), Random.Range(-0.95f, 0.95f));
            startDirection.Normalize();
            startDirection *= speed;

            return startDirection;
        }
    }
}
