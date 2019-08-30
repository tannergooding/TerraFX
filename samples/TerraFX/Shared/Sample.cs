// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using TerraFX.ApplicationModel;

namespace TerraFX.Samples
{
    public abstract class Sample : IDisposable
    {
        private static readonly Assembly s_win32Provider = Assembly.LoadFrom("TerraFX.Provider.Win32.dll");
        private static readonly Assembly s_x11Provider = Assembly.LoadFrom("TerraFX.Provider.X11.dll");

        private readonly string _name;
        private readonly Assembly[] _compositionAssemblies;

        protected Sample(string name, Assembly[] compositionAssemblies)
        {
            _name = name;
            _compositionAssemblies = new Assembly[compositionAssemblies.Length + 1];

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _compositionAssemblies[0] = s_win32Provider;
            }
            else
            {
                _compositionAssemblies[0] = s_x11Provider;
            }

            Array.Copy(compositionAssemblies, 0, _compositionAssemblies, 1, compositionAssemblies.Length);
        }

        ~Sample()
        {
            Dispose(isDisposing: false);
        }

        public Assembly[] CompositionAssemblies
        {
            get
            {
                return _compositionAssemblies;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public abstract void OnIdle(object? sender, ApplicationIdleEventArgs eventArgs);

        public void Dispose()
        {
            Dispose(isDisposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
        }
    }
}
