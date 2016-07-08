using UnityEngine;
using UnityEngine.UI;
using System.Collections;



//Background colours
public enum BackColor
{
    Happy,
    Depressed,
    Anxious,
    Calm
}

public class BackgroundColor : MonoBehaviour {

	 Color temp;

    public Image background;

	public bool happyTrue;
	public bool calmTrue;
	public bool sadTrue;
	public bool anxiousTrue;


    public void changeColour(BackColor BC)
    {
        switch(BC)
        {
		case BackColor.Calm:
			temp  = new Vector4 (131.0f / 255.0f,
				197f / 255.0f,
				210f / 255.0f,
				255 / 255.0f);
                break;

            case BackColor.Anxious:

			temp = new Vector4      (
				39f / 255.0f,
				5f / 255.0f,
				5f / 255.0f,
				255 / 255.0f
			);	
                break;

		case BackColor.Depressed:
			temp = new Vector4 (
				10f / 255.0f,
				10f / 255.0f,
				50f / 255.0f,
				255 / 255.0f
			);
                break;

            case BackColor.Happy:
			temp = new Vector4
                    (
                    145f / 255.0f,
                    184f / 255.0f,
                    82f / 255.0f,
                    255 / 255.0f
                    );
                break;

            default:
			background.color = new Vector4(0, 0, 0, 0.1f);
                break;
        }
    }

	// Use this for initialization
	void Start () {
       // changeColour(BackColor.Calm);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (background.color != temp) { 
			background.color = Vector4.Lerp (background.color, temp, 0.01f);
		}









	}
}
