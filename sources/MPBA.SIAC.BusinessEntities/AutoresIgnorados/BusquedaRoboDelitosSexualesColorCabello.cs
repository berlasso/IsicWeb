using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRoboDelitosSexualesColorCabello{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idColorCabello;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRoboDelitosSexualesColorCabello.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRoboDelitosSexualesColorCabello.
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
/// Gets or sets the idColorCabello of the BusquedaRoboDelitosSexualesColorCabello.
/// </summary>


public int idColorCabello { 
	  get{
			return _idColorCabello;
	  }
	  set{
			_idColorCabello = value;
	  }
	  }


#endregion

}
}
