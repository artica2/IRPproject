using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LLMUnity;
using TMPro;

public class LLMreader : MonoBehaviour
{
    public LLM llm; // the large language model
    public string replyToProcess; // the reply to be sent to the tree builder script
    public TMP_InputField input;

    void HandleReply(string reply)
    {
        replyToProcess = reply; // load the reply to the replytoprocess string
    }

    void ReplyCompleted()
    {
        Debug.Log("Reply is: " + replyToProcess);
        // once complete, send the reply to the tree builder script
        TreeBuilder.instance.stringToProcess = replyToProcess;
        TreeBuilder.instance.inputToProcess = true;
    }

    public void OnClick()
    {
        string messageTest = input.text; // get instructions from the input field
        _ = llm.Chat(messageTest, HandleReply, ReplyCompleted); // chat with the llm
    }
}
