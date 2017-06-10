using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour {

    public GameObject prefabButton;
    public RectTransform ParentPanel;
    private GameObject[] litery;
    bool switchWay = true;
    public static bool czyWolnoWyswietlic { set; get; }

    // Use this for initialization
    void Start () {
        czyWolnoWyswietlic = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (switchWay)
        {
            int count = 0;
            litery = new GameObject[Pytanie.iloscLiterWSlowie];
            for (int i = 0; i < litery.Length; i++)
            {
                if (count == 0)
                {
                    float tempLocal = (float) litery.Length;
                    tempLocal /= 2;
                    tempLocal *= 130;
                    tempLocal -= 75;
                    litery[i] = (GameObject)Instantiate(prefabButton, new Vector2(-tempLocal, 226), Quaternion.identity);
                    count++;
                }
                else
                {
                    float vecTmp = litery[i - 1].transform.localPosition.x;
                    litery[i] = (GameObject)Instantiate(prefabButton, new Vector2(vecTmp + 130, 226), Quaternion.identity);
                }

                litery[i].transform.SetParent(ParentPanel, false);
            }
            switchWay = false;
        }

        if (czyWolnoWyswietlic)
        {
            char[] literyUzytkownika = Pytanie.odpowiedziUżytkownika;
            for (int i = 0; i < literyUzytkownika.Length; i++)
            {
                if (literyUzytkownika[i] != '-')
                {
                    litery[i].GetComponentInChildren<Text>().text = "" + literyUzytkownika[i];
                }
            }
            czyWolnoWyswietlic = false;
        }
    }
}
