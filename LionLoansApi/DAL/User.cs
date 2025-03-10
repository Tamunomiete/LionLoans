using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LionLoansApi.DAL
{
    public class User :IdentityUser
    {  // Personal Information
        [Required(ErrorMessage = "Last name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DOB { get; set; }

        public string Nationality { get; set; }

        // Identification Numbers
        public string? BVN { get; set; } // Bank Verification Number (optional)
        public string? NIN { get; set; } // National Identification Number (optional)

        // Authentication
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; } // Ensure phone number is required
        public bool IsEmailVerified { get; set; } = false; // Email verification status
        public bool IsPhoneVerified { get; set; } = false; // Phone verification status

        // Blockchain Integration
        public string? WalletAddress { get; set; } // User's blockchain wallet address (optional)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? BlockchainTransactionHash { get; set; } // Transaction hash for loan agreements
      
        
    }
}
