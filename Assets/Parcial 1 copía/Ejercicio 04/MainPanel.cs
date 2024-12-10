using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private List<PlayersPanel> items = new List<PlayersPanel>();
    [SerializeField] private PlayersPanel scoreItemPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private Button sortButton;

    private int maxElements = 10;
    private bool isAscending = true;

    private void Awake()
    {
        sortButton.onClick.AddListener(ToggleSortOrder);
    }

    private void Start()
    {
        for (int i = 1; i <= maxElements; i++)
        {
            AddPlayer(i.ToString(), "Player " + i, Random.Range(0, 1000).ToString());
        }

        SortPlayers();
    }

    private void OnDestroy()
    {
        sortButton.onClick.RemoveAllListeners();
    }

    private void ToggleSortOrder()
    {
        isAscending = !isAscending;
        SortPlayers();
    }

    private void SortPlayers()
    {
        if (isAscending)
        {
            items.Sort((x, y) => int.Parse(x.ScoreText).CompareTo(int.Parse(y.ScoreText)));
        }
        else
        {
            items.Sort((x, y) => int.Parse(y.ScoreText).CompareTo(int.Parse(x.ScoreText)));
        }

        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.SetSiblingIndex(i);
        }
    }

    private void AddPlayer(string number, string name, string score)
    {
        PlayersPanel item = Instantiate(scoreItemPrefab, content);
        item.Set(number, name, score);
        items.Add(item);
        SortPlayers();
    }
}
