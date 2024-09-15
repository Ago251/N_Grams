using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private PlayerBase[] players;
    [SerializeField]
    private Button[] signButtons;
    [SerializeField]
    private Button newTurnButton;

    private int currentPlayer;

    private SignType aiSign;

    private void Start()
    {
        newTurnButton.onClick.AddListener(StartNewTurn);

        foreach (var player in players)
        {
            player.OnSignPlayed += OnPlayerPlayed;
        }

        players[currentPlayer].StartTurn();
    }

    private void OnDestroy()
    {
        newTurnButton.onClick.RemoveListener(StartNewTurn);

        foreach (var player in players)
        {
            player.OnSignPlayed -= OnPlayerPlayed;
        }
    }

    private void OnPlayerPlayed(SignType signType)
    {
        if (currentPlayer == 0)
            aiSign = signType;

        currentPlayer++;

        if (currentPlayer > players.Length - 1)
        {
            EndTurn(signType);
        }
        else
        {
            players[currentPlayer].StartTurn();
        }
    }

    private void StartNewTurn()
    {
        foreach (var player in players)
            player.SetStatus(PlayerStatus.Playing);

        SetActiveAllSignButtons(true);

        newTurnButton.gameObject.SetActive(false);
        currentPlayer = 0;
        players[currentPlayer].StartTurn();
    }

    private void EndTurn(SignType signType)
    {
        foreach (var player in players)
            player.ShowSign();

        SetActiveAllSignButtons(false);

        UpdatePlayerStatus(signType);
        currentPlayer = 0;
        newTurnButton.gameObject.SetActive(true);
    }

    private void SetActiveAllSignButtons(bool active)
    {
        foreach (var button in signButtons)
            button.gameObject.SetActive(active);
    }

    public void UpdatePlayerStatus(SignType playerSign)
    {
        switch (playerSign)
        {
            case SignType.Rock:
                players[0].SetStatus(aiSign == SignType.Paper ? PlayerStatus.Winner : PlayerStatus.Loser);
                players[1].SetStatus(aiSign == SignType.Scissor ? PlayerStatus.Winner : PlayerStatus.Loser);
                break;
            case SignType.Paper:
                players[0].SetStatus(aiSign == SignType.Scissor ? PlayerStatus.Winner : PlayerStatus.Loser);
                players[1].SetStatus(aiSign == SignType.Rock ? PlayerStatus.Winner : PlayerStatus.Loser);
                break;
            case SignType.Scissor:
                players[0].SetStatus(aiSign == SignType.Rock ? PlayerStatus.Winner : PlayerStatus.Loser);
                players[1].SetStatus(aiSign == SignType.Paper ? PlayerStatus.Winner : PlayerStatus.Loser);
                break;
        }
    }
}
