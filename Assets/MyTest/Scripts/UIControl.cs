using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LuaInterface;

public class UIControl : MonoBehaviour {

    private Button startButton = null;
    private Text scoreText = null;
    private PlayerControl player = null;
    private Image warnningUI = null;
    public delegate void StartButtonClickEvent();
    public event StartButtonClickEvent onStartButtonClick = null;

    private LuaFunction fun = null;
    private LuaState lua = null;

    private void Awake()
    {
        startButton = transform.Find("StartButton").GetComponent<Button>();
        scoreText = transform.Find("ScoreUI").Find("ScoreField").GetComponent<Text>();
        warnningUI = transform.Find("WarningUI").GetComponent<Image>();
        player = GameObject.Find("PlayerSphere").GetComponent<PlayerControl>();
    }

    private void Start()
    {
        lua = Lualauncher.instance.lua;
        //可视化设置
        warnningUI.gameObject.SetActive(false);

        startButton.onClick.AddListener(OnStartButtonClick);

        player.onGameOver += OnEndGame;
    }

    private void OnStartButtonClick()
    {
        player.isGameOver = false;
        startButton.gameObject.SetActive(false); 
        warnningUI.gameObject.SetActive(false);
        if (onStartButtonClick != null) onStartButtonClick();
    }

    private void OnEndGame()
    {
        startButton.gameObject.SetActive(true);
        warnningUI.gameObject.SetActive(true);
        OnScoreTextClear();
    }

    public void OnScoreTextAdd()
    {
        fun = lua.GetFunction("UI.OnScoreTextAdd");
        int score = int.Parse(scoreText.text);
        score = fun.Invoke<int,int>(score);
        scoreText.text = score.ToString();
    }

    public void OnScoreTextClear()
    {
        scoreText.text = "0";
    }




}
