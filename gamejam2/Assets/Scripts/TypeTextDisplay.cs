using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeTextDisplay : MonoBehaviour
{
    public Text textDisplay;

    string targetWord;
    string currentWord;

    string typedColor = "green";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetWord = TypeManager.ins.GetTargetWord();
        currentWord = TypeManager.ins.GetCurrentWord();

        if (textDisplay != null) {
            string text;
            if (currentWord != "") {
                text = "<color=" + typedColor + ">" + currentWord + "</color>" + targetWord.Substring(currentWord.Length);
            } else {
                text = targetWord;
            }

            textDisplay.text = text;
        } 
    }

    public void SetTargetWord(string word) {
        targetWord = word;
        currentWord = "";
    }
}
