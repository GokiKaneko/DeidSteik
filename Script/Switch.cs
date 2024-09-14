using UnityEngine;
using UnityEngine.Events;
public class Switch : MonoBehaviour
{
    [Tooltip("スイッチのトリガーに Player が接触した時に呼ぶ関数を登録する。")]
    [SerializeField] UnityEvent _actions;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            _actions.Invoke();
        }
    }
}