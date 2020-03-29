using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class GoldBuilder : MonoBehaviour {

    private LuaState lua = null;
    private LuaFunction fun = null;
    private UIControl ui = null;
    // Use this for initialization
    void Start () {
        lua = Lualauncher.instance.lua;
        ui = GameObject.Find("Canvas").GetComponent<UIControl>();
        ui.onStartButtonClick += StartGoldBuild;

    }
	
    private void StartGoldBuild()
    {
        fun = lua.GetFunction("Control.GoldBuilder");
        fun.Call();
    }
	
}
