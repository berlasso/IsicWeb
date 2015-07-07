using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


public partial class PuntoGestion{

#region "Private Variables"
  private string _id;
  private string _idClasePuntoGestion;
  private string _descripcion;
  private int _numero;
  private bool _externo;
  private int _idPais;
  private int _idProvincia;
  private int _idDepartamento;
  private int _idLocalidad;
  private int _idPartido;
  private string _direccion;
  private string _telefonos;
  private string _descripcionCorta;
  private int _ordenMuestra;
  private string _titular;
  private int _idDescentralizada;
  private bool _activo;
  private string _email;
  private string _idPadrePG;
  private string _idTitular;
  private string _codi_Corte;
  private int  _area_Corte;
  private PersonalPoderJudicialList _personalPoderJudicials = new PersonalPoderJudicialList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the PuntoGestion.
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
/// Gets or sets the idClasePuntoGestion of the PuntoGestion.
/// </summary>


public string idClasePuntoGestion { 
	  get{
			return _idClasePuntoGestion;
	  }
	  set{
			_idClasePuntoGestion = value;
	  }
	  }

/// <summary>
/// Gets or sets the Descripcion of the PuntoGestion.
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
/// Gets or sets the Numero of the PuntoGestion.
/// </summary>


public int Numero { 
	  get{
			return _numero;
	  }
	  set{
			_numero = value;
	  }
	  }

/// <summary>
/// Gets or sets the Externo of the PuntoGestion.
/// </summary>


public bool Externo { 
	  get{
			return _externo;
	  }
	  set{
			_externo = value;
	  }
	  }

/// <summary>
/// Gets or sets the idPais of the PuntoGestion.
/// </summary>


public int idPais { 
	  get{
			return _idPais;
	  }
	  set{
			_idPais = value;
	  }
	  }

/// <summary>
/// Gets or sets the idProvincia of the PuntoGestion.
/// </summary>


public int idProvincia { 
	  get{
			return _idProvincia;
	  }
	  set{
			_idProvincia = value;
	  }
	  }

/// <summary>
/// Gets or sets the idDepartamento of the PuntoGestion.
/// </summary>


public int idDepartamento { 
	  get{
			return _idDepartamento;
	  }
	  set{
			_idDepartamento = value;
	  }
	  }

/// <summary>
/// Gets or sets the idLocalidad of the PuntoGestion.
/// </summary>


public int idLocalidad { 
	  get{
			return _idLocalidad;
	  }
	  set{
			_idLocalidad = value;
	  }
	  }

/// <summary>
/// Gets or sets the idPartido of the PuntoGestion.
/// </summary>


public int idPartido { 
	  get{
			return _idPartido;
	  }
	  set{
			_idPartido = value;
	  }
	  }

/// <summary>
/// Gets or sets the Direccion of the PuntoGestion.
/// </summary>


public string Direccion { 
	  get{
			return _direccion;
	  }
	  set{
			_direccion = value;
	  }
	  }

/// <summary>
/// Gets or sets the Telefonos of the PuntoGestion.
/// </summary>


public string Telefonos { 
	  get{
			return _telefonos;
	  }
	  set{
			_telefonos = value;
	  }
	  }

/// <summary>
/// Gets or sets the DescripcionCorta of the PuntoGestion.
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
/// Gets or sets the OrdenMuestra of the PuntoGestion.
/// </summary>


public int OrdenMuestra { 
	  get{
			return _ordenMuestra;
	  }
	  set{
			_ordenMuestra = value;
	  }
	  }

/// <summary>
/// Gets or sets the titular of the PuntoGestion.
/// </summary>


public string titular { 
	  get{
			return _titular;
	  }
	  set{
			_titular = value;
	  }
	  }

/// <summary>
/// Gets or sets the idDescentralizada of the PuntoGestion.
/// </summary>


public int idDescentralizada { 
	  get{
			return _idDescentralizada;
	  }
	  set{
			_idDescentralizada = value;
	  }
	  }

/// <summary>
/// Gets or sets the activo of the PuntoGestion.
/// </summary>


public bool activo { 
	  get{
			return _activo;
	  }
	  set{
			_activo = value;
	  }
	  }

/// <summary>
/// Gets or sets the Email of the PuntoGestion.
/// </summary>


public string Email { 
	  get{
			return _email;
	  }
	  set{
			_email = value;
	  }
	  }

/// <summary>
/// Gets or sets the idPadrePG of the PuntoGestion.
/// </summary>


public string idPadrePG { 
	  get{
			return _idPadrePG;
	  }
	  set{
			_idPadrePG = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdTitular of the PuntoGestion.
/// </summary>


public string IdTitular { 
	  get{
			return _idTitular;
	  }
	  set{
			_idTitular = value;
	  }
	  }

/// <summary>
/// Gets or sets the codi_Corte of the PuntoGestion.
/// </summary>


public string codi_Corte { 
	  get{
			return _codi_Corte;
	  }
	  set{
			_codi_Corte = value;
	  }
	  }

/// <summary>
/// Gets or sets the area_Corte of the PuntoGestion.
/// </summary>
	public int area_Corte { 
	  get{
			return _area_Corte;
	  }
	  set{
			_area_Corte = value;
	  }
	  }
	  
/// <summary>
///Gets or sets a collection of <see cref="PersonalPoderJudicial" /> instances for the PuntoGestion.
/// </summary>

	public PersonalPoderJudicialList personalPoderJudicials {
	  get{
			return _personalPoderJudicials;
	  }
	  set{
			_personalPoderJudicials = value;
	  }
	}

#endregion

}
}
