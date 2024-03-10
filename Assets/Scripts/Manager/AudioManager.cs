using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������
/// </summary>

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgmSource;//����bgm����Ƶ

    private void Awake()
    {
        Instance = this;
    }

    //��ʼ��
    public void Init()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
    }

    //����bgm
    public void PlayBGM(string name,bool isLoop = true)
    {
        //����BGM��������
        AudioClip clip = Resources.Load<AudioClip>("Sounds/BGM/" + name);//asset��BGM�����ļ���

        bgmSource.clip = clip;//������Ƶ

        bgmSource.loop = isLoop;

        bgmSource.Play();
    }

    //������Ч
    public void PlayEffect(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);//asset����Ч�����ļ���

        AudioSource.PlayClipAtPoint(clip, transform.position);//����
    }
}
