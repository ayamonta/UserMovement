using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUtils : MonoBehaviour
{
	#region Fields
	
	// saved to support resolution changes
	static int screenWidth;
	static int screenHeight;
	
	// world coordinates
	// cached for efficient boundary checking
	static float screenLeft;
	static float screenRight;
	static float screenTop;
	static float screenBot;

    #endregion Fields

    public static float ScreenLeft{
		get { return screenLeft; }
	}

    public static float ScreenRight{
		get { return screenRight; }
	}

    public static float ScreenTop{
		get { return screenTop; }
	}

    public static float ScreenBot{
		get { return screenBot; }
	}
	
	public static void Initialize(){
		// put Initialize in Ball object (whatever new object that needs bounds)
        float screenZ = -Camera.main.transform.position.z;
        
        Vector3 botLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 botLeftCornerWorld = Camera.main.ScreenToWorldPoint(botLeftCornerScreen);

        Vector3 topRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 topRightCornerWorld = Camera.main.ScreenToWorldPoint(topRightCornerScreen);

        screenLeft = botLeftCornerWorld.x;
        screenRight = topRightCornerWorld.x;
        screenTop = topRightCornerWorld.y;
        screenBot = botLeftCornerWorld.y;
		
	}

	// find location in world coordinate
	public static Vector3 CursorLocation()
	{
        Vector3 mousePos = Input.mousePosition;
		mousePos.z = -Camera.main.transform.position.z;
		return Camera.main.ScreenToWorldPoint(mousePos);
	}

	public static bool WithinBoundary()
	{
		return (CursorLocation().x > screenLeft && 
				CursorLocation().x < screenRight && 
				CursorLocation().y > screenBot && 
				CursorLocation().y < screenTop);
	}


}
