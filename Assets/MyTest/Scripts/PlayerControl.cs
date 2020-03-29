using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class PlayerControl : MonoBehaviour {

    public float speed = 25f;
    private Rigidbody playerRigidbody=null;

    public delegate void GameOverEvent();
    public event GameOverEvent onGameOver=null;
    private bool _isGameOver = true;
    public bool isGameOver
    {
        get
        {
            return _isGameOver;
        }

        set
        {
            if (value == true)
            {
                _isGameOver = value;
                if (onGameOver != null)
                    onGameOver();
            }
            else
                _isGameOver = value;
        }
    }
    
    
    private LuaState lua = null;
    private LuaFunction fun = null;

    private void OnEnable()
    {
        isGameOver = true;
    }


    private void Start()
    {
        lua = Lualauncher.instance.lua;

        if (gameObject.tag != "Player")
            gameObject.tag = "Player";


        playerRigidbody = GetComponent<Rigidbody>();

        onGameOver += StopSphereMove;

    }

    // Update is called once per frame
    void Update () {

        if (isGameOver) return;

        fun= lua.GetFunction("Control.PlayerSphereMove");
        fun.Call(playerRigidbody, speed);

    }

    private void StopSphereMove()
    {
        fun = lua.GetFunction("Control.GameEnd");
        fun.Call(playerRigidbody);
    }
    
}


