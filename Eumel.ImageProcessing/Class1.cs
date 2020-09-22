using ExifLibrary;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace Eumel.ImageProcessing
{
    public class ExifWrapper : IDisposable
    {
        private ImageFile _eFile = null;

        public ExifWrapper(string file)
        {
            _eFile = ImageFile.FromFile(file);
        }

        public void AddDescription (string description, DateTime dat)
        {
            Console.WriteLine(_eFile.Properties.Get(ExifTag.DateTime).Value);
            Console.WriteLine(_eFile.Properties.Get(ExifTag.DateTimeOriginal).Value);

            _eFile.Properties.Set(ExifTag.ImageDescription, description);
            _eFile.Properties.Set(ExifTag.DateTime, dat);
        }

        public void SaveAs(string filename)
        {
            _eFile.Save(filename);
        }

        #region Dispose Pattern

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ExifWrapper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
