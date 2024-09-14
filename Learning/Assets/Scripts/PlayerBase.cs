using System;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public event Action<SignType> OnSignPlayed;

    public abstract void StartTurn();

    protected virtual void DrawSymbol(SignType symbol)
    {
        OnSignPlayed?.Invoke(symbol);
    }
}

