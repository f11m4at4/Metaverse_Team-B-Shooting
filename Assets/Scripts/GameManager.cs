using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임의 진행 상태를 관리하고 싶다.
// 필요속성 : 현재상태, Ready, Start, Playing, GameOver
public class GameManager : MonoBehaviour
{
    // 필요속성 : 현재상태, Ready, Start, Playing, GameOver
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
        // 게임의 진행 상태를 관리하고 싶다.
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

    // 일정시간 기다렸다가 상태를 Start 로 전환
    // 필요속성 : 기다리는 시간, 경과시간
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

    // 일정시간 기다렸다가 상태를 Playing 로 전환
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
