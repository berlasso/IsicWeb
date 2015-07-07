using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class BusquedaCalvicie{

#region "Private Variables"
  private decimal _id;
  private decimal _idBusqueda;
  private int _idClaseCalvicie;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaCalvicie.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public decimal id { 
	  get{
			return _id;
	  }
	  set{
			_id = value;
	  }
	  }

/// <summary>
/// Gets or sets the idBusqueda of the BusquedaCalvicie.
/// </summary>


public decimal idBusqueda { 
	  get{
			return _idBusqueda;
	  }
	  set{
			_idBusqueda = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseCalvicie of the BusquedaCalvicie.
/// </summary>


public int idClaseCalvicie { 
	  get{
			return _idClaseCalvicie;
	  }
	  set{
			_idClaseCalvicie = value;
	  }
	  }


#endregion

}
}
