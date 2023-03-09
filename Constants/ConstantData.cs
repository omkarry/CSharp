namespace WebAPI_upload_file.Constants
{
    public class ConstantData
    {
        public static readonly string[] AllowedFileTypes = { ".txt", ".jpg", ".png", ".xlsx" };
        public const long MinFileSize = 10485760; // 10 * 1024 * 1024 = 10 MB
    }
}
