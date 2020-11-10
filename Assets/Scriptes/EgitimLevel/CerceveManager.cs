using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CerceveManager : MonoBehaviour
{
   
    private Image cerceveResmi;

    int randomDeger;
    Color color;

    void Start()
    {
        cerceveResmi = GetComponent<Image>();
        RengiDegistir();
    }

    void RengiDegistir()
    {
        randomDeger = Random.Range(0, 50);

        if (randomDeger <= 10)
        {
            color = Color.blue;
        }
        else if (randomDeger <= 20)
        {
            color = Color.magenta;

        }else if (randomDeger <= 30)
        {
            color = Color.green;

        }else if (randomDeger <= 40)
        {
            color = Color.red;

        }else if (randomDeger <= 50)
        {
            color = Color.yellow;
        }
        if (cerceveResmi == null)
        {
            cerceveResmi.color = color;
        }
    }
}
