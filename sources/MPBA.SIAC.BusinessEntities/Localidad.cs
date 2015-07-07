using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.BusinessEntities
{


public partial class Localidad{

#region "Private Variables"
  private int _id;
  private string _localidad;
  private int _partido;
  private string _codigoPostal;
  private int _provincia;
  private DelitosList _delitoss = new DelitosList();


#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the Localidad.
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
/// Gets or sets the Localidad of the Localidad.
/// </summary>


public string localidad { 
	  get{
			return _localidad;
	  }
	  set{
			_localidad = value;
	  }
	  }

/// <summary>
/// Gets or sets the Partido of the Localidad.
/// </summary>


public int Partido { 
	  get{
			return _partido;
	  }
	  set{
			_partido = value;
	  }
	  }

/// <summary>
/// Gets or sets the CodigoPostal of the Localidad.
/// </summary>


public string CodigoPostal { 
	  get{
			return _codigoPostal;
	  }
	  set{
			_codigoPostal = value;
	  }
	  }

/// <summary>
/// Gets or sets the Provincia of the Localidad.
/// </summary>


public int Provincia { 
	  get{
			return _provincia;
	  }
	  set{
			_provincia = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Delitos" /> instances for the Localidad.
/// </summary>

	public DelitosList delitoss {
	  get{
			return _delitoss;
	  }
	  set{
			_delitoss = value;
	  }
	}

#endregion

}
}
