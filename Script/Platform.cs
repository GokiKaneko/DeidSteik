using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    /// <summary>�U�蕝(x)</summary>
    public float m_amplitudeX = 1f;
    /// <summary>�U�蕝(y)</summary>
    public float m_amplitudeY = 0f;
    /// <summary>��������</summary>
    public float m_speedX = 2.0f;
    /// <summary>��������</summary>
    public float m_speedY = 2.0f;
    /// <summary>���ړ��̂��߂̃^�C�}�[</summary>
    private float m_timerX;
    /// <summary>�c�ړ��̂��߂̃^�C�}�[</summary>
    private float m_timerY;
    /// <summary>�����ʒu</summary>
    private Vector2 m_initialPosition;

    void Start()
    {
        // �����ʒu���L�����Ă���
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        // �O�p�֐����g���ăI�u�W�F�N�g�̈ʒu������������
        m_timerX += Time.deltaTime * m_speedX;
        m_timerY += Time.deltaTime * m_speedY;
        float posX = Mathf.Sin(m_timerX) * m_amplitudeX;
        float posY = Mathf.Sin(m_timerY) * m_amplitudeY;
        Vector2 pos = m_initialPosition;
        pos = pos + new Vector2(posX, posY);
        transform.position = pos;
    }

    // �v���C���[����ɏ�������A������q�I�u�W�F�N�g�Ƃ��邱�Ƃɂ��v���C���[�̓I�u�W�F�N�g�ƈꏏ�ɓ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.transform.SetParent(transform);
    }

    // �v���C���[���I�u�W�F�N�g���痣�ꂽ���́A�e�q�֌W����������
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.transform.SetParent(null);
    }
}
