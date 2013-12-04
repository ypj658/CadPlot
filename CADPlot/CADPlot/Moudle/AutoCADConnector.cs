using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AutoCAD;

namespace CADPlot.Moudle
{
    public class AutoCadConnector : IDisposable
    {
        private readonly AcadApplication _application;

        private readonly bool _initialized;

        private bool _disposed;

        public AutoCadConnector()
        {
            try
            {
                // Upon creation, attempt to retrieve running instance

                _application = (AcadApplication) Marshal.GetActiveObject("AutoCAD.Application.16");
            }

            catch (COMException)
            {
                // Create an instance and set flag to indicate this

                _application = new AcadApplicationClass();

                _initialized = true;
            }
            catch
            {
                MessageBox.Show(@"调用CAD程序出错！", @"批量打印", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // If the user doesn't call Dispose, the

        // garbage collector will upon destruction


        public AcadApplication Application
        {
            get
            {
                // Return our internal instance of AutoCAD

                return _application;
            }
        }


        // This is the user-callable version of Dispose.

        // It calls our internal version and removes the

        // object from the garbage collector's queue.

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~AutoCadConnector()
        {
            Dispose(false);
        }


        // This version of Dispose gets called by our

        // destructor.

        protected virtual void Dispose(bool disposing)
        {
            // If we created our AutoCAD instance, call its

            // Quit method to avoid leaking memory.

            try
            {
                if (!_disposed && _initialized)

                    _application.Quit();
            }
            catch
            { }


            _disposed = true;
        }
    }
}