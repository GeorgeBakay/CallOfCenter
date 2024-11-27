using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static Canvas _canvas;
    public static Controller _controller;
    private bool is_laptop_close = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _canvas = GetComponentInChildren<Canvas>();
        _controller = GetComponentInChildren<Controller>();
        _canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_laptop_close == false)
        {
            Debug.Log("Close console");
            CloseConsole();
        }

    }
    public void OpenConsole()
    {
        if (is_laptop_close)
        {
            _controller.canMove = false;
            is_laptop_close = false;
            _canvas.enabled = true;
        }

    }
    public void CloseConsole()
    {
        _controller.canMove = true;
        is_laptop_close = true;
        _canvas.enabled = false;
    }
}
