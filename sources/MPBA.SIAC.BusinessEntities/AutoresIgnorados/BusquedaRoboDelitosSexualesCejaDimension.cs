using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRoboDelitosSexualesCejaDimension{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idDimensionCeja;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRoboDelitosSexualesCejaDimension.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRoboDelitosSexualesCejaDimension.
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
/// Gets or sets the idDimensionCeja of the BusquedaRoboDelitosSexualesCejaDimension.
/// </summary>


public int idDimensionCeja { 
	  get{
			return _idDimensionCeja;
	  }
	  set{
			_idDimensionCeja = value;
	  }
	  }


#endregion

}
}
