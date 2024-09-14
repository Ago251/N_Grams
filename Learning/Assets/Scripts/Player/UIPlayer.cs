using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerNameLabel;

    [SerializeField]
    private Image signSlot;

    [SerializeField]
    private UIPlayerData data;

    [SerializeField]
    private Image backplate;

    public void SetSign(SignType sign) => signSlot.sprite = data.GetSign(sign);

    public void SetStatus(PlayerStatus status)
    {
        switch (status)
        {
            case PlayerStatus.Winner:
                backplate.color = Color.green;
                break;
            case PlayerStatus.Loser:
                backplate.color = Color.red;
                break;
            case PlayerStatus.Playing:
                signSlot.sprite = null;
                backplate.color = Color.gray;
                break;
        }
    }
}
