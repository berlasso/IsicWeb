using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


public partial class ClasePuntoGestion{

#region "Private Variables"
  private string _id;
  private string _descripcion;
  private string _descripcionCorta;
  private bool _permiteDenuncia;
  private int _ordenMuestra;
  private int _usuarioDelSistema;
  private int _idMinisterio;
  private string _idClaseCategoria;
  private int _usaFicha;
  private int _usaPapeles;
  private PuntoGestionList _puntoGestions = new PuntoGestionList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the ClasePuntoGestion.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public string id { 
	  get{
			return _id;
	  }
	  set{
			_id = value;
	  }
	  }

/// <summary>
/// Gets or sets the Descripcion of the ClasePuntoGestion.
/// </summary>


public string Descripcion { 
	  get{
			return _descripcion;
	  }
	  set{
			_descripcion = value;
	  }
	  }

/// <summary>
/// Gets or sets the DescripcionCorta of the ClasePuntoGestion.
/// </summary>


public string DescripcionCorta { 
	  get{
			return _descripcionCorta;
	  }
	  set{
			_descripcionCorta = value;
	  }
	  }

/// <summary>
/// Gets or sets the PermiteDenuncia of the ClasePuntoGestion.
/// </summary>


public bool PermiteDenuncia { 
	  get{
			return _permiteDenuncia;
	  }
	  set{
			_permiteDenuncia = value;
	  }
	  }

/// <summary>
/// Gets or sets the ordenMuestra of the ClasePuntoGestion.
/// </summary>


public int ordenMuestra { 
	  get{
			return _ordenMuestra;
	  }
	  set{
			_ordenMuestra = value;
	  }
	  }

/// <summary>
/// Gets or sets the UsuarioDelSistema of the ClasePuntoGestion.
/// </summary>


public int UsuarioDelSistema { 
	  get{
			return _usuarioDelSistema;
	  }
	  set{
			_usuarioDelSistema = value;
	  }
	  }

/// <summary>
/// Gets or sets the idMinisterio of the ClasePuntoGestion.
/// </summary>


public int idMinisterio { 
	  get{
			return _idMinisterio;
	  }
	  set{
			_idMinisterio = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseCategoria of the ClasePuntoGestion.
/// </summary>


public string idClaseCategoria { 
	  get{
			return _idClaseCategoria;
	  }
	  set{
			_idClaseCategoria = value;
	  }
	  }

/// <summary>
/// Gets or sets the UsaFicha of the ClasePuntoGestion.
/// </summary>


public int UsaFicha { 
	  get{
			return _usaFicha;
	  }
	  set{
			_usaFicha = value;
	  }
	  }

/// <summary>
/// Gets or sets the UsaPapeles of the ClasePuntoGestion.
/// </summary>


public int UsaPapeles { 
	  get{
			return _usaPapeles;
	  }
	  set{
			_usaPapeles = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="PuntoGestion" /> instances for the ClasePuntoGestion.
/// </summary>

	public PuntoGestionList puntoGestions {
	  get{
			return _puntoGestions;
	  }
	  set{
			_puntoGestions = value;
	  }
	}

#endregion

}
}
