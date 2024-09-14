using UnityEngine;
using UnityEngine.Events;
public class Switch : MonoBehaviour
{
    [Tooltip("�X�C�b�`�̃g���K�[�� Player ���ڐG�������ɌĂԊ֐���o�^����B")]
    [SerializeField] UnityEvent _actions;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            _actions.Invoke();
        }
    }
}