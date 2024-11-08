namespace HuquqApi.Settings
{
    public class JwtSetting
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public string SecretKey { get; set; }

    }
}
