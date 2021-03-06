using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class IntroText : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI speakerName;
    private List<string> introLines;
    private int index;
    private bool readIntro;
    public PlayerMovement playMove;

    void Start()
    {
        index = 0;
        introLines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Intro.txt"));
        textBox.GetComponentInChildren<TextMeshProUGUI>().text = introLines[index];
        speakerName.text = "Cyrus";
        readIntro = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (readIntro)
        {
            playMove.canMove = false;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                index++;
                textBox.GetComponentInChildren<TextMeshProUGUI>().text = introLines[index];
            }

            if (index >= introLines.Count - 1)
            {
                readIntro = false;
            }
                
        }
    }
}
