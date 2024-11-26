using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public static MeshRenderer door_mesh;

    public static BoxCollider door_coll;
    public static bool Door_closed = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //var r = transform.rotation;
        door_coll = GetComponent<BoxCollider>();
        door_mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Open()   
    {
        door_coll.isTrigger = true;
        door_mesh.enabled = false;
        Debug.Log("Двері відкрито");
        Door_closed = false;
    }

    public static void Close()
    {
        door_coll.isTrigger = false;
        door_mesh.enabled = true;
        Debug.Log("Двері закрито");
        Door_closed = true;
    }
}
