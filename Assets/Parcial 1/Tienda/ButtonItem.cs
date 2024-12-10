using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{
    public StoreItem item;  // El ítem asociado con este botón
    private Button buyButton;  // El botón de compra

    public StoreManager storeManager;  // Referencia al StoreManager

    // Este evento se ejecutará cuando se haga clic en el botón
    public void OnBuyClicked()
    {
        if (storeManager != null && item != null)  // Verificar que no sea null
        {
            storeManager.BuyItem(item, buyButton);  // Invocar la compra
        }
        else
        {
            Debug.LogWarning("storeManager o item es null");
        }
    }

    void Start()
    {
        // Obtener el botón
        buyButton = GetComponentInChildren<Button>();

        if (buyButton != null)
        {
            // Asignar el listener al botón
            buyButton.onClick.AddListener(OnBuyClicked);
        }
        else
        {
            Debug.LogError("El botón no se encuentra en el prefab");
        }
    }
}
