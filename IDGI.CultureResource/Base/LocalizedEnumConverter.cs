using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

namespace IDGI.CultureResource
{
    [Serializable]
    public class LocalizedEnumConverter : ResourceEnumConverter
    {
        public LocalizedEnumConverter(Type type)
            : base(type, new ResourceManager("IDGI.CultureResource." + "EnumResource", Assembly.GetExecutingAssembly()))
        {
        }
    }
}
