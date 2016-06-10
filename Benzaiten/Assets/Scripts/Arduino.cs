using UnityEngine;
using System.Collections;
using System.IO.Ports;

using System.Collections.Generic;

public class Arduino : MonoBehaviour
{
	private FluteMode thisFluteScript;
	public float speed;
	private float amountToMove;
	SerialPort sp = new SerialPort ("/dev/cu.wchusbserial1410", 9600);

	byte low;
	byte high;
	public bool arduinoButtonCheck;

	public List<string> bufferList = new List<string> ();

	public static Arduino instance;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		} else
		{
			Debug.LogError ("instance already exists");
		}

	}


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

				/*
				if(bufferList[bufferList.Count-1] != b.ToString())
				{
					bufferList.Add(b.ToString());
				}
				*/
				//Debug.Log ((b & 0x80) >> 7);
				updateButtons ();

			} catch (System.Exception)
			{
				
			}

		}
	}

	void updateButtons ()
	{
		// NOTEN
		if ((low & 0x01) == 1)
		{
			thisFluteScript.Arduino1pressed = true;
			if (thisFluteScript.Arduino1buffer != thisFluteScript.Arduino1pressed)
			{
				thisFluteScript.Arduino1buffer = true;
			} else
			{
				thisFluteScript.Arduino1buffer = false;
			}
		} else
		{
			thisFluteScript.Arduino1pressed = false;
			thisFluteScript.Arduino1buffer = false;
			//		TryAddInput ("roze false");
		}
		if (((low & 0x02) >> 1) == 1)
		{
			thisFluteScript.Arduino2pressed = true;
			if (thisFluteScript.Arduino2buffer != thisFluteScript.Arduino2pressed)
			{
				thisFluteScript.Arduino2buffer = true;
			} else
			{
				thisFluteScript.Arduino2buffer = false;
			}
		} else
		{
			thisFluteScript.Arduino2pressed = false;
			thisFluteScript.Arduino2buffer = false;
			//		TryAddInput ("blauw false");
		}
		if (((low & 0x04) >> 2) == 1)
		{
			thisFluteScript.Arduino3pressed = true;
			if (thisFluteScript.Arduino3buffer != thisFluteScript.Arduino3pressed)
			{
				thisFluteScript.Arduino3buffer = true;
			} else
			{
				thisFluteScript.Arduino3buffer = false;
			}
		} else
		{
			thisFluteScript.Arduino3pressed = false;
			thisFluteScript.Arduino3buffer = false;
			//		TryAddInput ("groen false");
		}
		if (((low & 0x08) >> 3) == 1)
		{
			thisFluteScript.Arduino4pressed = true;
			if (thisFluteScript.Arduino4buffer != thisFluteScript.Arduino4pressed)
			{
				thisFluteScript.Arduino4buffer = true;
			} else
			{
				thisFluteScript.Arduino4buffer = false;
			}
		} else
		{
			thisFluteScript.Arduino4pressed = false;
			thisFluteScript.Arduino4buffer = false;
			//		TryAddInput ("geel false");
		}
		if (((low & 0x16) >> 4) == 1)
		{
			thisFluteScript.Arduino5pressed = true;
			if (thisFluteScript.Arduino5buffer != thisFluteScript.Arduino5pressed)
			{
				thisFluteScript.Arduino5buffer = true;
			} else
			{
				thisFluteScript.Arduino5buffer = false;
			}
		} else
		{
			thisFluteScript.Arduino5pressed = false;
			thisFluteScript.Arduino5buffer = false;
			//		TryAddInput ("rood false");
		}


		// WALK BUTTON
		if ((high & 0x01) == 1)
		{
			thisFluteScript.Arduino6pressed = true;
			arduinoButtonCheck = true;
			if (thisFluteScript.Arduino6buffer != thisFluteScript.Arduino6pressed)
			{
				thisFluteScript.Arduino6buffer = true;
			} else
			{
				arduinoButtonCheck = false;
				
				thisFluteScript.Arduino6buffer = false;
			}
		} else
		{
			thisFluteScript.Arduino6pressed = false;
			thisFluteScript.Arduino6buffer = false;
			//		TryAddInput ("down false");
		}
		if (((high & 0x02) >> 1) == 1)
		{
			thisFluteScript.Arduino7pressed = true;
			arduinoButtonCheck = true;
			if (thisFluteScript.Arduino7buffer != thisFluteScript.Arduino7pressed)
			{
				thisFluteScript.Arduino7buffer = true;
			} else
			{
				thisFluteScript.Arduino7buffer = false;
			}
		} else
		{
			arduinoButtonCheck = false;
			
			thisFluteScript.Arduino7pressed = false;
			thisFluteScript.Arduino7buffer = false;
			//		TryAddInput ("right false");
		}
		if (((high & 0x04) >> 2) == 1)
		{
			thisFluteScript.Arduino8pressed = true;
			arduinoButtonCheck = true;
			if (thisFluteScript.Arduino8buffer != thisFluteScript.Arduino8pressed)
			{
				thisFluteScript.Arduino8buffer = true;
			} else
			{
				arduinoButtonCheck = false;
				
				thisFluteScript.Arduino8buffer = false;
			}
		} else
		{
			thisFluteScript.Arduino8pressed = false;
			thisFluteScript.Arduino8buffer = false;
			//		TryAddInput ("left false");
		}
		if (((high & 0x08) >> 3) == 1)
		{
			
			thisFluteScript.Arduino9pressed = true;
			arduinoButtonCheck = true;
			if (thisFluteScript.Arduino9buffer != thisFluteScript.Arduino9pressed)
			{
				thisFluteScript.Arduino9buffer = true;
			} else
			{
				arduinoButtonCheck = false;
				
				thisFluteScript.Arduino9buffer = false;
			}

		} else
		{
			thisFluteScript.Arduino9pressed = false;
			thisFluteScript.Arduino9buffer = false;
			//		TryAddInput ("up false");
		}

	}


}
