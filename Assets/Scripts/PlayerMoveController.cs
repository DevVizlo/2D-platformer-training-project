using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private const string AnimationPlayerRun = "Run";
    private const string AnimationPlayerJump = "Jump";

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _renderer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D)) 
        {
            _animator.SetTrigger(AnimationPlayerRun);
            _renderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);

        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetTrigger(AnimationPlayerRun);
            _renderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(AnimationPlayerJump);
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }
}
