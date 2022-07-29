using GamersApp.DTO;
namespace GamersApp.Services.FileServices

{
    public class FileServices:IFileServices
    {
        private readonly DataContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileServices(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<String> UploadFileAsync(FileModel fileData)
        {
            try
            {
                var userProfile = await context.Profiles.FindAsync(fileData.UserId);
                if (userProfile == null)
                {
                    return null!;
                }
                var imagePath = generateToken(fileData);
                var base64 = fileData.FileBase64.Substring(fileData.FileBase64.IndexOf(",") + 1);
                await File.WriteAllBytesAsync(webHostEnvironment.WebRootPath + @"\content\" + imagePath, Convert.FromBase64String(base64));
                switch (fileData.FileType)
                {
                    case fileType.profilePicture:
                        userProfile.ProfilePictureURI = imagePath;
                        context.Profiles.Update(userProfile);
                        await context.SaveChangesAsync();
                        break;
                }
                return imagePath;
            }
            catch
            {
                return null;
            }
        }
         
        public string generateToken(FileModel file)
        {
            var tokenGenerated = (DateTime.Now.Ticks / 10000).ToString() + RandomString(6);
            FileInfo fi = new FileInfo(file.Filename);
            var filename = tokenGenerated + fi.Extension;
            return filename;
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
