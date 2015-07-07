using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class BusquedaColorPiel{

#region "Private Variables"
  private decimal _id;
  private decimal _idBusqueda;
  private int _idClaseColorPiel;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaColorPiel.
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
/// Gets or sets the idBusqueda of the BusquedaColorPiel.
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
/// Gets or sets the idClaseColorPiel of the BusquedaColorPiel.
/// </summary>


public int idClaseColorPiel { 
	  get{
			return _idClaseColorPiel;
	  }
	  set{
			_idClaseColorPiel = value;
	  }
	  }


#endregion

}
}
