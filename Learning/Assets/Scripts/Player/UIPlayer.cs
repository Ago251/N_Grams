using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIPlayer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerNameLabel;

    [SerializeField]
    private Image signSlot;

    [SerializeField]
    private UIPlayerData data;

    public void SetSign(SignType sign) => signSlot.sprite = data.GetSign(sign);
}
