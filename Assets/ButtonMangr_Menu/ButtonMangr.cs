using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMangr : MonoBehaviour
{
    private void Start()
    {
        SoundEvents.Instance.Play("ENV_AMBIENCE_v1_test");
    }

    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
