using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加：Sliderを扱うために必要

public class boss : MonoBehaviour
{
    /// <summary>敵のライフ</summary>
    [SerializeField] int m_life = 1;
    /// <summary>最大ライフ</summary>
    [SerializeField] int m_maxLife = 1;  // ボスの最大ライフを追加
    /// <summary>敵の弾のプレハブ</summary>
    [SerializeField] GameObject m_enemyBulletPrefab = null;
    /// <summary>敵が弾を発射する間隔（秒）</summary>
    [SerializeField] float m_fireInterval = 1f;
    /// <summary>敵が弾を発射する場所</summary>
    [SerializeField] Transform[] m_muzzles = null;
    /// <summary>爆発エフェクトのプレハブ</summary>
    [SerializeField] GameObject m_explosionPrefab = null;
    /// <summary>HP表示用のSlider</summary>
    [SerializeField] Slider m_hpSlider = null;  // 追加：HPバー用のSliderをリンク
    float m_timer;

    void Start()
    {
        // ライフの初期化
        m_life = m_maxLife;  // 現在のライフを最大ライフで初期化

        // HPスライダーの初期設定
        if (m_hpSlider != null)
        {
            m_hpSlider.maxValue = m_maxLife;  // 最大ライフに合わせる
            m_hpSlider.value = m_life;  // 現在のライフをスライダーに反映
        }

        // muzzle が設定されていなかったら自分自身の座標から弾を発射する
        if (m_muzzles == null || m_muzzles.Length == 0)
        {
            m_muzzles = new Transform[1] { this.transform };
        }
    }

    void Update()
    {
        if (m_enemyBulletPrefab)
        {
            // 一定間隔で弾を発射する
            m_timer += Time.deltaTime;
            if (m_timer > m_fireInterval)
            {
                m_timer = 0f;

                // 各 muzzle から弾を発射する
                foreach (Transform t in m_muzzles)
                {
                    Instantiate(m_enemyBulletPrefab, t.position, Quaternion.identity);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())  // 衝突相手がプレイヤーの弾だったら
        {
            Destroy(collision.gameObject);  // 弾のオブジェクトを破棄する
            m_life--;   // ライフを減らす

            // HPスライダーを更新する
            if (m_hpSlider != null)
            {
                m_hpSlider.value = m_life;  // 現在のライフをスライダーに反映
            }

            // ライフが 0 だったら
            if (m_life < 1)
            {
                // 爆発エフェクトを生成する
                if (m_explosionPrefab)
                {
                    Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
                }
                Destroy(this.gameObject);  // 自分自身を破棄する
            }
        }
    }
}

