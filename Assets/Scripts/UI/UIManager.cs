using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image _selectionImage;
    [SerializeField] TMP_Text _gemCountText;
    [SerializeField] Image[] _healthImages;

    private static UIManager instance;

    public static UIManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text DiamondCount;

    public void OpenShop(int count)
    {
        DiamondCount.text = count+ "G";
    }

    public void UpdateShopSelection(int yPos)
    {
         _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x, yPos);
        
    }

    public void UpdateGemCount(int count)
    {
        _gemCountText.text = "" + count + "G";
    }

    public void UpdateLives(int livesRemaining)
    {
        for(int i = 0; i < _healthImages.Length; i++)
        {
            if(i + 1 > livesRemaining)
            {
                _healthImages[i].enabled = false;
            }
        }
        //loop through lives
        //if i equal live remaining disable health
    }

}
