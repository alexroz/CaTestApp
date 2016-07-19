using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System;

namespace WebJobOne
{
    public static class RetryStorage
    {
        public static void Retry()
        {
            string blobContainerName = "data";
            var storageAccount = new CloudStorageAccount(new StorageCredentials("name", "secretkey"), true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            blobClient.DefaultRequestOptions.RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 10);

            CloudBlobContainer blobContainer = blobClient.GetContainerReference(blobContainerName);
            bool containerExists = blobContainer.Exists();
            
            // ...
        }
    }
}
