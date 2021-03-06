﻿using Microsoft.Azure.WebJobs;
using System.IO;

namespace WebJobOne
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }

        public static void CopyFile(
            [BlobTrigger("files/{name}.txt")] Stream input,
            [Blob("copies/{name}_copy.txt", System.IO.FileAccess.Write)] Stream output)
        {
            input.CopyTo(output);
        }
    }
}
