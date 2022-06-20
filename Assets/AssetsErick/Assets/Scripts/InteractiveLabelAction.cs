using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class InteractiveLabelAction : MonoBehaviour
{
    //Caminho para chegar no arquivo (Obrigatorio)
    public string FilePath;

    //Numero de frases que serão criadas (Obrigatorio)
    public int NumberOfSentences;

    public Button childButton;

    public Text childText;

    public string[] FullDialog;

    public int currentText;


    void Start()
    {
        this.currentText = 1;
        this.FullDialog = ConvertFileToArrayString();
        this.childText.text = FullDialog[0];
        this.childButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentText == NumberOfSentences) {
            Destroy(this.gameObject);
        }
    }

    string[] ConvertFileToArrayString() {
        if (File.Exists(FilePath))
        {
            string[] arr = new string[NumberOfSentences];
            int i = 0;
            using (StreamReader sr = File.OpenText(FilePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.StartsWith(" ") || s.Length == 0)
                        i++;
                    arr[i] += s;
                }
            }
            return arr;
        }
        return null;
    }
    void TaskOnClick() {

        this.childText.text = FullDialog[this.currentText];
        this.currentText++;
    }
}
