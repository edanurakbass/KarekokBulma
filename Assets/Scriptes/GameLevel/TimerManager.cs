using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private AudioClip oyunBitisSesi;

    int kalanSure;
    bool sureSaysinMi;

    GameManager gameManager;
    SonucManager sonucManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        kalanSure = 90;
        sureSaysinMi = true;

        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinMi)
        {
            yield return new WaitForSeconds(1f);
            if (kalanSure < 10)
            {
                timerText.text = "0" + kalanSure.ToString();
                timerText.color = Color.red;
            }
            else
            {
                timerText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinMi = false;
                timerText.text = "";
                sonucPaneli.SetActive(true);

                SesCikar(oyunBitisSesi);

                if (sonucPaneli != null)
                {
                    sonucManager = Object.FindObjectOfType<SonucManager>();
                    sonucManager.SonuclariYazdir(gameManager.dogruAdet, gameManager.yanlisAdet, gameManager.toplamPuan);

                }
            }
            kalanSure--;
        }
    }
    void SesCikar(AudioClip clip)
    {
        if (clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        }
    }

}
