using System;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public event Action<SignType> OnSignPlayed;

    [SerializeField]
    private UIPlayer uiPlayer;

    [SerializeField]
    private SignType selectedSign;

    public abstract void StartTurn();
    public virtual void ShowSign() => uiPlayer.SetSign(selectedSign);
    public void SetStatus(PlayerStatus status) => uiPlayer.SetStatus(status);
    protected virtual void DrawSymbol(SignType sign)
    {
        selectedSign = sign;
        OnSignPlayed?.Invoke(sign);
    }

}

