using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject player; // Playerオブジェクトをアサイン
    public GameObject objectToActivate; // Playerが消えたときにアクティブにするオブジェクト

    void Update()
    {
        // Playerが存在しているかどうかをチェック
        if (player == null)
        {
            // Playerがいなくなったら、別のGameObjectをアクティブにする
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            // 必要に応じて、このスクリプトを無効化するなどの追加処理も可能
            this.enabled = false;
        }
    }
}
