using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Annotator : MonoBehaviour
{
    private Stack<string> notes;

    [SerializeField] private bool isWriting = false;

    private string currentInput = "";

    public TMP_Text notesTXT;

    private void Awake()
    {
        notes = new Stack<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isWriting = true;
            currentInput = "";
            notesTXT.text += "\n";
        }

        if (isWriting)
        {
            foreach (char c in Input.inputString)
            {
                if (c == '\b')
                {
                    if (currentInput.Length > 0)
                    {
                        currentInput = currentInput.Substring(0, currentInput.Length - 1);
                    }
                }
                else if (c == '\r')
                {
                    if (currentInput.Length > 0)
                    {
                        notes.Push(currentInput);
                        UpdateNotesDisplay();
                        currentInput = "";
                        isWriting = false;
                    }
                }
                else
                {
                    currentInput += c;
                }
            }

            notesTXT.text = notesTXT.text.TrimEnd('\n') + "\n" + currentInput;
        }
    }

    private void UpdateNotesDisplay()
    {
        notesTXT.text = "";

        foreach (string note in notes)
        {
            notesTXT.text += note + "\n";
        }
    }
}
