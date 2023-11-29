using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] GameObject _shopPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            if (player != null)
            {
                UIManager.Instance.OpenShop(player.AmountOfDiamonds);
            }
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        //0 = Flame Sword
        //1 = Boots
        //2 = Key
        Debug.Log("Selected");

        switch(item)
        {
            case 0: UIManager.Instance.UpdateShopSelection(116); break;
            case 1: UIManager.Instance.UpdateShopSelection(2); break;
            case 2: UIManager.Instance.UpdateShopSelection(-112); break;
                default: break;
        }
    }
}
