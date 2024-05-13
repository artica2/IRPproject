using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLMUnity;

public class LLMreader : MonoBehaviour
{
    public LLM llm;

    void HandleReply(string reply)
    {
        Debug.Log("Handling reply!");
        Debug.Log("reply is " + reply);
    }

    void ReplyCompleted()
    {
        Debug.Log("AI finished Replying");
    }
    // Start is called before the first frame update
    private void Start()
    {

    }

    public void OnClick()
    {

        string message = "Hello! I would like you to dance and then move to the target please!";
        _ = llm.Chat(message, HandleReply, ReplyCompleted);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
