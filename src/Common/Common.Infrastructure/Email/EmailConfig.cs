namespace Common.Infrastructure.Email
{
    public class EmailConfig
    {
        public string SiteName { get; set; }
        public string DisplayName { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EnableSsl { get; set; }
    }
}

