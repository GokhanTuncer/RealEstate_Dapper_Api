namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost"; //Host'u dinleyen
        public const string ValidIssuer = "https://localhost"; //Host'u Yayınlayan
        public const string Key = "RealEstate...04032025Asp.NetCore8001*/*";   //Secret Key -- Sadece Eğitim için burada
        public const int Expire = 5;

    }
}
