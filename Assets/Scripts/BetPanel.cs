using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BetPanel : MonoBehaviour
{
    [SerializeField]
    Player player;
    Slider slider;
    Text[] show_bet_cash;
    int bet_cash = 0;
    int bet_cash_amount = 0;

    void Start()
    {
        slider = GetComponentInChildren<Slider>();

        show_bet_cash = GetComponentsInChildren<Text>();
    }

    public void SetBettingAmount()
    {
        bet_cash = (int)((float)player.Cash * (float)slider.value);

        StringBuilder str = new StringBuilder();
        str.Append(bet_cash);
        str.Append("원 베팅");
        show_bet_cash[0].text = str.ToString();
    }

    public void Betting()
    {
        player.Cash = player.Cash - bet_cash;
        bet_cash_amount += bet_cash;
        slider.value = 0;
        bet_cash = 0;

        StringBuilder str = new StringBuilder();
        str.Append("총 ");
        str.Append(bet_cash_amount);
        str.Append("원 베팅중");
        show_bet_cash[3].text = str.ToString();
    }
}
