using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [SerializeField] string sceneName; // �ǂݍ��ރV�[�������w��

    private void Update()
    {
        // R�L�[�������ꂽ���ǂ������m�F
        if (Input.GetKeyDown(KeyCode.R))
        {
            // �V�[�����ēǂݍ���
            SceneManager.LoadScene(sceneName);
        }
    }
}
