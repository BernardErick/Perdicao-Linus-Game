using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BackgroundImageAction : MonoBehaviour
{
    public Image outsideImage;

    public Sprite[] sprites;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }

    void Action() {
        int current = outsideImage.GetComponent<InteractiveLabelAction>().currentText;

        switch (current) {
            case 1:
                this.GetComponent<Image>().sprite = sprites[0];
            break;
            case 2:
                this.GetComponent<Image>().sprite = sprites[4];
                break;
            case 3:
                this.GetComponent<Image>().sprite = sprites[5];
                break;
            case 4:
                this.GetComponent<Image>().sprite = sprites[3];
                break;
            case 5:
                this.GetComponent<Image>().sprite = sprites[0];
                break;
            case 6:
                this.GetComponent<Image>().sprite = sprites[2];
                break;
            case 7:
                this.GetComponent<Image>().sprite = sprites[1];
                break;
            case 15:
                this.GetComponent<Image>().sprite = sprites[6];
                break;
            case 23:
                SceneManager.LoadScene("Map");
                break;
        }
    }
}
