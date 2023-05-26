using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityProject;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] private GameObject _loadingPanel;
    void Awake()
    {
        if (!MemoryManager.Is_There_a_Key("Level"))
        {
            MemoryManager.SaveDataInt("Level", 1);
            MemoryManager.SaveDataInt("Score", 50);
            MemoryManager.SaveDataInt("GameSound", 1);
            MemoryManager.SaveDataInt("EffectSound", 1);


        }
    }

    public void StartMenu()
    {
        StartCoroutine(LoadScene(MemoryManager.ReadDataInt("Level")));
    }

    IEnumerator LoadScene(int SceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneIndex);
        _loadingPanel.SetActive(true);

        while (!op.isDone)
        {
            float prog = Mathf.Clamp01(op.progress / .9f);
            _slider.value =prog;
            yield return null;
        }


    }
}
