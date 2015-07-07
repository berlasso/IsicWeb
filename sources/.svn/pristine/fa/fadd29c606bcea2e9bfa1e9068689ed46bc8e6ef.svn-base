using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


public partial class ClasePersona{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private PersonaList _personas = new PersonaList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the ClasePersona.
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
/// Gets or sets the descripcion of the ClasePersona.
/// </summary>


public string descripcion { 
	  get{
			return _descripcion;
	  }
	  set{
			_descripcion = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Persona" /> instances for the ClasePersona.
/// </summary>

	public PersonaList personas {
	  get{
			return _personas;
	  }
	  set{
			_personas = value;
	  }
	}

#endregion

}
}
