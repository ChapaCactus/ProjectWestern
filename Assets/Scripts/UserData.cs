namespace CCG
{
    public class UserData
    {
        public int ClearedStageNum { get; private set; } = 0;

        public int TotalCoin { get; private set; }
        public int AddTotalCoin(int add) => TotalCoin += add;

        public static UserData LoadUserData()
        {
            var data = new UserData();
            data.TotalCoin = 0;

            return data;
        }
    }
}