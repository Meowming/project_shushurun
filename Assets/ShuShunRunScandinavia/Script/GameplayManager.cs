using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    public PlayerManager player;
    public Slider SanitySlider;
    public Slider MoneySlider;

    // Start is called before the first frame update
    void Start()
    {

        SanitySlider.maxValue = player.maxSanity;
        SanitySlider.value = player.currentSanity;

        MoneySlider.maxValue = player.cashTarget;
        MoneySlider.value = player.cashAmount;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SanitySlider.value = player.currentSanity;
        MoneySlider.value = player.cashAmount;
    }
}
