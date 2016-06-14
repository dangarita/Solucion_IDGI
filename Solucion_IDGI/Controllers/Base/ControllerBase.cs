using IDGI.Model;
using System;
using System.Web;

namespace Solucion_IDGI.Controllers.Base
{
    [Serializable]
    public class ControllerBase
    {
        static ControllerBase()
        {

        }

        protected IModel _Model
        {
            get
            {
                if (HttpContext.Current.Session["_Model"] == null)
                    HttpContext.Current.Session["_Model"] = new IDGI.Model.Model();

                return HttpContext.Current.Session["_Model"] as IDGI.Model.Model;
            }
        }
    }
}
