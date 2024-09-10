using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BOSShp : MonoBehaviour
{
    /// <summary>�Q�[�W��ω�������b��</summary>
    [SerializeField] float _changeValueInterval = 0.5f;
    Slider _slider = default;

    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    /// <summary>
    /// �Q�[�W�����炷
    /// </summary>
    /// <param name="value">����������ʁi�����j</param>
    public void Change(float value)
    {
        ChangeValue(_slider.value + value);
    }

    /// <summary>
    /// �Q�[�W�𖞃^���ɂ���
    /// </summary>
    public void Fill()
    {
        ChangeValue(1f);
    }

    /// <summary>
    /// �w�肳�ꂽ�l�܂ŃQ�[�W�����炩�ɕω�������
    /// </summary>
    /// <param name="value"></param>
    void ChangeValue(float value)
    {
        //_slider.value = value;
        DOTween.To(() => _slider.value, (float x) => _slider.value = x, value, 1f);

        // DOTween.To() ���g���ĘA���I�ɕω�������
        DOTween.To(() => _slider.value, // �A���I�ɕω�������Ώۂ̒l
            x => _slider.value = x, // �ω��������l x ���ǂ��������邩������
            value, // x ���ǂ̒l�܂ŕω������邩�w������
            _changeValueInterval);   // ���b�����ĕω������邩�w������
    }
}
