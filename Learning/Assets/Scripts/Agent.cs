using System;
using System.Collections;
using UnityEngine;

public class Agent : PlayerBase
{
    [SerializeField]
    private PlayerBase _enemy;

    public override void StartTurn()
    {
        var probabilityActionHandler = _enemy.GetComponent<ProbabilityActionHandler>();
        var probabilyEnemyAction = probabilityActionHandler.GetActionWithHighProbility();
        SignType selectedSign = SignType.Paper;

        switch (probabilyEnemyAction)
        {
            case SignType.Rock:
                //Play paper
                selectedSign = SignType.Paper;
                break;
            case SignType.Paper:
                //Play Scissor
                selectedSign = SignType.Scissor;
                break;
            case SignType.Scissor:
                //Play Rock
                selectedSign = SignType.Rock;
                break;
        }

        Debug.Log(gameObject.name + ": " + selectedSign.ToString());
        DrawSymbol(selectedSign);
    }
}
