namespace IB_Data_DB
{
    public static class Config
    {
        static string server = @"DAVE-LAPTOP\SQLEXPRESS";
        static string dataBase = "IB_Data";
        static string userId = "sa";
        static string password = "makatini@1";

        public static string ConnectionString = "Server=" + server + 
                                         ";Database=" + dataBase +
                                         ";User Id=" + userId +
                                         ";Password=" + password + ";";
    }
}
