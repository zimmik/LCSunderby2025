using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    string text = "Hello world!";
    [SerializeField] string myName = "Tom";
    public string myHomeTown = "Piteå";

    // Start is called before the first frame update
    void Start()
    {
        //print(text);
        print("Hello world");
        Debug.Log(text); //Unity Debug Only
    }

    // Update is called once per frame
    void Update()
    {

    }
}
