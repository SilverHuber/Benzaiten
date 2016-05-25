using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class MyText : MonoBehaviour
{
	private Image characterImage;
	private float letterPause = 0.03f;
	public bool typing = false;

	public Image portrait;

	public Sprite benzaitenPortrait;
	public Sprite kenjiPortrait;
	public Sprite femArchPortrait;
	public Sprite maleArchPortrait;


	public List<GameObject> uiGameobjects;
	string message;
	private Text textComponent;

	private Color invisible;
	private Color visble;




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
	}


	void Update ()
	{
		if (typing == false)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				TypeLine ("I love you my love", "Kenji");
			}

			if (Input.GetKeyDown (KeyCode.V))
			{
				TypeLine ("Data is corrupted", "FemaleArch");
			}

			if (Input.GetKeyDown (KeyCode.C))
			{
				TypeLine ("OMG... The bridge is kapot... What nu?", "MaleArch");
			}
		}
	}

	IEnumerator TypeText ()
	{

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
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}
		typing = false;

		yield return new WaitForSeconds (4);

		foreach (GameObject uiObject in uiGameobjects)
		{
			
			uiObject.SetActive (false);
			textComponent.color = invisible;
		}

	}

	/// <summary>
	/// Types the line.
	/// </summary>
	/// <param name="textToType">Text to type.</param>
	/// <param name="character">Name of the Character.</param>
	public void TypeLine (string textToType, string character)
	{
		if (character == "Kenji")
		{
			portrait.sprite = kenjiPortrait;
		}
		if (character == "FemaleArch")
		{
			portrait.sprite = femArchPortrait;
		}
		if (character == "MaleArch")
		{
			portrait.sprite = maleArchPortrait;
		}

		textComponent.text = "";
		message = textToType;
		portrait.SetNativeSize ();
		StartCoroutine (TypeText ());
	}


}