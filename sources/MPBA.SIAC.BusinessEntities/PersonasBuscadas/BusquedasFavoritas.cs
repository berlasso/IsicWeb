using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class BusquedasFavoritas{

#region "Private Variables"
  private int _id;
  private int _idPersona;
  private int _idTablaDestino;
  private string _usuario;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedasFavoritas.
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
/// Gets or sets the idPersona of the BusquedasFavoritas.
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
/// Gets or sets the idTablaDestino of the BusquedasFavoritas.
/// </summary>


public int idTablaDestino { 
	  get{
			return _idTablaDestino;
	  }
	  set{
			_idTablaDestino = value;
	  }
	  }

/// <summary>
/// Gets or sets the Usuario of the BusquedasFavoritas.
/// </summary>


public string Usuario { 
	  get{
			return _usuario;
	  }
	  set{
			_usuario = value;
	  }
	  }


#endregion

}
}
