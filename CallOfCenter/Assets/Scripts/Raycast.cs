using UnityEngine;

public class Raycast : MonoBehaviour
{

    public float ray_l = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Vector3 rayOrigin = transform.position;

        if (Physics.Raycast(rayOrigin,transform.forward, out hit,ray_l))
        {
            Transform objectHit = hit.transform;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(objectHit.gameObject.tag + "Hello");
                // Debug.Log("!Е натиснуто!");
                if(objectHit.gameObject.CompareTag("Notebook"))
                {
                    Debug.Log("Notebook clicked");
                    if(LaptopScript.Laptop_close) LaptopScript.Open();
                    
                }
                else if(objectHit.gameObject.CompareTag("Door"))
                {
                    if(DoorScript.Door_closed == true)
                    {
                        DoorScript.Open();
                    }
                    else
                    {
                        DoorScript.Close();
                    }
                }
            }
        }
    }
}
