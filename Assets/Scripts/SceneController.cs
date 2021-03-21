using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int sceneCount;
    [SerializeField] private Animator anim;
    [SerializeField] private string fadeInBoolName;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadNextScene();
        }
    }

    private void PlayFadeInAnimation()
    {
        anim.SetBool(fadeInBoolName, true);
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        PlayFadeInAnimation();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % sceneCount);
    }
}
