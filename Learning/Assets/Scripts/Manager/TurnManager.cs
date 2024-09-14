using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private PlayerBase[] players;

    private int currentPlayer;

    private SignType aiSign;

    private void Start()
    {
        foreach (var player in players)
        {
            player.OnSignPlayed += OnPlayerPlayed;
        }

        players[currentPlayer].StartTurn();
    }

    private void OnPlayerPlayed(SignType signType)
    {
        if (currentPlayer == 0)
            aiSign = signType;

        currentPlayer++;

        if (currentPlayer > players.Length - 1)
        {
            DisplayWinText(signType);
            currentPlayer = 0;
            Debug.Log("----------------------------");
            Debug.Log("New turn");
        }

        players[currentPlayer].StartTurn();
    }

    public void DisplayWinText(SignType playerSign)
    {
        switch (playerSign)
        {
            case SignType.Rock:
                if (aiSign == SignType.Paper)
                {
                    Debug.Log("AI Win");
                }
                else if (aiSign == SignType.Scissor)
                {
                    Debug.Log("Player Win");
                }
                break;
            case SignType.Paper:
                if (aiSign == SignType.Scissor)
                {
                    Debug.Log("AI Win");
                }
                else if (aiSign == SignType.Rock)
                {
                    Debug.Log("Player Win");
                }
                break;
            case SignType.Scissor:
                if (aiSign == SignType.Rock)
                {
                    Debug.Log("AI Win");
                }
                else if (aiSign == SignType.Paper)
                {
                    Debug.Log("Player Win");
                }
                break;
        }
    }
}
