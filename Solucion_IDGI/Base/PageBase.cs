// ===================================================
// Desarrollado Por		    : DIEGO ANDRÉS ANGARITA
// Fecha de Creación		: 20/08/2014
// Lenguaje Programación	: [C#]
// Producto o sistema	    : Smart Parking
// Empresa			        : e Global Tecnology
// Cliente			        : e Global Tecnology
// ===================================================
// Versión	Descripción
// [1.0.0.0]
// Clase BASE de informacion adicional para cada  
// pagina web
// ===================================================
// MODIFICACIONES:
// ===================================================
// Ver.	 Fecha		Autor – Empresa 	Descripción
// ---	 -------------	----------------------	----------------------------------------
// XX	dd/mm/aaaa	[Nombre Completo]	 [Razón del cambio realizado] 
// ===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Solucion_IDGI.Base
{
    [Serializable]
    public class PageBase : Page
    {
        #region Page Render Timing

        // Page render performance fields.
        private DateTime startTime = DateTime.Now;
        private TimeSpan renderTime;

        /// <summary>
        /// Sets and gets the page render starting time. This property 
        /// represents the Template Design Pattern.
        /// </summary>
        public DateTime StartTime
        {
            set { startTime = value; }
            get { return startTime; }
        }

        /// <summary>
        /// Gets page render time. This property is virtual therefore getting the 
        /// page performance is overridable by derived pages. This property 
        /// represents the Template Design Pattern.
        /// </summary>
        public virtual string PageRenderTime
        {
            get
            {
                renderTime = DateTime.Now - startTime;
                return renderTime.Seconds + "." + renderTime.Milliseconds + " segundos";
            }
        }

        #endregion
    }
}