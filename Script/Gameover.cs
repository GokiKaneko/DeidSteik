using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject player; // Playerオブジェクトをアサイン
    public GameObject objectToActivate; // Playerが消えたときにアクティブにするオブジェクト

    void Update()
    {
        
        if (player == null)
        {
          
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            
            this.enabled = false;
        }
    }
}
