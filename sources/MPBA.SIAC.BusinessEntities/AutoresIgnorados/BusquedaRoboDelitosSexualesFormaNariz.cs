using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRoboDelitosSexualesFormaNariz{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idFormaNariz;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRoboDelitosSexualesFormaNariz.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRoboDelitosSexualesFormaNariz.
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
/// Gets or sets the idFormaNariz of the BusquedaRoboDelitosSexualesFormaNariz.
/// </summary>


public int idFormaNariz { 
	  get{
			return _idFormaNariz;
	  }
	  set{
			_idFormaNariz = value;
	  }
	  }


#endregion

}
}
