namespace WebAPI_upload_file.Constants
{
    public static class ResponseMessages
    {
        public const string DirectoryExist = "Directory already exist";
        public const string DirectoryCreate = "Directory created successfully";
        public const string CreateDirectoryError = "An error occurred while creating directory.";
        public const string FileTypeError = "File type not Allowed. Only txt/png/xls/jpg files are allowed.";
        public const string FileSizeError = "File size should be greater than 10MB";
        public const string FileExist = "File Already exist";
        public const string FileUpload = "File Uplaoaded successfully";
        public const string FileNotFoundToCopy = "File not found to copy";
        public const string FileUploadError = "An error occurred while uploading the file.";
        public const string FileNotFound = "File not found";
        public const string FileDelete = "File deleted successfully";
        public const string FileDeleteError = "Error while deleting file.";
    }
}
