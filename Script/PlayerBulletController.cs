using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    /// <summary>�e�̔�ԑ��x</summary>
    [SerializeField] float m_bulletSpeed = 10f;
    /// <summary>�e����ԍő勗��</summary>
    [SerializeField] float m_maxDistance = 15f;
    Rigidbody2D m_rb;
    Transform playerTransform;
    SpriteRenderer playerSprite;

    // ���ˎ��̈ʒu���L�^����ϐ�
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
}

