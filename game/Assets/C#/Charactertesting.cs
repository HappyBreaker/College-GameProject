using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactertesting : MonoBehaviour 
{
	public Character Raelin;


	void Start () 
	{
		Raelin = CharacterManager.instance.GetCharacter("Raelin", enableCreatedCharacterOnStart: false);
	}
	public string[] speech;
	int i = 0;

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (i < speech.Length)
				Raelin.Say (speech [i]);
			else
				story.instance.Close ();
			
			i++;
		}
	}
}
//2526