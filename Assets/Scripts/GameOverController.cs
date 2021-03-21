using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button replayButton,
                                    quitButton;
    [SerializeField] private SceneController sc;

    private void Start()
    {
        replayButton.onClick.AddListener(Replay);
        quitButton.onClick.AddListener(Quit);
    }

    private void Replay()
    {
        sc.LoadNextScene();
    }

    private void Quit()
    {
        Application.Quit();
    }
}
