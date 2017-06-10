using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Pytanie : MonoBehaviour {
    public static int iloscLiterWSlowie;
    public string pytanie;
    public static char[] odpowiedz { set; get; }
    public static char[] odpowiedziUżytkownika { set; get; }

    public  GameObject wynikTekst;
    public GameObject life;

    public GameObject btnKrenc;



    void Start() {
        string[] pytania = { "Język programowania niskiego poziomu", "Nazwa popularnego antywirusa", "Nazwa interfejsu podłącznia twardego dysku w komputerach serwerowych", "Najmniejszy element obrazu wyświetlanego na ekranie", "Nazwa standardowego edytora obrazu dla systemu Windows", "Rząd klawiszy używany do pisania", "Materiał z którego zrobiony procesor", "Cytrusowy drzewo z pachnących kwiatów", "Ten ptak może latać tyłem do przodu", "Wiedząc to, możemy zrozumieć, jak działa urządzenie" , "Jedyne jadowite ssaki na świecie" };
        string[] odpowiedzi = { "ASSEMBLER", "AVAST", "SCSI", "PIKSEL", "PAINT", "KŁAWIATURA", "KRZEM", "BERGAMOTKA", "KOLIBER", "STRUKTURA", "DZIOBAK" };

        int tmp = UnityEngine.Random.Range(0, pytania.Length);

        pytanie = pytania[tmp];
        odpowiedz = odpowiedzi[tmp].ToCharArray();
        iloscLiterWSlowie = odpowiedz.Length;
        GetComponent<Text>().text = pytanie;
        odpowiedziUżytkownika = new char[iloscLiterWSlowie];
        for (int i = 0; i < iloscLiterWSlowie; i++)
        {
            odpowiedziUżytkownika[i] = '-';
        }

        wynikTekst.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }
    public void sprawdzenie(char litera) {
        int count = 0;
        wynikTekst.SetActive(true);
        for (int i = 0; i < odpowiedz.Length; i++)
        {
            if (odpowiedz[i] == litera)
            {
                if (odpowiedziUżytkownika[i] == odpowiedz[i])
                {
                    count = -1;
                }
                else
                {
                    count++;
                    odpowiedziUżytkownika[i] = odpowiedz[i];
                }
            }         
        }

        if (czyKoniec())
        {
            wynikTekst.GetComponent<Text>().text = "Zgadłeś całe słowo";
            btnKrenc.SetActive(false);
            Status.czyWolnoWyswietlic = true;
        }

        else
        {
            if (count == 1)
            {
                wynikTekst.GetComponent<Text>().text = "Zgadłeś 1 litere";
                Status.czyWolnoWyswietlic = true;
            }
            else if (count > 1)
            {
                wynikTekst.GetComponent<Text>().text = "Zgadłeś " + count + " litery";
                Status.czyWolnoWyswietlic = true;
            }
            else if (count == 0)
            {
                int tempLife = Int32.Parse(life.GetComponent<Text>().text);
                tempLife--;

                if (tempLife == 0)
                {
                    wynikTekst.GetComponent<Text>().text = "Przegrałeś";
                    odpowiedziUżytkownika = odpowiedz;
                    Status.czyWolnoWyswietlic = true;
                    btnKrenc.SetActive(false);
                }

                else
                {
                    wynikTekst.GetComponent<Text>().text = "W tym słowie nie ma takiej litery";
                }
                life.GetComponent<Text>().text = tempLife.ToString();
            }
            else
            {     
                int tempLife = Int32.Parse(life.GetComponent<Text>().text);
                tempLife--;
                if (tempLife == 0)
                {
                    wynikTekst.GetComponent<Text>().text = "Przegrałeś";
                    btnKrenc.SetActive(false);
                    odpowiedziUżytkownika = odpowiedz;
                }

                else
                {
                    wynikTekst.GetComponent<Text>().text = "Już podawałeś tą litere";
                }
                life.GetComponent<Text>().text = tempLife.ToString();
            }
        }
    }

    public void sprawdzenie (string slowo)
    {
        wynikTekst.SetActive(true);
        string strTemp = "";

        foreach(char i in odpowiedz)
        {
            strTemp += ""+ i;
        }

        if (slowo.Equals(strTemp))
        {
            wynikTekst.GetComponent<Text>().text = "Zgadłeś całe słowo";
            odpowiedziUżytkownika = odpowiedz;
            Status.czyWolnoWyswietlic = true;
            btnKrenc.SetActive(false);
        }
        else
        {
            wynikTekst.GetComponent<Text>().text = "Przegrałeś";
            odpowiedziUżytkownika = odpowiedz;
            Status.czyWolnoWyswietlic = true;
            btnKrenc.SetActive(false);
            life.GetComponent<Text>().text = "" + 0;
        }

    }

    private static bool czyKoniec(){
        bool result = false;
        int countLocal = 0;
        foreach (char i in odpowiedziUżytkownika)
        {
            if (i != '-')
                countLocal++;
        }

        if (countLocal == odpowiedziUżytkownika.Length)
        {
            result = true;
        }

        return result;
    }
}
