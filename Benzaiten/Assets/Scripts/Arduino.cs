using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arduino : MonoBehaviour
{
	private FluteMode thisFluteScript;
	public float speed;
	private float amountToMove;
	SerialPort sp = new SerialPort ("/dev/cu.wchusbserial1410", 9600);

	byte low;
	byte high;

	// Use this for initialization
	void Start ()
	{
		thisFluteScript = GetComponent <FluteMode> ();
		sp.Open ();
		sp.ReadTimeout = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		amountToMove = speed * Time.deltaTime;

		if (sp.IsOpen)
		{
			try
			{
//				MoveObject (sp.ReadByte ());
//				print (sp.ReadByte ());
				byte b = (byte)sp.ReadByte ();
				//check of ie high of low is
				if (((b & 0x80) >> 7) == 1) //als de 8e bit 1 is
					high = b;
				else
					low = b;

				//Debug.Log ((b & 0x80) >> 7);
				updateButtons ();

			} catch (System.Exception)
			{
				
			}

		}
	}

	void updateButtons ()
	{

//		if (Button == 1)
//		{
//			thisFluteScript.Arduino1pressed = true;
//
//		} else if (Button == 2)
//		{
//			thisFluteScript.Arduino2pressed = true;
//		} else if (Button == 30)
//		{
//			thisFluteScript.Arduino1pressed = false;
//			thisFluteScript.Arduino2pressed = false;
//		}

		if ((low & 0x01) == 1)
			thisFluteScript.Arduino1pressed = true;
		else
			thisFluteScript.Arduino1pressed = false;

		if (((low & 0x02) >> 1) == 1)
			thisFluteScript.Arduino2pressed = true;
		else
			thisFluteScript.Arduino2pressed = false;

		if (((low & 0x04) >> 2) == 1)
			thisFluteScript.Arduino3pressed = true;
		else
			thisFluteScript.Arduino3pressed = false;

		if (((low & 0x08) >> 3) == 1)
			thisFluteScript.Arduino4pressed = true;
		else
			thisFluteScript.Arduino4pressed = false;
	}
}
