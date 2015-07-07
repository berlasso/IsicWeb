using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class BusquedaLongitudCabello{

#region "Private Variables"
  private decimal _id;
  private decimal _idBusqueda;
  private int _idClaseLongitudCabello;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaLongitudCabello.
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
/// Gets or sets the idBusqueda of the BusquedaLongitudCabello.
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
/// Gets or sets the idClaseLongitudCabello of the BusquedaLongitudCabello.
/// </summary>


public int idClaseLongitudCabello { 
	  get{
			return _idClaseLongitudCabello;
	  }
	  set{
			_idClaseLongitudCabello = value;
	  }
	  }


#endregion

}
}
