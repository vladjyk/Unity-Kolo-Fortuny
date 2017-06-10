using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Podac : MonoBehaviour {

    public GameObject PodacBTN;
    public GameObject BtnKrencenia;
    public GameObject Pole;
    public GameObject TextPola;
    public GameObject pytanie;

    public string strOdpowiedz;
    void Start () {
        PodacBTN.SetActive(false);
        Pole.SetActive(false);
	}
	
	void Update () {
		
	}

    public void Click()
    {
        strOdpowiedz = TextPola.GetComponent<Text>().text;
        strOdpowiedz = strOdpowiedz.ToUpper();
        PodacBTN.SetActive(false);
        Pole.GetComponent<InputField>().text = "";
        Pole.SetActive(false);
        BtnKrencenia.SetActive(true);
        Rorate.juzDanaOdpowiedz = true;
        if (strOdpowiedz.Length == 1)
        {
            char[] tempLocal = strOdpowiedz.ToCharArray();
            pytanie.GetComponent<Pytanie>().sprawdzenie(tempLocal[0]);
        }

        else
        {
            pytanie.GetComponent<Pytanie>().sprawdzenie(strOdpowiedz);
            
        }
        

    }
}
