using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EgitimMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startBtn, geriDonBtn;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private GameObject kokiciPrefab;

    [SerializeField]
    private Transform content;

    [SerializeField]
    private Sprite[] kokiciResimler;
   
    [SerializeField]
    private Sprite[] kokdisiResimler;

    [SerializeField]
    private Image kokdisiImage;

    [SerializeField]
    private Text aciklamaText;

    [SerializeField]
    private AudioClip alistirmaClip;
    void Start()
    {
        aciklamaText.text = "";
        fadePanel.SetActive(true);
        
        fadePanel.GetComponent<CanvasGroup>().alpha = 1;

        fadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(IlkAyariYap);

        kokdisiImage.sprite = kokdisiResimler[0];

        if (startBtn != null)
        {
            startBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
            
        } 
        if (startBtn != null)
        {
            geriDonBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
            
        }

        fadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(IlkAyariYap);
    }

    void IlkAyariYap()
    {
        fadePanel.SetActive(false);

        aciklamaText.text = "Alttaki panelden resimleri surukleyerek istediginiz resime tiklayip kok degerini ogrenebilirsiniz";

        SesCikar(alistirmaClip);
        ButonlariAc();
        KokiciResimlerOlustur();
    }
    void ButonlariAc()
    {
        startBtn.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        geriDonBtn.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

   void KokiciResimlerOlustur()
    {
        for (int i = 0; i < kokiciResimler.Length; i++)
        {
            GameObject kokiciItem = Instantiate(kokiciPrefab, content);

            kokiciItem.GetComponent<KokiciButonManager>().butonNo = i;

            kokiciItem.transform.GetChild(3).GetComponent<Image>().sprite = kokiciResimler[i];
        }

        
    }

    public void KokdisiGoster(int butonNo)
    {
        kokdisiImage.sprite = kokdisiResimler[butonNo];
    }
    public void MenuLevelineDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void OyunLevelineGit()
    {
        SceneManager.LoadScene("GameLevel");
    }

    void SesCikar(AudioClip clip)
    {
        if (clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        }
    }
}
