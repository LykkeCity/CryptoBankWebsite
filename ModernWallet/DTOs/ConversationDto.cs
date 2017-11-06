using ModernWallet.Domain;


namespace ModernWallet.DTOs
{
    public class ConversationDto : IConversation
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public ConversationType Type { get; set; }
    }
}
