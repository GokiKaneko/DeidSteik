using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    /// <summary>�G�̃��C�t</summary>
    [SerializeField] int m_life = 1;
    /// <summary>�G�̒e�̃v���n�u</summary>
    [SerializeField] GameObject m_enemyBulletPrefab = null;
    /// <summary>�G���e�𔭎˂���Ԋu�i�b�j</summary>
    [SerializeField] float m_fireInterval = 1f;
    /// <summary>�G���e�𔭎˂���ꏊ</summary>
    [SerializeField] Transform[] m_muzzles = null;
    /// <summary>�����G�t�F�N�g�̃v���n�u</summary>
    [SerializeField] GameObject m_explosionPrefab = null;
    float m_timer;

    void Start()
    {
        // muzzle ���ݒ肳��Ă��Ȃ������玩�����g�̍��W����e�𔭎˂���
        if (m_muzzles == null || m_muzzles.Length == 0)
        {
            m_muzzles = new Transform[1] { this.transform };
        }
    }

    void Update()
    {
        if (m_enemyBulletPrefab)
        {
            // ���Ԋu�Œe�𔭎˂���
            m_timer += Time.deltaTime;
            if (m_timer > m_fireInterval)
            {
                m_timer = 0f;

                // �e muzzle ����e�𔭎˂���
                foreach (Transform t in m_muzzles)
                {
                    Instantiate(m_enemyBulletPrefab, t.position, Quaternion.identity);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())  // �Փˑ��肪 �e ��������
        {
            Destroy(collision.gameObject);  // �e�̃I�u�W�F�N�g��j������
            m_life--;   // ���C�t�����炷

            // ���C�t�� 0 ��������
            if (m_life < 1)
            {
                // �����G�t�F�N�g�𐶐�����
                if (m_explosionPrefab)
                {
                    Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
                }
                Destroy(this.gameObject);       // �����Ď������j������
            }
        }
    }
}
