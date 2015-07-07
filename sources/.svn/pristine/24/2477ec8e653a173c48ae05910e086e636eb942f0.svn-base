using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.BusinessEntities
{


public partial class Partido{

#region "Private Variables"
  private int _id;
  private string _partido;
  private int _idDepartamento;
  private int _idProvincia;
  private DelitosList _delitoss = new DelitosList();
  private LocalidadList _localidads = new LocalidadList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the Partido.
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
/// Gets or sets the Partido of the Partido.
/// </summary>


public string partido { 
	  get{
			return _partido;
	  }
	  set{
			_partido = value;
	  }
	  }

/// <summary>
/// Gets or sets the idDepartamento of the Partido.
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
/// Gets or sets the idProvincia of the Partido.
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
///Gets or sets a collection of <see cref="Delitos" /> instances for the Partido.
/// </summary>

	public DelitosList delitoss {
	  get{
			return _delitoss;
	  }
	  set{
			_delitoss = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="Localidad" /> instances for the Partido.
/// </summary>

	public LocalidadList localidads {
	  get{
			return _localidads;
	  }
	  set{
			_localidads = value;
	  }
	}

#endregion

}
}
