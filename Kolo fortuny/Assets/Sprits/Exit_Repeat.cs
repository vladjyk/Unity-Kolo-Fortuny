using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Repeat : MonoBehaviour {

	public void Click_Exit()
    {
        Application.Quit();
    }

    public void Click_Repeat()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
