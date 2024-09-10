using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed = 1f;
    [SerializeField] private float rotateX = 0;

    [SerializeField] private float rotateY = 0;

    [SerializeField] private float rotateZ = 0;
    private void Start()
    {

    }

    void Update()
    {
        // ������x���ɍs������
        if (this.transform.position.x > 10f)
        {
            // �������g��j������
            Destroy(this.gameObject);
        }

        // ��葬�x�ŉE�ɓ�����
        this.transform.Translate(Vector2.right * m_moveSpeed * Time.deltaTime);
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}