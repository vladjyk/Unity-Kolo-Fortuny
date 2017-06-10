using UnityEngine;
using UnityEngine.UI;

public class Rorate : MonoBehaviour {
    public GameObject kolo, BtnPytania, Pole, BtnKrencenia, TekstPola, wynikTekst;
    public bool isClick = false, isStop = true;
    public int count, tmp, countGlobal;
    public static bool juzPokrencono, juzDanaOdpowiedz = true;
 
   void Start(){
        int a;
        if (Random.Range(1,11)%2 == 0){
            a = 1;
        }
        else a = -1;
        tmp = (360 + Random.Range(0,7)*30*a);
   }

	void FixedUpdate ()
    {
        juzPokrencono = false; 

         if (isClick && count != tmp&& juzDanaOdpowiedz){
            count ++;        
            kolo.transform.rotation *= Quaternion.Euler(0, 0, 5);
         }
         else if (count == tmp){
            BtnPytania.SetActive(true);
            Pole.SetActive(true);
            BtnKrencenia.SetActive(false);
            juzDanaOdpowiedz = false;

            isClick = false;
            isStop = true;
            count = 0;
            
            int a;
            if (Random.Range(1,11)%2 == 0){
                a = 1;
            }
            else a = -1;
            tmp = (360 + Random.Range(0,7)*30*a);

            countGlobal++;
            juzPokrencono = true;
        }
    }

    public void OnClick()
    {
        if(isStop)
        {
            wynikTekst.SetActive(false);
            juzPokrencono = false;
            isClick = true;
        }
    }
}
