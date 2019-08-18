namespace Storage
{
    public enum StorageDriverEnum
    {
        Azure,
        File
    }

    public static class StorageDriverEnumExtension
    {
        public static bool IsAzure(this StorageDriverEnum storageDriver)
        {
            return storageDriver == StorageDriverEnum.Azure;
        }

        public static bool IsFile(this StorageDriverEnum storageDriver)
        {
            return storageDriver == StorageDriverEnum.File;
        }
    }
}