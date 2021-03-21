using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    [SerializeField] private Slider powerSlider,
                                    angleSlider;

    [SerializeField] private TextMeshProUGUI powerValue,
                                             angleValue,
                                             healthText;
    [SerializeField] private Button fireButton;
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private Transform nozzlePosition;
    
    private int health;
    private bool thisTankTurn;
    public bool SetTurn { set { thisTankTurn = value; } }

    private void Start()
    {
        AddListenerToButton();
        health = 100;
    }

    private void Update()
    {
        UpdateSliders();
    }

    private void UpdateSliders()
    {
        powerValue.SetText(powerSlider.value.ToString());
        angleValue.SetText(angleSlider.value.ToString());
    }
    
    public void AddListenerToButton()
    {
        fireButton.onClick.AddListener(FireBullet);
    }

    public void RemoveListenerFromButton()
    {
        fireButton.onClick.RemoveListener(FireBullet);
    }

    private void FireBullet()
    {
        if(thisTankTurn)
        {
            BulletController temp = Instantiate(bulletPrefab);
            temp.gameObject.transform.position = nozzlePosition.transform.position;
            TurnManager.Instance.ChangeTurn();
            RemoveListenerFromButton();
        }
    }

    public void DealDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            healthText.SetText("0");
            TurnManager.Instance.GameOver();
        }
        else
        {
            healthText.SetText(health.ToString());
        }
    }

}
