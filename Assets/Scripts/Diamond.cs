using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            if (player != null)
            {
                player.AmountOfDiamonds++;
                UIManager.Instance.UpdateGemCount(player.AmountOfDiamonds);
                Destroy(this.gameObject);
            }
        }
    }
}
