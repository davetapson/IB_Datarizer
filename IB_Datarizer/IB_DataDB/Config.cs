namespace IB_DataDB
{
    public static class Config
    {
        static string server = @"DAVE-LAPTOP\SQLEXPRESS";
        static string dataBase = "IB_Data";
        static string userId = "sa";
        static string password = "Makatini@1";

        public static string ConnectionString = "Server=" + server + 
                                         ";Database=" + dataBase +
                                         ";User Id=" + userId +
                                         ";Password=" + password + ";";
    }
}
