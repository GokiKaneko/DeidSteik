using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject player; // Player�I�u�W�F�N�g���A�T�C��
    public GameObject objectToActivate; // Player���������Ƃ��ɃA�N�e�B�u�ɂ���I�u�W�F�N�g

    void Update()
    {
        // Player�����݂��Ă��邩�ǂ������`�F�b�N
        if (player == null)
        {
            // Player�����Ȃ��Ȃ�����A�ʂ�GameObject���A�N�e�B�u�ɂ���
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            // �K�v�ɉ����āA���̃X�N���v�g�𖳌�������Ȃǂ̒ǉ��������\
            this.enabled = false;
        }
    }
}
