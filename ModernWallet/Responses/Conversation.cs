using ModernWallet.Domain;

namespace ModernWallet.Responses
{
    public class Conversation : IConversation
    {
        public string Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public ConversationType Type { get; set; }
    }
}
