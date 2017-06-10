using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CzujnikNew : MonoBehaviour
{

    public static int rezultatKrencenia;
    public static bool czyMoznaSczytywac { set; get; }

    public LayerMask Tysioc;
    public LayerMask Sto;
    public LayerMask Trzysta;
    public LayerMask Dziewiencset;
    public LayerMask StrataZycia;
    public LayerMask TysiocPiencset;
    public LayerMask Szsczset;
    public LayerMask Piencset;
    public LayerMask Siedemset;
    public LayerMask Bankrot;

    public Transform Czujnik;
    public float radius = 0.1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Rorate.juzPokrencono)
        {

            if (Physics2D.OverlapCircle(Czujnik.position, radius, Tysioc))
            {
                rezultatKrencenia = 1000;
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, Sto))
            {
                rezultatKrencenia = 100;
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, Trzysta))
            {
                rezultatKrencenia = 300;
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, Dziewiencset))
            {
                rezultatKrencenia = 900;
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, StrataZycia))
            {
                rezultatKrencenia = -1; //Strata życia
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, TysiocPiencset))
            {
                rezultatKrencenia = 1500;
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, Szsczset))
            {
                rezultatKrencenia = 600;
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, Piencset))
            {
                rezultatKrencenia = 500;
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, Siedemset))
            {
                rezultatKrencenia = 700;
                czyMoznaSczytywac = true;
            }
            else if (Physics2D.OverlapCircle(Czujnik.position, radius, Bankrot))
            {
                rezultatKrencenia = -1000;
                czyMoznaSczytywac = true;
            }

        }
    }
}
