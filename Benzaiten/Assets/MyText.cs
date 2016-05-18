using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class MyText : MonoBehaviour
{
	private Image characterImage;
	private float letterPause = 0.03f;
	public bool typing = false;

	public Sprite benzaitenPortrait;
	public Sprite kenjiPortrait;


	public List<GameObject> uiGameobjects;
	string message;
	private Text textComp;

	private Color invisible;
	private Color visble;
	// Use this for initialization
	void Start ()
	{
		foreach (Transform child in transform.parent)
		{
			if (child.name == "Character")
			{
				characterImage = child.GetComponent <Image> ();
			}
		}
		invisible = new Color (1, 1, 1, 0);
		textComp = GetComponent<Text> ();
		message = "Ik ben Ben-Ben-Ben... Ik Stotter hihihi. Ik ben Ben-Ben-Benzaiten. Ik zeg altijd YOLO. Dat betekend; Your Octopus Likes Owls.";
		textComp.text = "";
		//StartCoroutine (TypeText ());
		foreach (GameObject uiObject in uiGameobjects)
		{

			uiObject.SetActive (false);
			textComp.color = invisible;
		}
	}



	void Update ()
	{
		if (typing == false)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				TypeLine ("I love you my love", this.gameObject);
			}
		}
	}

	IEnumerator TypeText ()
	{
//		characterImage = kenjiPortrait;
		foreach (GameObject uiObject in uiGameobjects)
		{
			Color visible = new Color (0, 0, 0, 1);
			uiObject.SetActive (true);
			textComp.color = visible;
		}

		foreach (char letter in message.ToCharArray())
		{
			typing = true;
			textComp.text += letter;
			//sound of character
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}
		typing = false;

		yield return new WaitForSeconds (4);

		foreach (GameObject uiObject in uiGameobjects)
		{
			
			uiObject.SetActive (false);
			textComp.color = invisible;
		}
	}


	void TypeLine (string textToType, GameObject character)
	{
		textComp.text = "";
		message = textToType;
		StartCoroutine (TypeText ());
	}


}