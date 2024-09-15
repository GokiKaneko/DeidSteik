using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    private static BGMController instance;

    public AudioClip scene1BGM;  // �V�[��1��BGM
    public AudioClip scene2BGM;  // �V�[��2��BGM
    public AudioClip scene3BGM;
    public AudioClip scene4BGM;
    public AudioClip scene5BGM;
    private AudioSource audioSource;

    void Awake()
    {
        // �V���O���g���p�^�[�����g�p���āABGMController��������������Ȃ��悤�ɂ���
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ���̃I�u�W�F�N�g��j�����Ȃ��悤�ɂ���
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;  // �V�[�����[�h���̃C�x���g�ɓo�^
        }
        else
        {
            Destroy(gameObject);  // ���ł�BGMController�����݂���ꍇ�͐V�������̂�j��
        }
    }

    // �V�[�������[�h���ꂽ�Ƃ��ɌĂяo�����
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeBGM(scene.name);  // �V�[�����ɉ�����BGM��ύX
    }

    // �V�[���ɉ�����BGM��ύX���鏈��
    void ChangeBGM(string sceneName)
    {
        AudioClip newBGM = null;

        // �V�[�����ɉ����ēK�؂�BGM��I��
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

        // �V����BGM������ꍇ�A�؂�ւ���
        if (newBGM != null && audioSource.clip != newBGM)
        {
            audioSource.clip = newBGM;
            audioSource.Play();
        }
    }
}

