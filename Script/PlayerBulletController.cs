using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] float m_bulletSpeed = 10f;
    [SerializeField] float m_maxDistance = 15f;
    [SerializeField] AudioClip hitSound; // �Փˎ��̉�
    private AudioSource audioSource;

    Rigidbody2D m_rb;
    Transform playerTransform;
    SpriteRenderer playerSprite;
    Vector3 startPosition;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
            playerSprite = player.GetComponent<SpriteRenderer>();
        }

        m_rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  // AudioSource�̎擾

        Vector2 direction;
        if (playerSprite.flipX)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        startPosition = transform.position;
        Vector3 velocity = direction.normalized * m_bulletSpeed;
        m_rb.velocity = velocity;
    }

    void Update()
    {
        float distanceTraveled = Vector3.Distance(startPosition, transform.position);
        if (distanceTraveled > m_maxDistance)
        {
            Destroy(gameObject);
        }
    }

    // �e���Փ˂����Ƃ��̏���
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);  // ���ʉ����Đ�
        }
        Destroy(gameObject);  // �Փˌ�ɒe��j��
    }
}
