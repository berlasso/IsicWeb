using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRoboDelitosSexualesCejaForma{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idFormaCeja;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRoboDelitosSexualesCejaForma.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRoboDelitosSexualesCejaForma.
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
/// Gets or sets the idFormaCeja of the BusquedaRoboDelitosSexualesCejaForma.
/// </summary>


public int idFormaCeja { 
	  get{
			return _idFormaCeja;
	  }
	  set{
			_idFormaCeja = value;
	  }
	  }


#endregion

}
}
