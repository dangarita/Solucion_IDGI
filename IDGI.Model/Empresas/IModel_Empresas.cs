using IDGI.Entities;
using Library.Utilidades;

namespace IDGI.Model
{
    public partial interface IModel
    {
        ResultadoOperacion ObtenerListaCiudad(int idDpto);
        ResultadoOperacion ObtenerListaDptos(int idPais);
        ResultadoOperacion ObtenerListaPais();
        ResultadoOperacion ObtenerListaSectores();
        ResultadoOperacion InsertarEmpresa(Tbl_Empresa Empresa);

    }
}
