using LionLoansApi.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nethereum.JsonRpc.Client;


namespace LionLoansApi.Controllers
{

    public class UserManagementController : Controller
    {
        private readonly SQLDAL _sQLDAL;
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;
        private readonly StorageService _storageService;

        private readonly UserManager<User> _userManager;

        
        // Inject services via constructor
        public UserManagementController(
            EmailService emailService,
            StorageService storageService,
            SmsService smsService,
            UserManager<User> userManager
            )
        {
            _emailService = emailService;
            _smsService = smsService;
            _userManager = userManager;
            _storageService = storageService;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            // Validate the request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if email or phone number already exists
            var existingUserByEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingUserByEmail != null)
            {
                return BadRequest(new { Message = "Email is already registered." });
            }

            var existingUserByPhone = _dbContext.Users.FirstOrDefault(u => u.PhoneNumber == request.PhoneNumber);
            if (existingUserByPhone != null)
            {
                return BadRequest(new { Message = "Phone number is already registered." });
            }

            // Map UserRequest to User
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = $"{request.FirstName} {request.LastName}",
                DOB = request.DOB,
                Nationality = request.Nationality,
                BVN = request.BVN,
                NIN = request.NIN,
                WalletAddress = request.WalletAddress,
                PhoneNumber = request.PhoneNumber,
                IsEmailVerified = false,
                IsPhoneVerified = false
            };

            // Create the user
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                // Send OTP for email and phone verification
                var emailOtp = new Random().Next(100000, 999999).ToString();
                var phoneOtp = new Random().Next(100000, 999999).ToString();

                await _emailService.SendOTP(request.Email, emailOtp);
                await _smsService.SendOTP(request.PhoneNumber, phoneOtp);

                return Ok(new { Message = "User registered successfully. Please verify your email and phone number." });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("upload-kyc")]
        public async Task<IActionResult> UploadKYC([FromForm] KYCRequest request)
        {
            var documentUrl = await _storageService.UploadFile(request.Document);

            // Update user's KYC document URL
            var user = await _userManager.FindByIdAsync(request.UserId);
            user.KYCDocumentUrl = documentUrl;
            await _userManager.UpdateAsync(user);

            return Ok(new { Message = "KYC document uploaded successfully.", DocumentUrl = documentUrl });
        }

    }
}
