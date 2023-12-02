using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] GameObject _shopPanel;
    [SerializeField] int _currentItemSelected;
    [SerializeField] int _currentItemCost;

    Player _player;

    public int currentItemSelected { get { return _currentItemSelected; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _player = collision.GetComponent<Player>();

            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player.AmountOfDiamonds);
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
            case 0: UIManager.Instance.UpdateShopSelection(116); _currentItemSelected = 0; _currentItemCost = 200; break;
            case 1: UIManager.Instance.UpdateShopSelection(2); _currentItemSelected = 1; _currentItemCost = 400; break;
            case 2: UIManager.Instance.UpdateShopSelection(-112); _currentItemSelected = 2; _currentItemCost = 100; break;
                default: break;
        }
    }

    public void BuyItem()
    {
        if(_player.AmountOfDiamonds >= _currentItemCost)
        {
            //award item

            switch(_currentItemSelected)
            {
                case 0: break;
                case 1: break;
                case 2: GameManager.Instance.HasKeyToCastle = true; break;
            }

            _player.AmountOfDiamonds -= _currentItemCost;
            _shopPanel.SetActive(false);
        }else
        {
            Debug.Log("Not Enough Diamonds");
            _shopPanel.SetActive(false);
        }
    }
}
