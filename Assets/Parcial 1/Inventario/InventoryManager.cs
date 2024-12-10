using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public Transform itemListContainer; // Contenedor para mostrar los ítems
    public GameObject itemPrefab; // Prefab para cada ítem en la UI

    void Start()
    {
        // Inicializar el inventario con 10 ítems aleatorios
        for (int i = 0; i < 10; i++)
        {
            AddRandomItem();
        }
        UpdateInventoryUI();
    }

    // Agregar un ítem aleatorio
    public void AddRandomItem()
    {
        string[] types = { "Arma", "Armadura", "Consumible", "Accesorio" };
        string randomName = "Item" + Random.Range(1, 100);
        string randomType = types[Random.Range(0, types.Length)];
        int randomValue = Random.Range(1, 101);

        inventory.Add(new Item(randomName, randomType, randomValue));
        UpdateInventoryUI();
    }

    // Eliminar un ítem aleatorio
    public void RemoveRandomItem()
    {
        if (inventory.Count > 0)
        {
            int randomIndex = Random.Range(0, inventory.Count);
            inventory.RemoveAt(randomIndex);
            UpdateInventoryUI();
        }
    }

    // Ordenar por Nombre (BubbleSort)
    public void SortByName()
    {
        for (int i = 0; i < inventory.Count - 1; i++)
        {
            for (int j = 0; j < inventory.Count - i - 1; j++)
            {
                if (string.Compare(inventory[j].Name, inventory[j + 1].Name) > 0)
                {
                    var temp = inventory[j];
                    inventory[j] = inventory[j + 1];
                    inventory[j + 1] = temp;
                }
            }
        }
        UpdateInventoryUI();
    }

    // Ordenar por Tipo (SelectionSort)
    public void SortByType()
    {
        for (int i = 0; i < inventory.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < inventory.Count; j++)
            {
                if (string.Compare(inventory[j].Type, inventory[minIndex].Type) < 0)
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                var temp = inventory[i];
                inventory[i] = inventory[minIndex];
                inventory[minIndex] = temp;
            }
        }
        UpdateInventoryUI();
    }

    // Ordenar por Valor (BubbleSort)
    public void SortByValue()
    {
        for (int i = 0; i < inventory.Count - 1; i++)
        {
            for (int j = 0; j < inventory.Count - i - 1; j++)
            {
                if (inventory[j].Value > inventory[j + 1].Value)
                {
                    var temp = inventory[j];
                    inventory[j] = inventory[j + 1];
                    inventory[j + 1] = temp;
                }
            }
        }
        UpdateInventoryUI();
    }

    // Actualizar la UI del inventario
    void UpdateInventoryUI()
    {
        foreach (Transform child in itemListContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in inventory)
        {
            GameObject newItem = Instantiate(itemPrefab, itemListContainer);
            newItem.GetComponentInChildren<TextMeshProUGUI>().text = $"{item.Name} - {item.Type} - ${item.Value}";
        }
    }
}

