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
        ResultadoOperacion InsertarEmpresa(Empresa Empresa);
        ResultadoOperacion ObtenerListaEmpresas();
        ResultadoOperacion ObtenerEmpresaPaginado(int iPageNumber, string ExpresionFiltro, string _OrdenCampoDispSelect);


    }
}
