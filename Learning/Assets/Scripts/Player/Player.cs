using System;
using UnityEngine;

public class Player : PlayerBase
{
    public void DrawRock() => DrawSymbol(SignType.Rock);
    
    public void DrawPaper() => DrawSymbol(SignType.Paper);
    
    public void DrawScissors() => DrawSymbol(SignType.Scissor);

    public override void StartTurn()
    {
        Debug.Log("Your turn");
    }
}

