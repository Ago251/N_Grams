using System;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public event Action<SignType> OnSignPlayed;

    [SerializeField]
    private UIPlayer uiPlayer;

    public abstract void StartTurn();

    protected virtual void DrawSymbol(SignType symbol)
    {
        uiPlayer.SetSign(symbol);
        OnSignPlayed?.Invoke(symbol);
    }
}

