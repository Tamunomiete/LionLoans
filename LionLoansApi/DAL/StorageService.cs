namespace LionLoansApi.DAL
{
    public class StorageService
    {
        private readonly string _storagePath;

        public StorageService(IConfiguration configuration)
        {
            _storagePath = configuration["Storage:Path"] ?? "wwwroot/uploads";
            Directory.CreateDirectory(_storagePath); // Ensure the directory exists
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(_storagePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{fileName}"; // Return the file URL
        }

    }
}
