using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image _selectionImage;

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

}
