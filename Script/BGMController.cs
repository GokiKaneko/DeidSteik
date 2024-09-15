using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    private static BGMController instance;

    public AudioClip scene1BGM;  // シーン1のBGM
    public AudioClip scene2BGM;  // シーン2のBGM
    public AudioClip scene3BGM;
    public AudioClip scene4BGM;
    public AudioClip scene5BGM;
    private AudioSource audioSource;

    void Awake()
    {
        // シングルトンパターンを使用して、BGMControllerが複数生成されないようにする
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // このオブジェクトを破棄しないようにする
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;  // シーンロード時のイベントに登録
        }
        else
        {
            Destroy(gameObject);  // すでにBGMControllerが存在する場合は新しいものを破棄
        }
    }

    // シーンがロードされたときに呼び出される
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeBGM(scene.name);  // シーン名に応じてBGMを変更
    }

    // シーンに応じてBGMを変更する処理
    void ChangeBGM(string sceneName)
    {
        AudioClip newBGM = null;

        // シーン名に応じて適切なBGMを選択
        switch (sceneName)
        {
            case "BOSS":
                newBGM = scene1BGM;
                break;
            case "Clear":
                newBGM = scene2BGM;
                break;
            case "Home":
                newBGM = scene3BGM;
                break;
            case "1-1":
                newBGM = scene4BGM;
                break;
            case "2-1":
                newBGM = scene5BGM;
                break;
        }

        // 新しいBGMがある場合、切り替える
        if (newBGM != null && audioSource.clip != newBGM)
        {
            audioSource.clip = newBGM;
            audioSource.Play();
        }
    }
}

