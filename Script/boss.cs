using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  // DOTween ‚ðŽg—p‚·‚é‚½‚ß‚É’Ç‰Á

public class boss : MonoBehaviour
{
    [SerializeField] int m_life = 1;
    [SerializeField] int m_maxLife = 1; 
    [SerializeField] GameObject m_enemyBulletPrefab = null;
    [SerializeField] float m_fireInterval = 1f;
    [SerializeField] Transform[] m_muzzles = null;
    [SerializeField] GameObject m_explosionPrefab = null;
    [SerializeField] Slider m_hpSlider = null;
    float m_timer;
    void Start()
    {
        m_life = m_maxLife;
        if (m_hpSlider != null)
        {
            m_hpSlider.maxValue = m_maxLife;
            m_hpSlider.value = m_life;
        }
        if (m_muzzles == null || m_muzzles.Length == 0)
        {
            m_muzzles = new Transform[1] { this.transform };
        }
    }

    void Update()
    {
        if (m_enemyBulletPrefab)
        {
            m_timer += Time.deltaTime;
            if (m_timer > m_fireInterval)
            {
                m_timer = 0f;
                foreach (Transform t in m_muzzles)
                {
                    Instantiate(m_enemyBulletPrefab, t.position, Quaternion.identity);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject); 
            m_life--;
            if (m_hpSlider != null)
            {
                m_hpSlider.DOValue(m_life, 0.5f); 
            }

            
            if (m_life < 1)
            {
                Destroy(this.gameObject);  
            }
        }
    }
}
