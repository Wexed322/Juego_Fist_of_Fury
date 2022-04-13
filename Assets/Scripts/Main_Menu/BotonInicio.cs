using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonInicio : MonoBehaviour
{
    public Button loadSceneGameplay;
    public Slider loadSlider;
    void Start()
    {

    }
    void Update()
    {

    }

    public void loadSceneGame() 
    {
        SceneManager.LoadScene("Game");
    }
    public void ActivateLoadingCanvas() 
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel() 
    {
        //yield return new WaitForSeconds(1);
        AsyncOperation op = SceneManager.LoadSceneAsync("Game");
        loadSceneGameplay.gameObject.SetActive(false);
        loadSlider.gameObject.SetActive(true);

        while (!op.isDone)
        {
            loadSlider.value = op.progress;
            yield return null;
        }

    }

}
