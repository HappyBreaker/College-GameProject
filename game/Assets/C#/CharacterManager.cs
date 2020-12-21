using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour 
{
	public static CharacterManager instance;

	//All characters must be attached to the character panel
	//所有角色必須連接到角色面板
	public RectTransform characterPanel;

	//a list of all charaters currently in our scene.
	//當前畫面所有角色的清單
	public List<Character> characters = new List<Character>();


	//easy lookup for our charaters.

	public Dictionary<string, int> characterDictionary  = new Dictionary<string, int>();
		
	void Awaken()
	{
		instance = this;
	}

	//try to get a charater by the name provided from the charater list.
	//用角色名子抓取角色清單中的角色
	//<param name="haratersName">Charater name.</param>

	public Character GetCharacter(string characterName,bool createCharacterIfDoesNotExist = true, bool enableCreatedCharacterOnStart= true)
	{
		//search our dictionary to find the charater quickly if it is already in our scren
		//從字典快速找出要用的角色
		int index = -1;
		if (characterDictionary.TryGetValue (characterName, out index))
		{
			return characters [index];
		} 
		else if (createCharacterIfDoesNotExist)
		{
			return CreateCharacter (characterName,enableCreatedCharacterOnStart);
		}

		return null;
			
	}

	public Character CreateCharacter(string characterName, bool enableOnStart = true)
	{
		Character newCharacter = new Character (characterName, enableOnStart);
		characterDictionary.Add (characterName, characters.Count);
		characters.Add (newCharacter);

		return newCharacter;

	}

}
//2646