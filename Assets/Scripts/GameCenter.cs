using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Lab1;
using UnityEngine.UI;
using Betting;

public class GameCenter : MonoBehaviour
{
    [SerializeField]
    Transform dogRoot;
    [SerializeField]
    Transform playerRoot;
    [SerializeField]
    Button buttonRace;
    [SerializeField]
    Transform panelBetting;

    public enum Step
    {
        Betting,
        ReadyRace,
        StartRace,
        Racing,
        EndRace,
        ShowResult,
    }

    [SerializeField]
    Step currentStep;

    Dogs[] dogs = null;
    Player[] players = null;
    Bet[] betting = null;

    void Start()
    {
        if (!buttonRace)
        {
            Debug.LogError("레이스 버튼이 연결되지 않음");
        }

        LoadGuys(playerRoot.childCount);
        LoadDogs(dogRoot.childCount);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            buttonRace.interactable = !buttonRace.interactable;
            Debug.Log("Race 버튼이 토글됨 - 사용 가능 여부 : " + buttonRace.interactable);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            NextStep();
        }
    }


    void LoadGuys(int count)
    {
        players = new Player[count];
        betting = new Bet[count];
        for (int i = 0; i < playerRoot.childCount; i++)
        {
            players[i] = playerRoot.GetChild(i).GetComponent<Player>();
            betting[i] = panelBetting.GetChild(i).GetComponent<Bet>();
            Debug.Log(players[i].name + "읽었음");
        }
    }

    void LoadDogs(int count)
    {
        dogs = new Dogs[count];
        for (int i = 0; i < dogRoot.childCount; i++)
        {
            dogs[i] = dogRoot.GetChild(i).GetComponent<Dogs>();
            dogs[i].SetID(i);
            
            Debug.Log(dogs[i].name + "읽었음");
        }
    }

    void LoadPanel(int count)
    {
        dogs = new Dogs[count];
        for (int i = 0; i < dogRoot.childCount; i++)
        {
            dogs[i] = dogRoot.GetChild(i).GetComponent<Dogs>();
            dogs[i].SetID(i);

            Debug.Log(dogs[i].name + "읽었음");
        }
    }

    void NextStep()
    {
        
        Step preStep = currentStep;
        currentStep = (currentStep == Step.ShowResult) ? Step.Betting : currentStep + 1;

        switch (currentStep)
        {
            case Step.ReadyRace:
                {
                    buttonRace.interactable = true;
                }
                break;
            case Step.StartRace:
                {
                    buttonRace.interactable = false;
                }
                break;
            case Step.Racing:
                {

                }
                    break;
        }
    }

    public void StartRace()
    {
        NextStep();
        Debug.Log("Start");

        for (int i = 0; i < dogs.Length; i++)
        {
            dogs[i].Run();
        }

        NextStep();
    }

    public void StartBet()
    {
        
    }

    public void EndBet()
    {
        panelBetting.gameObject.SetActive(false);
        Debug.Log("End Bet");
        NextStep();
    }
        // 상태가 변경될 때, Step.betting -> Step.StartRace : buttonRace.interactable를 활성화 시켜준다.
}