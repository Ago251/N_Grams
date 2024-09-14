using UnityEngine;

public static class UIPlayerDataExtensions
{
    public static Sprite GetSign(this UIPlayerData data, SignType sign)
    {
        switch (sign)
        {
            case SignType.Rock:
                return data.Rock;
            case SignType.Paper:
                return data.Paper;
            case SignType.Scissor:
                return data.Scissor;
            default:
                return null;
        }
    }
}
