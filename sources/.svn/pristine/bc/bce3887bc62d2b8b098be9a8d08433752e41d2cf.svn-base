using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class Dientes{

#region "Private Variables"
  private int _id;
  private int _idPersona;
  private int _idDiente;
  private bool _existe;
  private DateTime?  _fechaUltimaModificacion = null;
  private string _usuarioUltimaModificacion;
  private bool _baja;
  private PersonasDesaparecidasList _personasDesaparecidass = new PersonasDesaparecidasList();
  private PersonasHalladasList _personasHalladass = new PersonasHalladasList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the Dientes.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public int Id { 
	  get{
			return _id;
	  }
	  set{
			_id = value;
	  }
	  }

/// <summary>
/// Gets or sets the idPersona of the Dientes.
/// </summary>


public int idPersona { 
	  get{
			return _idPersona;
	  }
	  set{
			_idPersona = value;
	  }
	  }

/// <summary>
/// Gets or sets the idDiente of the Dientes.
/// </summary>


public int idDiente { 
	  get{
			return _idDiente;
	  }
	  set{
			_idDiente = value;
	  }
	  }

/// <summary>
/// Gets or sets the Existe of the Dientes.
/// </summary>


public bool Existe { 
	  get{
			return _existe;
	  }
	  set{
			_existe = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaUltimaModificacion of the Dientes.
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
/// Gets or sets the UsuarioUltimaModificacion of the Dientes.
/// </summary>


public string UsuarioUltimaModificacion { 
	  get{
			return _usuarioUltimaModificacion;
	  }
	  set{
			_usuarioUltimaModificacion = value;
	  }
	  }

/// <summary>
/// Gets or sets the Baja of the Dientes.
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
///Gets or sets a collection of <see cref="PersonasDesaparecidas" /> instances for the Dientes.
/// </summary>

	public PersonasDesaparecidasList personasDesaparecidass {
	  get{
			return _personasDesaparecidass;
	  }
	  set{
			_personasDesaparecidass = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="PersonasHalladas" /> instances for the Dientes.
/// </summary>

	public PersonasHalladasList personasHalladass {
	  get{
			return _personasHalladass;
	  }
	  set{
			_personasHalladass = value;
	  }
	}

#endregion

}
}
