using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace Nibo.OfxReader.Website.DependencyInjection
{
    public class Kernel
    {
        private static readonly object _instanceLoker = new Object();
        private static volatile StandardKernel _instance;

        [ExcludeFromCodeCoverage]
        private Kernel()
        {
        }

        public static StandardKernel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLoker)
                    {
                        if (_instance == null)
                        {
                            _instance = new StandardKernel();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}