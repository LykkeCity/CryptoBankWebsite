using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace CryptoBank
{
    public static class AzureStorageHelper
    {
        public static void Store(ITableEntity conversation)
        {
            CloudTableClient tableClient = new CloudTableClient(
               new Uri(ApplicationSettings.Configuration["Azure:Storage:Uri"]),
               new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                   ApplicationSettings.Configuration["Azure:Storage:Credentials:AccountName"],
                   ApplicationSettings.Configuration["Azure:Storage:Credentials:AccountKey"]));

            CloudTable table = tableClient.GetTableReference("Conversation");
            table.CreateIfNotExistsAsync();

            TableOperation insertOperation = TableOperation.Insert(conversation);

            table.ExecuteAsync(insertOperation);
        }
    }
}
