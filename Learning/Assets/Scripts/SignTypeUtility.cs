public static class SignTypeUtility
{
    public static string GetShortString(this SignType signType)
    {
        switch (signType)
        {
            case SignType.Rock:
                return "R";
            case SignType.Paper:
                return "P";
            case SignType.Scissor:
                return "S";
            default:
                return string.Empty;
        }
    }


    public static SignType ConvertStringToType(char value)
    {
        switch (value)
        {
            case 'R':
                return SignType.Rock;
            case 'P':
                return SignType.Paper;
            case 'S':
                return SignType.Scissor;
            default:
                return SignType.Rock;
        }
    }
}
