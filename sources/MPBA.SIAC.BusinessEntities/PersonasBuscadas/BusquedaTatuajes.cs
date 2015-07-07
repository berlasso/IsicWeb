using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class BusquedaTatuajes{

#region "Private Variables"
  private decimal _id;
  private decimal _idBusqueda;
  private int _idClaseTatuaje;
  private int _idUbicacionTatuaje;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaTatuajes.
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
/// Gets or sets the idBusqueda of the BusquedaTatuajes.
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
/// Gets or sets the IdClaseTatuaje of the BusquedaTatuajes.
/// </summary>


public int IdClaseTatuaje { 
	  get{
			return _idClaseTatuaje;
	  }
	  set{
			_idClaseTatuaje = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdUbicacionTatuaje of the BusquedaTatuajes.
/// </summary>


public int IdUbicacionTatuaje { 
	  get{
			return _idUbicacionTatuaje;
	  }
	  set{
			_idUbicacionTatuaje = value;
	  }
	  }


#endregion

}
}
