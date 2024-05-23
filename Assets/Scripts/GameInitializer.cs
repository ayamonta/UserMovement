using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // REMEMBRE TO ATTACH TO MAIN CAMERA!!!!!!!!!!!!!!!!!
        ScreenUtils.Initialize();
    }
}
