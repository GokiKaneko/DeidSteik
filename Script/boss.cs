using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // �ǉ��FSlider���������߂ɕK�v

public class boss : MonoBehaviour
{
    /// <summary>�G�̃��C�t</summary>
    [SerializeField] int m_life = 1;
    /// <summary>�ő僉�C�t</summary>
    [SerializeField] int m_maxLife = 1;  // �{�X�̍ő僉�C�t��ǉ�
    /// <summary>�G�̒e�̃v���n�u</summary>
    [SerializeField] GameObject m_enemyBulletPrefab = null;
    /// <summary>�G���e�𔭎˂���Ԋu�i�b�j</summary>
    [SerializeField] float m_fireInterval = 1f;
    /// <summary>�G���e�𔭎˂���ꏊ</summary>
    [SerializeField] Transform[] m_muzzles = null;
    /// <summary>�����G�t�F�N�g�̃v���n�u</summary>
    [SerializeField] GameObject m_explosionPrefab = null;
    /// <summary>HP�\���p��Slider</summary>
    [SerializeField] Slider m_hpSlider = null;  // �ǉ��FHP�o�[�p��Slider�������N
    float m_timer;

    void Start()
    {
        // ���C�t�̏�����
        m_life = m_maxLife;  // ���݂̃��C�t���ő僉�C�t�ŏ�����

        // HP�X���C�_�[�̏����ݒ�
        if (m_hpSlider != null)
        {
            m_hpSlider.maxValue = m_maxLife;  // �ő僉�C�t�ɍ��킹��
            m_hpSlider.value = m_life;  // ���݂̃��C�t���X���C�_�[�ɔ��f
        }

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
        if (collision.gameObject.GetComponent<PlayerController>())  // �Փˑ��肪�v���C���[�̒e��������
        {
            Destroy(collision.gameObject);  // �e�̃I�u�W�F�N�g��j������
            m_life--;   // ���C�t�����炷

            // HP�X���C�_�[���X�V����
            if (m_hpSlider != null)
            {
                m_hpSlider.value = m_life;  // ���݂̃��C�t���X���C�_�[�ɔ��f
            }

            // ���C�t�� 0 ��������
            if (m_life < 1)
            {
                // �����G�t�F�N�g�𐶐�����
                if (m_explosionPrefab)
                {
                    Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
                }
                Destroy(this.gameObject);  // �������g��j������
            }
        }
    }
}

