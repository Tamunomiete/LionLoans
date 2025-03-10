namespace LionLoansApi.DAL
{
    public class SmsService
    {
        private readonly string _apiKey;
        private readonly string _sender;

        public SmsService(IConfiguration configuration)
        {
            _apiKey = configuration["TextLocal:ApiKey"];
            _sender = configuration["TextLocal:Sender"];
        }

        public async Task SendOTP(string phoneNumber, string otp)
        {
            using var httpClient = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("apikey", _apiKey),
            new KeyValuePair<string, string>("message", $"Your OTP is: {otp}"),
            new KeyValuePair<string, string>("sender", _sender),
            new KeyValuePair<string, string>("numbers", phoneNumber)
        });

            var response = await httpClient.PostAsync("https://api.textlocal.in/send/", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
