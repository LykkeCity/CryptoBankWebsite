using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernWallet.Domain
{
    public interface IConversationRepository
    {
        Task<IConversation> Create(IConversation conversation);
    }
}
