using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2 : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float _jumpSpeed = 5f;
    [SerializeField] float _gravityDrag = .8f;
    [SerializeField] int _maxJumps = 2; // �ő�W�����v��
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite; // �X�v���C�g�����_���[���g�����߂̕ϐ�
    bool _isGrounded = true;
    int _jumpCount = 0;
    Vector3 _initialPosition = default;
    float h;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>(); // SpriteRenderer ���擾
        _initialPosition = transform.position;
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = _rb.velocity;

        // ���ړ�
        if (h != 0)
        {
            velocity.x = h * _moveSpeed;

            // �X�v���C�g�̔��]����
            if (h > 0)
            {
                _sprite.flipX = false; // �E�Ɉړ����Ă���ꍇ�̓X�v���C�g�����̌�����
            }
            else if (h < 0)
            {
                _sprite.flipX = true; // ���Ɉړ����Ă���ꍇ�̓X�v���C�g�𔽓]
            }
        }

        // �W�����v����
        if (Input.GetButtonDown("Jump") && (_isGrounded || _jumpCount < _maxJumps))
        {
            _jumpCount++;
            velocity.y = _jumpSpeed;

            if (!_isGrounded)
            {
                _isGrounded = false;
            }
        }
        else if (!Input.GetButton("Jump") && velocity.y > 0)
        {
            velocity.y *= _gravityDrag;
        }

        _rb.velocity = velocity;
    }

    public void JumpSpeeed(float jump)
    {
        _jumpSpeed += jump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded = true;
        _jumpCount = 0; // ���n���ɃW�����v�J�E���g�����Z�b�g
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }
}
