using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.SIAC.BusinessEntities
{


public partial class ClaseTipoDNI{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private byte[] _version;
  private PersonasDesaparecidasList _personasDesaparecidass = new PersonasDesaparecidasList();
  private PersonasHalladasList _personasHalladass = new PersonasHalladasList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the ClaseTipoDNI.
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
/// Gets or sets the Descripcion of the ClaseTipoDNI.
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
/// Gets or sets the Version of the ClaseTipoDNI.
/// </summary>


public byte[] Version { 
	  get{
			return _version;
	  }
	  set{
			_version = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="PersonasDesaparecidas" /> instances for the ClaseTipoDNI.
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
///Gets or sets a collection of <see cref="PersonasHalladas" /> instances for the ClaseTipoDNI.
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
