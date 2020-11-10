using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hakkimdaPanel;

    bool panelAcikMi;

    private void Start()
    {
        panelAcikMi = false;
    }
    public void OyunaBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void HakkimdaPanelAc()
    {
        if (!panelAcikMi)
        {
            hakkimdaPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        }
        else
        {
            hakkimdaPanel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        }

        panelAcikMi = !panelAcikMi;
    }
    public void OyundanCik()
    {
        Application.Quit();
    }

}