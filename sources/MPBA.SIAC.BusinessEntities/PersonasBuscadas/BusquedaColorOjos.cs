using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class BusquedaColorOjos{

#region "Private Variables"
  private decimal _id;
  private decimal _idBusqueda;
  private int _idClaseColorOjos;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaColorOjos.
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
/// Gets or sets the idBusqueda of the BusquedaColorOjos.
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
/// Gets or sets the idClaseColorOjos of the BusquedaColorOjos.
/// </summary>


public int idClaseColorOjos { 
	  get{
			return _idClaseColorOjos;
	  }
	  set{
			_idClaseColorOjos = value;
	  }
	  }


#endregion

}
}
