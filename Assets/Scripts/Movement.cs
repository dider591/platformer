using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    private const string Walk = "Walk";
    private const string Jamp = "Jamp";

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jampFarce;
    [SerializeField] private Transform _graundCheck;
    [SerializeField] private LayerMask _layerMask;

    private float _speed = 2f;
    private bool _isGraunded;
    private float _graudRadius = 0.4f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        _isGraunded = Physics2D.OverlapCircle(_graundCheck.position, _graudRadius, _layerMask);

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool(Walk, true);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool(Walk, true);
            transform.Translate(_speed * Time.deltaTime * - 1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isGraunded)
        {
            _animator.SetTrigger(Jamp);
            _rigidbody.AddForce(Vector2.up * _jampFarce);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool(Walk, false);
        }
    }
}
