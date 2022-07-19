using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� ���¸� �����ϰ� �ʹ�.
// �ʿ�Ӽ� : �������, Ready, Start, Playing, GameOver
public class GameManager : MonoBehaviour
{
    // �ʿ�Ӽ� : �������, Ready, Start, Playing, GameOver
    //[HideInInspector]
    //[System.NonSerialized]
    public enum GameState
    {
        Ready,
        Start,
        Playing,
        GameOver
    }

    public GameState m_State = GameState.Ready;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ���� ���¸� �����ϰ� �ʹ�.
        switch(m_State)
        {
            case GameState.Ready:
                ReadyState();
                break;
            case GameState.Start:
                StartState();
                break;
            case GameState.Playing:
                PlayingState();
                break;
            case GameState.GameOver:
                GameOverState();
                break;
        }
    }

    // �����ð� ��ٷȴٰ� ���¸� Start �� ��ȯ
    // �ʿ�Ӽ� : ��ٸ��� �ð�, ����ð�
    public float readyDelayTime = 2;
    float currentTime = 0;
    public float startDelayTime = 5;
    private void ReadyState()
    {
        currentTime += Time.deltaTime;
        if(currentTime > readyDelayTime)
        {
            currentTime = 0;
            m_State = GameState.Start;
        }
    }

    // �����ð� ��ٷȴٰ� ���¸� Playing �� ��ȯ
    private void StartState()
    {
        currentTime += Time.deltaTime;
        if (currentTime > startDelayTime)
        {
            currentTime = 0;
            m_State = GameState.Playing;
        }
    }

    private void PlayingState()
    {
        
    }

    private void GameOverState()
    {
        
    }
}
