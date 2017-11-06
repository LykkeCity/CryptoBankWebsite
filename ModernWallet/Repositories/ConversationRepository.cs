using AutoMapper;
using AzureStorage;
using ModernWallet.Domain;
using ModernWallet.DTOs;
using ModernWallet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernWallet.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly INoSQLTableStorage<ConversationEntity> _conversationTable;

        public ConversationRepository(INoSQLTableStorage<ConversationEntity> conversationTableStorage)
        {
            _conversationTable = conversationTableStorage;
        }

        public static string GetPartitionKey() => "Conversation";

        public static string GetRowKey(string id)
        {
            if (String.IsNullOrEmpty(id))
                return Guid.NewGuid().ToString();

            return id;
        }

        public async Task<IConversation> Create(IConversation conversation)
        {
            var entity = Mapper.Map<ConversationEntity>(conversation);

            entity.PartitionKey = GetPartitionKey();
            entity.RowKey = GetRowKey(conversation.Id);

            await _conversationTable.InsertAsync(entity);

            return Mapper.Map<ConversationDto>(entity);
        }
    }
}
