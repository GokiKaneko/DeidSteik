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
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField, Range(0, 10)] int m_bulletLimit = 0;
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

        // �N���b�N�Œe�𔭎˂��鏈��
        if (Input.GetButtonDown("Fire1"))  // Fire1 �{�^���i�f�t�H���g�Ń}�E�X�̍��N���b�N�j����������
        {
            Fire1();  // �e�𔭎˂���
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

    // �e�𔭎˂��郁�\�b�h
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab �Ƀv���n�u���ݒ肳��Ă��鎞 ���� m_muzzle �ɒe�̔��ˈʒu���ݒ肳��Ă��鎞
        {
            Instantiate(m_bulletPrefab, m_muzzle.position, m_muzzle.rotation);  // �e�𐶐����Ĕ��˂���
        }
    }

    public void JumpSpeeed(float jump)
    {
        _jumpSpeed += jump;
    }

    // ���n����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g�� "Ground" �^�O�����ꍇ�̂݁A���n�Ɣ��肷��
        if (collision.CompareTag("Ground"))
        {
            _isGrounded = true;
            _jumpCount = 0; // ���n���ɃW�����v�J�E���g�����Z�b�g
        }
    }

    // �n�ʂ��痣�ꂽ�ۂ̏���
    private void OnTriggerExit2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g�� "Ground" �^�O�����ꍇ�̂݁A�����Ɣ��肷��
        if (collision.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
