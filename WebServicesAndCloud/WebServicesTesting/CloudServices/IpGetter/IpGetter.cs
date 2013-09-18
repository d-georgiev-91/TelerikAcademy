namespace IpGetter
{
    using System.Net.Http;

    public static class IpGetter
    {
        public static string GetPublicIPAddress()
        {
            HttpClient client = new HttpClient();
            var resposnse = client.GetAsync("http://icanhazip.com/").Result;
            string ipAddress = resposnse.Content.ReadAsStringAsync().Result;

            return ipAddress.Replace("\n", string.Empty);
        }
    }
}
