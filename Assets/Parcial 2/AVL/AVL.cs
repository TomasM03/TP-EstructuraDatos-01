using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class AVL : ABB
{
    public Node avlRoot;

    public class Node
    {
        public int Key;
        public Node Left, Right;
        public int Height;

        public Node(int key)
        {
            Key = key;
            Height = 1;
        }
    }

    private void Start()
    {
        avlRoot = null;
        foreach (int key in myArray)
        {
            avlRoot = Insert(avlRoot, key);
        }

        ShowAVLTree(avlRoot, new Vector2(0, 3), 2.0f, 2.0f, 0);
    }

    public Node Insert(Node node, int key)
    {
        if (node == null)
            return new Node(key);

        if (key < node.Key)
            node.Left = Insert(node.Left, key);
        else if (key > node.Key)
            node.Right = Insert(node.Right, key);
        else
            return node;

        node.Height = 1 + Mathf.Max(GetHeight(node.Left), GetHeight(node.Right));

        int balance = GetBalance(node);

        if (balance > 1 && key < node.Left.Key)
            return RotateRight(node);

        if (balance < -1 && key > node.Right.Key)
            return RotateLeft(node);

        if (balance > 1 && key > node.Left.Key)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        if (balance < -1 && key < node.Right.Key)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private int GetHeight(Node node)
    {
        return node == null ? 0 : node.Height;
    }

    private int GetBalance(Node node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }

    private Node RotateRight(Node y)
    {
        Node x = y.Left;
        Node T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = Mathf.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Mathf.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    private Node RotateLeft(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = Mathf.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Mathf.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y;
    }

    void ShowAVLTree(Node node, Vector2 position, float verticalSpacing, float horizontalSpacing, int index)
    {
        if (node != null)
        {
            GameObject newCircle = Instantiate(circlePrefab, position, Quaternion.identity);
            TextMeshProUGUI circleText = newCircle.GetComponentInChildren<TextMeshProUGUI>();
            circleText.text = node.Key.ToString();

            Vector2 leftChildPosition = position + new Vector2(-horizontalSpacing / (index + 1), -verticalSpacing);
            Vector2 rightChildPosition = position + new Vector2(horizontalSpacing / (index + 1), -verticalSpacing);

            if (node.Left != null)
            {
                DrawLine(position, leftChildPosition);
                ShowAVLTree(node.Left, leftChildPosition, verticalSpacing, horizontalSpacing, 2 * index + 1);
            }

            if (node.Right != null)
            {
                DrawLine(position, rightChildPosition);
                ShowAVLTree(node.Right, rightChildPosition, verticalSpacing, horizontalSpacing, 2 * index + 2);
            }
        }
    }
}
