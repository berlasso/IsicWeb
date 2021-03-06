using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class BusquedaColorTenido{

#region "Private Variables"
  private decimal _id;
  private decimal _idBusqueda;
  private int _idClaseColorTenido;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaColorTenido.
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
/// Gets or sets the idBusqueda of the BusquedaColorTenido.
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
/// Gets or sets the idClaseColorTenido of the BusquedaColorTenido.
/// </summary>


public int idClaseColorTenido { 
	  get{
			return _idClaseColorTenido;
	  }
	  set{
			_idClaseColorTenido = value;
	  }
	  }


#endregion

}
}
