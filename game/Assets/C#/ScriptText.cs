using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class ScriptText : MonoBehaviour
{
    story diologue;

    // Start is called before the first frame update
    void Start()
    {
        diologue = story.instance;
    }

    public string[] s = new string[]
    {
        "我想去見上帝，你可以幫幫我嗎?:結月ゆかり",
        "我已經有二十四小時以上還沒睡覺了.....",
        "你天殺的還給我出BUG!?!?"
    };

    int index = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!diologue.isSpeaking || diologue.isWaitingForUserInput)
            {
                if(index >= s.Length)
                {
                    return;
                }

                Say(s[index]);
                index ++;
            }
        }
    }
    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        diologue.Say(speech ,true ,speaker);
    }
}*/
