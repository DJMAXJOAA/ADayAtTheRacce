using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Betting;

public class Player : MonoBehaviour
{
    [SerializeField]
    int cash = 100;
    public int Cash { get { return cash; }  set { cash = value; } }

    [SerializeField]
    Bet bet;

    void Start()
    {
        if (!bet)
        {
            bet = GetComponentInChildren<Bet>();

            if(!bet)
            {
                Debug.LogError(name + "´Â Bet¾ø´Ù");
            }
        }

    }
    public int getCash()
    {
        return cash;
    }

}
