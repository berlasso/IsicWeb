using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class LugaresDeTrasladoDeVictimas{

#region "Private Variables"
  private int _id;
  private string _idCausa;
  private int _idDelito;
  private int _idLocalidad;
  private bool _baja;
  private DateTime?  _fechaUltimaModificacion = null;
  private string _usuarioUltimaModificacion;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the LugaresDeTrasladoDeVictimas.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public int id { 
	  get{
			return _id;
	  }
	  set{
			_id = value;
	  }
	  }

/// <summary>
/// Gets or sets the idCausa of the LugaresDeTrasladoDeVictimas.
/// </summary>


public string idCausa { 
	  get{
			return _idCausa;
	  }
	  set{
			_idCausa = value;
	  }
	  }

/// <summary>
/// Gets or sets the idDelito of the LugaresDeTrasladoDeVictimas.
/// </summary>


public int idDelito { 
	  get{
			return _idDelito;
	  }
	  set{
			_idDelito = value;
	  }
	  }

/// <summary>
/// Gets or sets the idLocalidad of the LugaresDeTrasladoDeVictimas.
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
/// Gets or sets the Baja of the LugaresDeTrasladoDeVictimas.
/// </summary>


public bool Baja { 
	  get{
			return _baja;
	  }
	  set{
			_baja = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaUltimaModificacion of the LugaresDeTrasladoDeVictimas.
/// </summary>

	public DateTime? FechaUltimaModificacion { 
	  get{
			return _fechaUltimaModificacion;
	  }
	  set{
			_fechaUltimaModificacion = value;
	  }
	  }

/// <summary>
/// Gets or sets the UsuarioUltimaModificacion of the LugaresDeTrasladoDeVictimas.
/// </summary>


public string UsuarioUltimaModificacion { 
	  get{
			return _usuarioUltimaModificacion;
	  }
	  set{
			_usuarioUltimaModificacion = value;
	  }
	  }


#endregion

}
}
