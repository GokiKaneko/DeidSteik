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
    [SerializeField] int _maxJumps = 2; // 最大ジャンプ回数
    [SerializeField] Transform m_muzzle = null;
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField, Range(0, 10)] int m_bulletLimit = 0;
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite; // スプライトレンダラーを使うための変数
    bool _isGrounded = true;
    int _jumpCount = 0;
    Vector3 _initialPosition = default;
    float h;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>(); // SpriteRenderer を取得
        _initialPosition = transform.position;
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = _rb.velocity;

        // 横移動
        if (h != 0)
        {
            velocity.x = h * _moveSpeed;

            // スプライトの反転処理
            if (h > 0)
            {
                _sprite.flipX = false; // 右に移動している場合はスプライトを元の向きに
            }
            else if (h < 0)
            {
                _sprite.flipX = true; // 左に移動している場合はスプライトを反転
            }
        }

        // クリックで弾を発射する処理
        if (Input.GetButtonDown("Fire1"))  // Fire1 ボタン（デフォルトでマウスの左クリック）を押した時
        {
            Fire1();  // 弾を発射する
        }

        // ジャンプ処理
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

    // 弾を発射するメソッド
    void Fire1()
    {
        if (m_bulletPrefab && m_muzzle) // m_bulletPrefab にプレハブが設定されている時 かつ m_muzzle に弾の発射位置が設定されている時
        {
            Instantiate(m_bulletPrefab, m_muzzle.position, m_muzzle.rotation);  // 弾を生成して発射する
        }
    }

    public void JumpSpeeed(float jump)
    {
        _jumpSpeed += jump;
    }

    // 着地判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトが "Ground" タグを持つ場合のみ、着地と判定する
        if (collision.CompareTag("Ground"))
        {
            _isGrounded = true;
            _jumpCount = 0; // 着地時にジャンプカウントをリセット
        }
    }

    // 地面から離れた際の処理
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 衝突したオブジェクトが "Ground" タグを持つ場合のみ、離陸と判定する
        if (collision.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
