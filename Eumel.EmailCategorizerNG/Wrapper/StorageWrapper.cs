using System;
using Eumel.EmailCategorizer.Core;
using Microsoft.Office.Interop.Outlook;

namespace Eumel.EmailCategorizerNG.Wrapper
{
    public class StorageWrapper : IEumelStorageItem
    {
        public const string CategorizerDataStore = "Eumel.EmailCategorizer";
        private readonly StorageItem _storage;

        public StorageWrapper(StorageItem storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public string this[string name]
        {
            get
            {
                if (_storage.Size != 0) return _storage.UserProperties[name].Value;

                // empty init
                _storage.UserProperties.Add(name, OlUserPropertyType.olText);
                _storage.UserProperties[name].Value = string.Empty;
                _storage.Save();

                return _storage.UserProperties[name].Value;
            }
            set
            {
                _storage.UserProperties[name].Value = value;
                _storage.Save();
            }
        }
    }
}