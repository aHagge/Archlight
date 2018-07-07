using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

    public Slider slider;
    public Text progresstext;
    public void Loadlevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynch(sceneIndex));
    }

    private void Start()
    {
        Loadlevel(2);
    }
    IEnumerator LoadAsynch(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progresstext.text = progress * 100f + "%".ToString();
            yield return null;
        }

    }

}
