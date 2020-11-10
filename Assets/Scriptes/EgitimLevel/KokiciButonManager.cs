using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KokiciButonManager : MonoBehaviour
{
    [SerializeField]
    private Image kokiciImage;

    public int butonNo;

    EgitimMenuManager egitimMenuManager;

    private void Awake()
    {
        egitimMenuManager = FindObjectOfType<EgitimMenuManager>();
    }

    public void ButonaTiklandi()
    {
        egitimMenuManager.KokdisiGoster(butonNo);
    }
}
