using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(1))
        {
            FadeToLevel(1);
        }*/
    }

    //dispara o FaadeOut
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    //carrega novo level quando FadeToLevel terminar
    public void OnFadeComplete()
    {
        //SceneManager.LoadScene(levelToLoad);
        Debug.Log("CARREGOU NOVO NÍVEL");
    }
}
