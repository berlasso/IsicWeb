using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class BusquedaAspectoCabello{

#region "Private Variables"
  private decimal _id;
  private decimal _idBusqueda;
  private int _idAspectoCabello;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaAspectoCabello.
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
/// Gets or sets the idBusqueda of the BusquedaAspectoCabello.
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
/// Gets or sets the idAspectoCabello of the BusquedaAspectoCabello.
/// </summary>


public int idAspectoCabello { 
	  get{
			return _idAspectoCabello;
	  }
	  set{
			_idAspectoCabello = value;
	  }
	  }


#endregion

}
}
