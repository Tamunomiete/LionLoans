using System.ComponentModel.DataAnnotations;

namespace LionLoansApi.DAL
{
    public class CorporateUserRequest
    {       
        [Required(ErrorMessage = "Company name is required.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Registration number is required.")]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Tax identification number is required.")]
        public string TaxIdentificationNumber { get; set; }

        [Required(ErrorMessage = "Business type is required.")]
        public string BusinessType { get; set; }

        [Required(ErrorMessage = "Industry is required.")]
        public string Industry { get; set; }

        [Required(ErrorMessage = "Date of incorporation is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfIncorporation { get; set; }

        [Required(ErrorMessage = "Country of operation is required.")]
        public string CountryOfOperation { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Url(ErrorMessage = "Invalid website URL.")]
        public string Website { get; set; }

        // Contact Information
        [Required(ErrorMessage = "Primary contact name is required.")]
        public string PrimaryContactName { get; set; }

        [Required(ErrorMessage = "Primary contact email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string PrimaryContactEmail { get; set; }

        [Required(ErrorMessage = "Primary contact phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PrimaryContactPhone { get; set; }

        public string SecondaryContactName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string SecondaryContactEmail { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string SecondaryContactPhone { get; set; }

        // Financial Information (Optional for Registration)
        public decimal? AnnualRevenue { get; set; }

        public string BankName { get; set; }

        public string BankAccountNumber { get; set; }

        public string BankBranchCode { get; set; }

        public decimal? AverageMonthlyIncome { get; set; }

        // Documents (Optional for Registration)
        public string RegistrationCertificateUrl { get; set; }

        public string TaxCertificateUrl { get; set; }

        public string BankStatementUrl { get; set; }

        public string AuditedFinancialsUrl { get; set; }

        public string BusinessPlanUrl { get; set; }

        public int? NumberOfEmployees { get; set; }

        public int? YearsInOperation { get; set; }

        public List<Reference> References { get; set; }
    }

    public class Reference
    {
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string ContactEmail { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string ContactPhone { get; set; }
    }

}

