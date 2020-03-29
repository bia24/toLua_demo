using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class Lualauncher : MonoBehaviour {

    public static Lualauncher instance;

    private LuaState _lua=null;
    public LuaState lua { get { return _lua; } }
    private LuaLooper looper = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;


        _lua = new LuaState();
        lua.Start();
        LuaBinder.Bind(lua);
        
        //和协程有关
        DelegateFactory.Init();
        looper = gameObject.AddComponent<LuaLooper>();
        looper.luaState = lua;

        string filePath = Application.dataPath + "/MyTest/LuaScripts";
         lua.AddSearchPath(filePath);
            
        //加载指定模块
        lua.Require("Control");

    }


    private void OnDestroy()
    {
        if (lua != null)
        {
            lua.Dispose();
            _lua = null;
        }
    }
}
