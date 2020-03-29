using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class GoldControl : MonoBehaviour {

    private LuaFunction fun = null;
    private LuaState lua = null;
    private UIControl ui = null;
	// Use this for initialization
	void Start () {
        lua = Lualauncher.instance.lua;
        fun = lua.GetFunction("Control.GoldControl");
        ui = GameObject.Find("Canvas").GetComponent<UIControl>();
        
	}

    private void Update()
    {
        fun.Call(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //加分
            ui.OnScoreTextAdd();
            //销毁本物体
            ClearSelf();
        }
    }

    public void ClearSelf()
    {
        Destroy(gameObject);
    }

}
