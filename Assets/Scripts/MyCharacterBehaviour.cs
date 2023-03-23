using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyCharacterBehaviour : MonoBehaviour
{
    public GameObject chatCanvas;
    bool onChatActive = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && onChatActive)  {
            GetComponent<PlayerInput>().enabled = true;
            chatCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        chatCanvas.SetActive(true);
        GetComponent<PlayerInput>().enabled = false;
        onChatActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
