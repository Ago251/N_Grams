using System;

public interface IPlayable
{
    public event Action<SignType> OnSignPlayed;

    public void StartTurn();
}
