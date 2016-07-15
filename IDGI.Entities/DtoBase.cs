using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDGI.Entities
{
    [Serializable]
    public class DtoBase
    {
        private Int32 _TotalRegistros;
        private Int32 _Row;
        private string _Idioma;

        public string Idioma
        {
            get { return _Idioma; }
            set { _Idioma = value; }
        }

        /// <summary>
        /// Total Registro Consulta Total
        /// </summary>
        public Int32 TotalRegistros
        {
            get { return _TotalRegistros; }
            set { _TotalRegistros = value; }
        }

        /// <summary>
        /// Número de Registro
        /// </summary>
        public Int32 Row
        {
            get { return _Row; }
            set { _Row = value; }
        }
    }
}
