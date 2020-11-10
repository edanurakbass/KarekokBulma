using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] kokiciResimler;

    [SerializeField]
    private Sprite[] kokdisiResimler;

    [SerializeField]
    private Image morKokdisiResim, maviKokdisiResim, griKokdisiResim;

    [SerializeField]
    private Image sariKokdisiResim, pembeKokdisiResim, yesilKokdisiResim;

    [SerializeField]
    private Image ustKokiciResim, altKokiciResim;

    [SerializeField]
    private Transform Sorulardairesi;

    [SerializeField]
    private Transform solBar, sagBar;

    [SerializeField]
    private GameObject trueIcon, falseIcon, dogruYanlisObje;

    [SerializeField]
    private Text dogruText, yanlisText, puanText;

    [SerializeField]
    private GameObject bonusObje;

    [SerializeField]
    private AudioClip baslangicClip;

    [SerializeField]
    private AudioClip daireSesi, barKapanisSesi;

 
    int hangiSoru;

    bool daireUstteMi;
    bool daireDonsunMu;

    string butondakiResim;

    Vector3 solBarBirinciYer = new Vector3(-273f, 80f, 0);
    Vector3 solBarIkincinciYer = new Vector3(-173f, 80f, 0); 
    Vector3 solBarUcuncuYer = new Vector3(-100f, 80f, 0);

    Vector3 sagBarBirinciYer = new Vector3(282f, 80f, 0); 
    Vector3 sagBarIkinciYer = new Vector3(182f, 80f, 0); 
    Vector3 sagBarUcuncuYer = new Vector3(109f, 80f, 0);

    int kacinciYanlis;

    public int dogruAdet, yanlisAdet;

    public int toplamPuan, puanArtisi;

    int bonusAdeti;

    bool butonaBasilsinMi;


    private void Start()
    {
        daireUstteMi = true;
        daireDonsunMu = true;
        butonaBasilsinMi = true;

        dogruAdet = 0;
        yanlisAdet = 0;

        toplamPuan = 0;
        puanArtisi = 0;
        bonusAdeti = 0;

        puanText.text = toplamPuan.ToString();

        SesCikar(baslangicClip);
        
        kacinciYanlis = 0;

        ResimleriYerlestir();
        
    }

    void ResimleriYerlestir()
    {
        hangiSoru = Random.Range(0, kokdisiResimler.Length - 3);
        int rasgeleDeger = Random.Range(0, 100);

        if (daireUstteMi)
        {
            if (rasgeleDeger <= 10)
            {
                morKokdisiResim.sprite = kokdisiResimler[hangiSoru];
                maviKokdisiResim.sprite = kokdisiResimler[hangiSoru + 1];
                griKokdisiResim.sprite = kokdisiResimler[hangiSoru + 2];
            }
            else if (rasgeleDeger <= 40)
            {
                morKokdisiResim.sprite = kokdisiResimler[hangiSoru + 1];
                maviKokdisiResim.sprite = kokdisiResimler[hangiSoru];
                griKokdisiResim.sprite = kokdisiResimler[hangiSoru + 2];
            }
            else
            {
                morKokdisiResim.sprite = kokdisiResimler[hangiSoru + 1];
                maviKokdisiResim.sprite = kokdisiResimler[hangiSoru + 2];
                griKokdisiResim.sprite = kokdisiResimler[hangiSoru];
            }
        }
        else
        {
            if (rasgeleDeger <= 10)
            {
                sariKokdisiResim.sprite = kokdisiResimler[hangiSoru];
                pembeKokdisiResim.sprite = kokdisiResimler[hangiSoru + 1];
                yesilKokdisiResim.sprite = kokdisiResimler[hangiSoru + 2];
            }
            else if (rasgeleDeger <= 40)
            {
                sariKokdisiResim.sprite = kokdisiResimler[hangiSoru + 1];
                pembeKokdisiResim.sprite = kokdisiResimler[hangiSoru];
                yesilKokdisiResim.sprite = kokdisiResimler[hangiSoru + 2];
            }
            else
            {
                sariKokdisiResim.sprite = kokdisiResimler[hangiSoru + 1];
                pembeKokdisiResim.sprite = kokdisiResimler[hangiSoru + 2];
                yesilKokdisiResim.sprite = kokdisiResimler[hangiSoru];
            }
        }
        if (daireUstteMi)
        {
            ustKokiciResim.sprite = kokiciResimler[hangiSoru];
        }
        else
        {
            altKokiciResim.sprite = kokiciResimler[hangiSoru];
        }

        daireUstteMi = !daireUstteMi;

    }

    public void ButonaBasildi()
    {
        butondakiResim = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;
       
        if (butonaBasilsinMi)
        {
            butonaBasilsinMi = false;
            SonucuKontrolEt();
        }

    }
    void SonucuKontrolEt()
    {
        if (butondakiResim == kokdisiResimler[hangiSoru].name)
        {
            //Dogrular
            dogruAdet++;
            bonusAdeti++;

            dogruText.text = dogruAdet.ToString();
            DogruYanlisIconGoster(true);
            DaireyiCevir();

            if (bonusAdeti >= 5 && bonusAdeti <= 9)
            {
                toplamPuan += 30;
                BonusScaleOn();
            }
            else
            {
                puanArtisi += 20;
            }

            if (bonusAdeti > 9)
            {
                BonusScaleOff();
                bonusAdeti = 0;
            }

         

        }
        else
        {
            BonusScaleOff();
            yanlisAdet++;
            bonusAdeti--;

            yanlisText.text = yanlisAdet.ToString();
            DogruYanlisIconGoster(false);
            kacinciYanlis++;
            BarlariKapat(kacinciYanlis);

            puanArtisi -= 5;
        }
        toplamPuan += puanArtisi;

        if (toplamPuan < 0)
        {
            toplamPuan = 0;
        }
        puanArtisi = 0;
        puanText.text = toplamPuan.ToString();
    }

    void DaireyiCevir()
    {
        if (daireDonsunMu)
        {
            daireDonsunMu = false;
            kacinciYanlis = 0;

            solBar.DOLocalMove(solBarBirinciYer, 0.2f);
            sagBar.DOLocalMove(sagBarBirinciYer, 0.2f);

            SesCikar(daireSesi);

            ResimleriYerlestir();

            Sorulardairesi.DORotate(Sorulardairesi.rotation.eulerAngles + new Vector3(0, 0, 180), 0.5f).OnComplete(DaireDonsunMuTrueYap);
        }
    }
    void DaireDonsunMuTrueYap()
    {
        butonaBasilsinMi = true;
        daireDonsunMu = true;
    }
    void BarlariKapat(int kacinciYanlis)
    {
        SesCikar(barKapanisSesi);
        if (kacinciYanlis == 1)
        {
            butonaBasilsinMi = true;
            solBar.DOLocalMove(solBarIkincinciYer, 0.2f);
            sagBar.DOLocalMove(sagBarIkinciYer, 0.2f);
        }
        else if (kacinciYanlis == 2)
        {
            solBar.DOLocalMove(solBarUcuncuYer, 0.2f);
            sagBar.DOLocalMove(sagBarUcuncuYer, 0.2f).OnComplete(BarkapanisiniBekle);
        }

        SesCikar(barKapanisSesi);
      
    }
    void BarkapanisiniBekle()
    {
        daireDonsunMu = true;
        Invoke("DaireyiCevir",1f);
    }

    void DogruYanlisIconGoster(bool dogruMu)
    {
        dogruYanlisObje.GetComponent<CanvasGroup>().alpha = 0;

        if (dogruMu)
        {
            trueIcon.SetActive(true);
            falseIcon.SetActive(false);
        }
        else
        {
            trueIcon.SetActive(false);
            falseIcon.SetActive(true);
        }
        dogruYanlisObje.GetComponent<CanvasGroup>().DOFade(1, 0.2f).OnComplete(TrueFalseIconuAlphaKapat);
    }
    void TrueFalseIconuAlphaKapat()
    {
        dogruYanlisObje.GetComponent<CanvasGroup>().DOFade(0, 0.2f);

    }
    void BonusScaleOn()
    {
        bonusObje.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutElastic);
    }

    void BonusScaleOff()
    {
        bonusObje.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InElastic);

    }
    public void GeriDon()
    {
        SceneManager.LoadScene("EgitimLevel");
    }

    void SesCikar(AudioClip clip)
    {
        if (clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        }
    }
}
