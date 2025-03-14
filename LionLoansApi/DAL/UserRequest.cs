using System.ComponentModel.DataAnnotations;

namespace LionLoansApi.DAL
{
    public class UserRequest
    {
        // Personal Information
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        
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


        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }
        // Blockchain Integration
        public string? WalletAddress { get; set; } // User's blockchain wallet address (optional)
    }

    
    }
