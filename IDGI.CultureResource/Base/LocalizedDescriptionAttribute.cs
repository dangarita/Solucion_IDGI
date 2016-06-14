using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IDGI.CultureResource
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly string _resourceKey;
        private  ResourceManager _resource = new ResourceManager("IDGI.CultureResource." + "EnumDescription", Assembly.GetExecutingAssembly());
       

        public LocalizedDescriptionAttribute(string resourceKey) 
        {
            
            _resourceKey = resourceKey;
        }


        public override string Description
        {
            get
            {

                string sCulture = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                if (sCulture.Trim().ToUpper() != "ES" && sCulture.Trim().ToUpper() != "EN")
                {
                    sCulture = "en";
                }

                CultureInfo _CultureInfo = new CultureInfo(sCulture);
                string displayName = _resource.GetString(_resourceKey, _CultureInfo);

                return string.IsNullOrEmpty(displayName)
                    ? string.Format("[[{0}]]", _resourceKey)
                    : displayName;
            }
        }
    }
}
