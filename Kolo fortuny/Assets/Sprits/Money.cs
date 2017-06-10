using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public int money,tmp, counter;
    public GameObject life;
    public GameObject MoneySchore;

    public GameObject btnPodania;
    public GameObject wynikTekst;
    public GameObject pole;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (counter == 1)
        {
            CzujnikNew.czyMoznaSczytywac = false;
            counter = 0;
        }

        if (CzujnikNew.czyMoznaSczytywac && counter == 0)
        {
            tmp = CzujnikNew.rezultatKrencenia;
            if (tmp > 0)
            {
                money += tmp;
                MoneySchore.GetComponent<Text>().text = money.ToString();
                counter++;
            }
            else if (tmp == -1)
            {
                int tempLife = Int32.Parse(life.GetComponent<Text>().text);
                tempLife--;
                if (tempLife == 0)
                {
                    life.GetComponent<Text>().text = "" + 0;
                    wynikTekst.GetComponent<Text>().text = "Przegrałeś";
                    Pytanie.odpowiedziUżytkownika = Pytanie.odpowiedz;
                    Status.czyWolnoWyswietlic = true;
                    btnPodania.SetActive(false);
                    pole.SetActive(false);

                }
                else
                {
                    life.GetComponent<Text>().text = tempLife.ToString();
                    counter++;
                }

            }
            else if (tmp == -1000)
            {
                money = 0;
                MoneySchore.GetComponent<Text>().text = money.ToString();
                counter++;
            }

        }
	}
}
