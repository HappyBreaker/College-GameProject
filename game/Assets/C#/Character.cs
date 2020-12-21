using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Character
{

	public string characterName;


	//The root
	[HideInInspector]public RectTransform root;

	public bool isMultiLayerCharacter{ get { return renderers.renderer == null; } }

	public bool enabled { get { return root.gameObject.activeInHierarchy; } set { root.gameObject.SetActive (value); } }

	story dialogue;

	public void Say(string speech,bool add = false)
	{
		if (!enabled)
			enabled = true;
		if (!add)
			dialogue.Say(speech, characterName);
		else
			dialogue.SayAdd(speech, characterName);
	}

	//Create a new charater
	//<param name="_name">Name.</param>

	public Character (string _name, bool enabledOnStart = true)
	{
		CharacterManager cm = CharacterManager.instance;
		//locate the character prefab
		//鎖定角色組件
		GameObject prefab = Resources.Load("Characters/Character["+_name+"]") as GameObject;
		//spawn an instance of the prefab directly on the character panel
		//立即在角色面板上產生角色組件組合結果
		GameObject ob = GameObject.Instantiate(prefab, cm.characterPanel);
		
		root = ob.GetComponent<RectTransform> ();
		characterName = _name;

		renderers.renderer = ob.GetComponentInChildren<RawImage> ();
		if (isMultiLayerCharacter)
		{
			renderers.bodyRenderer = ob.transform.Find ("bodyLayer").GetComponent<Image> ();
			renderers.expressionRenderer = ob.transform.Find("expressionlayer").GetComponent<Image>();
		}

		dialogue = story.instance;
		//Get Rebderer(s)
		enabled = enabledOnStart;


	}


	[System.Serializable]
	public class Renderers
	{
		//used as only image for a single layer character
		public RawImage renderer;

		//sprites use images
		//the body renderer for a multi layer character
		public Image bodyRenderer;
		//the expression randerer for multi layer character
		public Image expressionRenderer;
	}

	public Renderers renderers = new Renderers();
}
