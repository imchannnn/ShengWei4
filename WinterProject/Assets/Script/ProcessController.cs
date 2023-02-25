using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ProcessController : MonoBehaviour
{
    [SerializeField] private float myMaxHP, enemyMaxHP,timeLimit;
    [SerializeField] private HealthControl myHP;
    [SerializeField] private HealthControl enemyHP;
    [SerializeField] private int enemyDamage, myDamage;
    [SerializeField] QuizManager quizManager;
    [SerializeField] Text firstText;
    [SerializeField] Canvas menu, mainPage;
    [SerializeField] Image quiz,battle,win,lose;
    [SerializeField] Slider timeSlider;
    [SerializeField] ParticleSystem ex;
    private float currentTime;
    private GameStatus gameStatus = GameStatus.IDLE;
    private bool attackDir;
    public GameStatus GameStatus
    {
        get { return gameStatus; }
        set { gameStatus = value; }
    }
    void Start()
    {
        ex.Stop();        
    }
    public void StartForTest()
    {
        myHP.SetMaxHP(myMaxHP);
        enemyHP.SetMaxHP(enemyMaxHP);
        menu.transform.gameObject.SetActive(false);
        quiz.transform.gameObject.SetActive(false);
        mainPage.transform.gameObject.SetActive(true);
        Invoke("StartGame", 2f);
    }

    void TimeReset()
    {
        currentTime = timeLimit;
    }
    void StartGame()
    {
        timeSlider.maxValue = timeLimit;
        timeSlider.value = timeLimit;
        currentTime = timeLimit;
        firstText.transform.gameObject.SetActive(false);
        quizManager.StartSetting();
        quiz.transform.gameObject.SetActive(true);
        //battle.transform.gameObject.SetActive(false);
        gameStatus = GameStatus.ANSWER;
    }
    public void Battle(bool val)
    {
        gameStatus = GameStatus.BATTLE;
        attackDir = val;
        Invoke("OpenBattleUI",0.2f);
        
    }

    void OpenBattleUI()
    {
        quiz.gameObject.SetActive(false);
        //battle.gameObject.SetActive(true);
        Invoke("BattleProcess", 0.2f); //轉換測試方法與實際方法
    }

    //測試用
    void BattleProcess()
    {
        if (attackDir)
        {
            enemyHP.Damage(myDamage);
            if (enemyHP.ZeroDetect())
            {
                gameStatus = GameStatus.IDLE;
                Invoke("WinPage", 1f);
            }
            else
            {
                Invoke("ReturnQuiz", 1f);
            }
        }
        else
        {
            myHP.Damage(enemyDamage);
            if (myHP.ZeroDetect())
            {
                gameStatus = GameStatus.IDLE;
                Invoke("LosePage", 1f);
            }
            else
            {
                Invoke("ReturnQuiz", 1f);
            }
        }
    }
    
    //動畫播放--實際使用
    public void BattleAnime()
    {
        if (attackDir)
        {
            //攻擊敵方動畫
        }
        else
        {
            //我方被攻擊動畫
        }
    }
    //動畫播放--攻擊敵方
    public void Attack()
    {
        enemyHP.Damage(myDamage);
        if (enemyHP.ZeroDetect())
        {
            gameStatus = GameStatus.IDLE;
            Invoke("WinPage", 1f);
        }
        else
        {
            Invoke("ReturnQuiz", 1f);
        }
    }

    //動畫播放--我方被攻擊
    public void Attacked()
    {
        myHP.Damage(enemyDamage);
        if (myHP.ZeroDetect())
        {
            gameStatus = GameStatus.IDLE;
            Invoke("LosePage", 1f);
        }
        else
        {
            Invoke("ReturnQuiz", 1f);
        }
    }
    void ReturnQuiz()
    {
        TimeReset();
        gameStatus =GameStatus.ANSWER;
        quiz.transform.gameObject.SetActive(true);
        //battle.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameStatus == GameStatus.ANSWER)
        {
            currentTime -= Time.deltaTime;
            SetTimer(currentTime);
        }
    }

    void SetTimer(float value)
    {
        timeSlider.value = value;
        if (currentTime <= 0)
        {
            gameStatus = GameStatus.BATTLE;
            Battle(false);
            TimeReset();
            quizManager.TimeIsOver();
        }
    }

    void LosePage()
    {
        lose.transform.gameObject.SetActive(true);
    }
    void WinPage()
    {
        win.transform.gameObject.SetActive(true);
    }
}


public enum GameStatus
{
    IDLE,
    ANSWER,
    BATTLE,
    STOP,
}
