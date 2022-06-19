using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BtnScript : MonoBehaviour
{
    public Button button;
    void Start()
    {
        this.button.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {

    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Map");
    }
}
