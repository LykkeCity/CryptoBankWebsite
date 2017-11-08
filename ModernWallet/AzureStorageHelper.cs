using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace ModernWallet
{
    public static class AzureStorageHelper
    {
        public static void Store(ITableEntity conversation)
        {
            CloudTableClient tableClient = new CloudTableClient(
               new Uri("https://lkedevmain.table.core.windows.net/"),
               new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("lkedevmain", "l0W0CaoNiRZQIqJ536sIScSV5fUuQmPYRQYohj/UjO7+ZVdpUiEsRLtQMxD+1szNuAeJ351ndkOsdWFzWBXmdw=="));

            CloudTable table = tableClient.GetTableReference("Conversation");
            table.CreateIfNotExistsAsync();

            TableOperation insertOperation = TableOperation.Insert(conversation);

            table.ExecuteAsync(insertOperation);
        }
    }
}
