namespace MagnetApi.DTO
    {
    public class UpdatePasswordDto
        {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        }
    }
