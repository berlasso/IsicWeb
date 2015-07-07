using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRoboDelitosSexualesRobustez{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idRobustez;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRoboDelitosSexualesRobustez.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRoboDelitosSexualesRobustez.
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
/// Gets or sets the idRobustez of the BusquedaRoboDelitosSexualesRobustez.
/// </summary>


public int idRobustez { 
	  get{
			return _idRobustez;
	  }
	  set{
			_idRobustez = value;
	  }
	  }


#endregion

}
}
