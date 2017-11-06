using Microsoft.WindowsAzure.Storage.Table;
using ModernWallet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernWallet.Entities
{
    public class ConversationEntity:TableEntity
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        string Message { get; }
        ConversationType Type { get; }
    }
}
