using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoSingletonGeneric<TurnManager>
{
    [SerializeField] private TankController tankA,
                                            tankB;
    [SerializeField] private SceneController sc;
    private bool tankATurn;

    private void Start()
    {
        tankATurn = false;
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        tankATurn = !tankATurn;
        tankA.SetTurn = tankATurn;
        tankB.SetTurn = !tankATurn;
        
        if(tankATurn)
        {
            tankA.AddListenerToButton();
        }
        else
        {
            tankB.AddListenerToButton();
        }

    }

    public void GameOver()
    {
        sc.LoadNextScene();
        Destroy(gameObject);
    }
}
