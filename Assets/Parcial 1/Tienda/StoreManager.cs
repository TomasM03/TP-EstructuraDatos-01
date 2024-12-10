using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameObject panelPrefab;
    public Transform contentParent;
    public int playerMoney = 1000;
    public TextMeshProUGUI playerMoneyText;

    public Sprite rengarSprite;
    public Sprite katarinaSprite;
    public Sprite azirSprite;
    public Sprite zedSprite;
    public Sprite vladimirSprite;

    private List<StoreItem> items = new List<StoreItem>();
    public float panelSpacing = 150f; // Espaciado entre los paneles

    public Button sortByPriceButton;
    public Button sortByTypeButton;

    void Start()
    {
        // Crear los �tems de la tienda

        sortByPriceButton.onClick.AddListener(SortByPrice);
        sortByTypeButton.onClick.AddListener(SortByType);

        items.Add(new Zed(zedSprite));
        items.Add(new Katarina(katarinaSprite));
        items.Add(new Vladimir(vladimirSprite));
        items.Add(new Azir(azirSprite));
        items.Add(new Rengar(rengarSprite));

        CreateStorePanels();

        // Actualizar el texto del dinero del jugador
        UpdatePlayerMoneyText();
    }

    private void CreateStorePanels()
    {
        // Limpiar los paneles existentes
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Instanciar los paneles para cada �tem
        for (int i = 0; i < items.Count; i++)
        {
            GameObject panel = Instantiate(panelPrefab, contentParent);

            panel.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = items[i].Name;
            panel.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = $"${items[i].Price}";
            panel.transform.Find("Image").GetComponent<Image>().sprite = items[i].Image;

            RectTransform panelRect = panel.GetComponent<RectTransform>();
            panelRect.anchoredPosition = new Vector2(-i * panelSpacing, 0);

            Button buyButton = panel.transform.Find("Buy").GetComponent<Button>();

            // Configurar el bot�n de compra
            StoreItem currentItem = items[i];
            buyButton.onClick.AddListener(() => BuyItem(currentItem, buyButton));
        }
    }

    // M�todo que es llamado desde el ItemButton
    public void BuyItem(StoreItem item, Button buyButton)
    {
        if (playerMoney >= item.Price)
        {
            playerMoney -= item.Price;
            buyButton.interactable = false;  // Desactivar el bot�n de compra
            UpdatePlayerMoneyText();  // Actualizar el dinero del jugador
            Debug.Log($"Compraste: {item.Name} por ${item.Price}");
        }
        else
        {
            Debug.Log("No tienes suficiente dinero.");
        }
    }

    // M�todos de ordenaci�n
    private void SortByPrice()
    {
        items.Sort((x, y) => x.Price.CompareTo(y.Price)); // Ordenar por precio ascendente
        CreateStorePanels(); // Actualizar los paneles
    }
    private void SortByType()
    {
        items.Sort((x, y) => x.type.CompareTo(y.type)); // Ordenar por tipo (ascendente)
        CreateStorePanels(); // Actualizar los paneles
    }


    // Actualizar el texto del dinero en la UI
    private void UpdatePlayerMoneyText()
    {
        playerMoneyText.text = $"Money: ${playerMoney}";
    }
}
