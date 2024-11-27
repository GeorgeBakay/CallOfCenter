using System.Collections.Generic;
using UnityEngine;

public class LaptopScript : MonoBehaviour
{
    
    public PlayerScript _player;
    public bool notebook_open = false;
    public void Open(){
        if(!notebook_open){
            notebook_open = true;
            _player.OpenConsole();
        }
        else{
            notebook_open = false;
        }
        
    }
    
}
