using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRobosDelitosSexualesLocalidades{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idLocalidad;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRobosDelitosSexualesLocalidades.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRobosDelitosSexualesLocalidades.
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
/// Gets or sets the idLocalidad of the BusquedaRobosDelitosSexualesLocalidades.
/// </summary>


public int idLocalidad { 
	  get{
			return _idLocalidad;
	  }
	  set{
			_idLocalidad = value;
	  }
	  }


#endregion

}
}
