namespace Email.Data.Enums
{
    public struct Service
    {
        public static readonly string MAIL_RU = "smtp.mail.ru";
        public static readonly string YANDEX = "smtp.yandex.ru";
        
        [Obsolete("GMAIL service is not compatible for personal using")]
        public static readonly string GMAIL = "smtp.gmail.com";
    }
}
