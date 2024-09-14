using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] int m_life;
    [SerializeField] int m_maxlife;

    // Start is called before the first frame update
    void Start()
    {
        m_life = m_maxlife;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            m_life--;
        }
        if (m_life < 1)
        {
            Destroy(this.gameObject);  
        }
    }
}
