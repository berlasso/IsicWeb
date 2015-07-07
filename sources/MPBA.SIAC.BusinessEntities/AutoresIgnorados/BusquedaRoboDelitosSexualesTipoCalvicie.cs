using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRoboDelitosSexualesTipoCalvicie{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idTipoCalvicie;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRoboDelitosSexualesTipoCalvicie.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRoboDelitosSexualesTipoCalvicie.
/// </summary>


public int idBusquedaRoboDS { 
	  get{
			return _idBusquedaRoboDS;
	  }
	  set{
			_idBusquedaRoboDS = value;
	  }
	  }

/// <summary>
/// Gets or sets the idTipoCalvicie of the BusquedaRoboDelitosSexualesTipoCalvicie.
/// </summary>


public int idTipoCalvicie { 
	  get{
			return _idTipoCalvicie;
	  }
	  set{
			_idTipoCalvicie = value;
	  }
	  }


#endregion

}
}
