namespace LionLoansApi.DAL
{
    public class UserService
    {
        public User MapToUser(UserRequest request)
        {
            return new User
            {
               UserName = request.FirstName, 
                Email = request.Email,
                FullName = $"{request.FirstName} {request.LastName}",
                Password = request.Password,
                DOB = request.DOB,
                Nationality = request.Nationality,
                BVN = request.BVN,
                NIN = request.NIN,

                WalletAddress = request.WalletAddress
            };
        }
    }
}

