using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRobosDelitosSexualesEstatura{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idestatura;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRobosDelitosSexualesEstatura.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRobosDelitosSexualesEstatura.
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
/// Gets or sets the idestatura of the BusquedaRobosDelitosSexualesEstatura.
/// </summary>


public int idestatura { 
	  get{
			return _idestatura;
	  }
	  set{
			_idestatura = value;
	  }
	  }


#endregion

}
}
