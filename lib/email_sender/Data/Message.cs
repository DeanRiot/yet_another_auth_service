namespace Email.Data
{
    public struct Message
    {
        /// <summary>
        /// Email Subject
        /// </summary>
        public string title;

        /// <summary>
        /// Email message text
        /// </summary>
        public string body;
        public Message(string title, string body)
        {
            this.title = title;
            this.body = body;
        }
        
    }
}
