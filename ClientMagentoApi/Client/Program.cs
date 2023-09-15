namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GetToken("admin", "admin123");
        }
        static void GetToken(string userName, string passWord)
        {
            var m2 = new ClientMagentoApi.Mg2Connector("http://192.168.104.60");
            string token = m2.GetAdminToken(userName, passWord); // Deben colocarse usuario y pass de magento

        }
    }
}
