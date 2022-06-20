using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public Button button;
    public string mapToGo;
    void Start()
    {
        this.button.onClick.AddListener(btnOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btnOnClick() {
        SceneManager.LoadScene(mapToGo);
    }
}
