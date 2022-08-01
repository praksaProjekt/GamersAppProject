using System.ComponentModel.DataAnnotations;

namespace GamersApp.DTO
{
    public class FileModel
    {
        [Required]
        public int UserId { get; set; }
        public fileType FileType { get; set; }
        public string Filename { get; set; } = string.Empty;
        public string FileBase64 { get; set; } = string.Empty; 
    }

    public enum fileType
    {
        profilePicture = 0,
        profileVideo = 1,
        postPhoto = 2,
        postVideo = 3
    }
}
