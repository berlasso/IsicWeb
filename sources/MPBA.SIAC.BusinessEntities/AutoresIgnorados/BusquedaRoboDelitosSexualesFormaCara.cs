using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRoboDelitosSexualesFormaCara{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idFormaCara;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRoboDelitosSexualesFormaCara.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRoboDelitosSexualesFormaCara.
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
/// Gets or sets the idFormaCara of the BusquedaRoboDelitosSexualesFormaCara.
/// </summary>


public int idFormaCara { 
	  get{
			return _idFormaCara;
	  }
	  set{
			_idFormaCara = value;
	  }
	  }


#endregion

}
}
