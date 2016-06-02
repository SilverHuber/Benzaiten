using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIText
{
	public string characterName;
	public string textToType;

	public UIText (string text, string name)
	{
		characterName = name;
		textToType = text;
	}
}

public class MyText : MonoBehaviour
{
	private Image characterImage;
	private Image background;
	private float letterPause = 0.01f;
	public bool typing = false;

	public Image portrait;

	public Sprite benzaitenPortrait;
	public Sprite kenjiPortrait;
	public Sprite femArchPortrait;
	public Sprite maleArchPortrait;

	public Sprite benzaitenBackground;
	public Sprite kenjiBackground;
	public Sprite femArchBackground;
	public Sprite maleArchBackground;

	public List<GameObject> uiGameobjects;

	string message;
	private Text textComponent;

	private Color invisible;
	private Color visble;

	public List<UIText> textsToType = new List<UIText> ();



	void Awake ()
	{
		foreach (Transform child in transform.parent)
		{
			if (child.name != "Text")
			{
				uiGameobjects.Add (child.gameObject);
			}
			if (child.name == "Character")
			{
				characterImage = child.GetComponent <Image> ();
			}
			if (child.name == "Background")
			{
				background = child.GetComponent <Image> ();
			}
		}
		invisible = new Color (1, 1, 1, 0);
		textComponent = GetComponent<Text> ();
		textComponent.text = "";
		foreach (GameObject uiObject in uiGameobjects)
		{

			uiObject.SetActive (false);
			textComponent.color = invisible;
		}
	}


	void Start ()
	{
		//textsToType.Add (new UIText ("Ik wou dat ik een dolfijn was met augurken als rot toch eens op, hufter", "FemaleArch"));


	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			TypeLine ("i just wanna love you", "FemaleArch");

		if (Input.GetKeyDown (KeyCode.R))
			TypeLine ("inshalallalala", "Kenji");

		if (Input.GetKeyDown (KeyCode.T))
			TypeLine ("kdjfkjdskfjdlfnsdlkfjkldjfkl", "MaleArch");
			
		Debug.Log (textsToType.Count);

		print (textsToType [0]);
	}




	public void TypeLine (string textToType, string character)
	{
		if (typing == true)
		{
			textsToType.Add (new UIText (textToType, character));
		} else
		{

			if (character == "Kenji")
			{
				portrait.sprite = kenjiPortrait;
				background.sprite = kenjiBackground;
			} else if (character == "FemaleArch")
			{
				portrait.sprite = femArchPortrait;
				background.sprite = femArchBackground;

			} else if (character == "MaleArch")
			{
				portrait.sprite = maleArchPortrait;
				background.sprite = maleArchBackground;

			} else
			{
				print ("name not regocnized");
			}

			textComponent.text = "";
			message = textToType;
			portrait.SetNativeSize ();
			StartCoroutine (TypeText (character));
		}
	}

	IEnumerator TypeText (string character)
	{
		bool playCharSound = true;
		foreach (GameObject uiObject in uiGameobjects)
		{
			Color visible = new Color (0, 0, 0, 1);
			uiObject.SetActive (true);
			textComponent.color = visible;
		}

		foreach (char letter in message.ToCharArray())
		{
			typing = true;
			textComponent.text += letter;
			//sound of character
			if (playCharSound)
			{
				MainSoundScript.Instance.PlayTalkSFX (character);
				playCharSound = false;
			} else
			{
				playCharSound = true;
			}
				

			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}


		yield return new WaitForSeconds (4);


		typing = false;
		foreach (GameObject uiObject in uiGameobjects)
		{

			uiObject.SetActive (false);
			textComponent.color = invisible;
		}

		if (textsToType.Count > 0)
		{
			TypeLine (textsToType [0].textToType, textsToType [0].characterName);
			textsToType.RemoveAt (0);
			textsToType.Sort ();
		}


	}

}