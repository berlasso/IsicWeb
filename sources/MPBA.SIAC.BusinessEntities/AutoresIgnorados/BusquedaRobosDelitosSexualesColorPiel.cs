using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRobosDelitosSexualesColorPiel{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idColorPiel;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRobosDelitosSexualesColorPiel.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRobosDelitosSexualesColorPiel.
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
/// Gets or sets the idColorPiel of the BusquedaRobosDelitosSexualesColorPiel.
/// </summary>


public int idColorPiel { 
	  get{
			return _idColorPiel;
	  }
	  set{
			_idColorPiel = value;
	  }
	  }


#endregion

}
}
