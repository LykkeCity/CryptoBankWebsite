using AutoMapper;
using ModernWallet.Domain;
using ModernWallet.Responses;

namespace ModernWallet
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IConversation, Conversation>();
        }
    }
}
