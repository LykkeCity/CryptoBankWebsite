namespace ModernWallet.Domain
{
    public interface IConversation
    {
        string Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Message { get; }
        ConversationType Type { get; }
    }
}
