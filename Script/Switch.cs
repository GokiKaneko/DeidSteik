using UnityEngine;
using UnityEngine.Events;   // UnityEvent ���g�����߂̖��O���

/// <summary>
/// �X�C�b�`�𐧌䂷��R���|�[�l���g�B
/// GameObject �ɒǉ�����Ă���g���K�[�Ƀv���C���[���ڐG������AActions �ɓo�^�����֐����Ăяo���B
/// </summary>
public class Switch : MonoBehaviour
{
    [Tooltip("�X�C�b�`�̃g���K�[�� Player ���ڐG�������ɌĂԊ֐���o�^����B")]
    [SerializeField] UnityEvent _actions;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // �o�^�����֐����Ăяo���B
            _actions.Invoke();
        }
    }
}