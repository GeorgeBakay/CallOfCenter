using System.Collections.Generic;
using UnityEngine;

public class LaptopScript : MonoBehaviour
{
    public Camera Camera;
    private static Canvas _canvas;
    public static bool Laptop_close;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Laptop_close = true;
        _canvas = Camera.GetComponentInChildren<Canvas>();
        _canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Laptop_close == false){
            Close();
        }
        
    }
    public static void Open(){
        Laptop_close = false;
        _canvas.enabled = true;
    }
    public static void Close(){
        Laptop_close = true;
         _canvas.enabled = false;
    }
}
