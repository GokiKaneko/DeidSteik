using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject player; // Player�I�u�W�F�N�g���A�T�C��
    public GameObject objectToActivate; // Player���������Ƃ��ɃA�N�e�B�u�ɂ���I�u�W�F�N�g

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
