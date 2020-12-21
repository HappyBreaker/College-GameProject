using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class story : MonoBehaviour
{
    public static story instance;

    public ELEMENTS elements;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    //Say something and show it on the speech box.
    public void Say(string speech, string speaker = "")
    {
        StopSpeaking();

        speechText.text = targetSpeech;

        speaking = StartCoroutine(Speaking(speech, false, speaker));
    }
    public void SayAdd(string speech, string speaker = "")
    {
        StopSpeaking();

        speechText.text = targetSpeech;

        speaking = StartCoroutine(Speaking(speech, true, speaker));
    }
    //say someting to be added to what is already on the speech box
    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }
    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector] public bool isWaitingForUserInput = false;

    string targetSpeech = "";
    Coroutine speaking = null;
    IEnumerator Speaking(string speech,bool additive,string speaker = "")
    {
        PannelSpeech.SetActive(true);
        targetSpeech = speech;

        if (!additive)
            speechText.text = "";
        else
            targetSpeech = speechText.text + targetSpeech;

        speakerNameText.text = DetermineSpeaker(speaker);//temporary(臨時)
        isWaitingForUserInput = false;

        while (speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length-1];
            yield return new WaitForEndOfFrame();
        }

        //text finished
        isWaitingForUserInput = true;
        while (isWaitingForUserInput)
            yield return new WaitForEndOfFrame();

        StopSpeaking();
    }

    string DetermineSpeaker(string s)
    {
        string retVal = speakerNameText.text;
        if (s != speakerNameText.text && s != "")
            retVal = (s.ToLower().Contains("narrator")) ? "" : s;

        return retVal;
    }

	//close the entire speech panel.Stop all dialogue.
	public void Close()
	{
		StopSpeaking ();
		PannelSpeech.SetActive (false);
	}

    [System.Serializable]
    public class ELEMENTS
    {
        //The main panel containing all dialogue related elements on the UI
        //主要面板包含所有對話有關元素在這UI設定

        public GameObject PannelSpeech;
        public Text speakerNameText;
        public Text speechText;
    }
    public GameObject PannelSpeech { get { return elements.PannelSpeech; } }
    public Text speakerNameText { get { return elements.speakerNameText; } }
    public Text speechText { get { return elements.speechText; } }
}
