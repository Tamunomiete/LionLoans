using LionLoansApi.DAL;
using Microsoft.AspNetCore.Mvc;

namespace LionLoansApi.Controllers
{
    public class VerificationController : Controller
    {
        private readonly SmsService _smsService;

        public VerificationController(SmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOTP([FromBody] SendOTPRequest request)
        {
            var otp = new Random().Next(100000, 999999).ToString(); // Generate a 6-digit OTP
            await _smsService.SendOTP(request.PhoneNumber, otp);

            return Ok(new { Message = "OTP sent successfully." });
        }

        public class SendOTPRequest
        {
            public string PhoneNumber { get; set; }
        }
    }
}
