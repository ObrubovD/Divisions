namespace Divisions.Dal
{
    public static class BoolExtension
    {
        public static string BoolString(this bool status)
        {
            if (status == true)
                return "Активно";
            else
                return "Заблокировано";
        }
    }
}
