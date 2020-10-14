using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.File;

namespace DynamicsConnector.Core.Providers
{
    public class FileStorageProvider
    {
        private readonly string StorageAccountName;
        private readonly string StorageAccountKey;
        private CloudStorageAccount storageAccount;
        public FileStorageProvider(string storageAccountName, string storageAccountKey)
        {
            this.StorageAccountName = storageAccountName;
            this.StorageAccountKey = storageAccountKey;

            storageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountName, storageAccountKey), false);
        }
        public string ReadFromFile(string shareName, string fileName)
        {             
            var share = storageAccount.CreateCloudFileClient().GetShareReference(shareName);

            var rootdir = share.GetRootDirectoryReference();
            var data = rootdir.GetFileReference(fileName).DownloadText();

            return data;
        }
    }
}
