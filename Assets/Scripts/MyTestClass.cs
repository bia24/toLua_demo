using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestClass {
    public delegate void shange();
    public string name;
    public int id;

    public MyTestClass()
    {
        name = "null";
        id = 0;
    }



    public MyTestClass(string name,int id)
    {
        this.name = name;
        this.id = id;
    }
}


