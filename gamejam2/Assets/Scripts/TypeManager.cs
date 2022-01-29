using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeManager : MonoBehaviour
{
    public static TypeManager ins;

    string targetWord;
    string currentWord;

    bool isTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        ins = this;
        targetWord = "";
        currentWord = "";
    }

    public string GetTargetWord() { return targetWord; }
    public string GetCurrentWord() { return currentWord; }
    public bool IsTyping() { return isTyping; }

    public void SetTargetWord(string word) {
        targetWord = word;
        currentWord = "";
    }

    void Update() {
        if (isTyping) {
            if (currentWord.Length >= targetWord.Length) {
                // Word completed
                isTyping = false;
                return;
            }

            char targetChar = targetWord[currentWord.Length];
            if (!Input.anyKeyDown)
                return;

            if (Input.inputString.Length > 0 && Input.inputString[0] == targetChar) {
                // Correct letter typed
                currentWord = targetWord.Substring(0, currentWord.Length+1);
            } else {
                // Incorrect letter typed
                Debug.Log("Wrong letter!");
            }
        }
    }

    public void StartTyping() {
        isTyping = true;
    }

    /*public void StartTyping() {
        if (targetWord == "")
            return;
        StartCoroutine(Typing());
    }*/

    /*IEnumerator Typing() {
        while (true) {
            if (currentWord.Length >= targetWord.Length)
                break;  // word completed
            char targetChar = targetWord[currentWord.Length];
            while (!Input.anyKeyDown) {
                yield return null;
            }

            if (Input.inputString[0] == targetChar) {
                // Correct letter typed
                currentWord = targetWord.Substring(0, currentWord.Length+1);
            } else {
                // Incorrect letter typed
                Debug.Log("Wrong letter!");
            }
        }
    }*/
}
