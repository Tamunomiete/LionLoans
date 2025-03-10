namespace LionLoansApi.DAL
{
    public class VerificationService
    {

        private readonly Dictionary<string, string> _otpStore = new Dictionary<string, string>();

        public string GenerateOTP(string emailOrPhone)
        {
            var otp = new Random().Next(100000, 999999).ToString(); // 6-digit OTP
            _otpStore[emailOrPhone] = otp;
            return otp;
        }

        public bool ValidateOTP(string emailOrPhone, string otp)
        {
            if (_otpStore.TryGetValue(emailOrPhone, out var storedOtp))
            {
                return storedOtp == otp;
            }
            return false;
        }

    }
}
