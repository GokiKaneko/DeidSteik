using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    [SerializeField] string sceneName; // 読み込むシーン名を指定

    private void Update()
    {
        // Rキーが押されたかどうかを確認
        if (Input.GetKeyDown(KeyCode.R))
        {
            // シーンを再読み込み
            SceneManager.LoadScene(sceneName);
        }
    }
}
