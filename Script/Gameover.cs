using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToActivate; 

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
