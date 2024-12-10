using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{
    public StoreItem item;  // El �tem asociado con este bot�n
    private Button buyButton;  // El bot�n de compra

    public StoreManager storeManager;  // Referencia al StoreManager

    // Este evento se ejecutar� cuando se haga clic en el bot�n
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
        // Obtener el bot�n
        buyButton = GetComponentInChildren<Button>();

        if (buyButton != null)
        {
            // Asignar el listener al bot�n
            buyButton.onClick.AddListener(OnBuyClicked);
        }
        else
        {
            Debug.LogError("El bot�n no se encuentra en el prefab");
        }
    }
}
