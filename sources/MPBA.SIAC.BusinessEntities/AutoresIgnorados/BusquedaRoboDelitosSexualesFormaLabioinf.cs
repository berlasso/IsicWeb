using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BusquedaRoboDelitosSexualesFormaLabioinf{

#region "Private Variables"
  private int _id;
  private int _idBusquedaRoboDS;
  private int _idFormaLabioInferior;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRoboDelitosSexualesFormaLabioinf.
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
/// Gets or sets the idBusquedaRoboDS of the BusquedaRoboDelitosSexualesFormaLabioinf.
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
/// Gets or sets the idFormaLabioInferior of the BusquedaRoboDelitosSexualesFormaLabioinf.
/// </summary>


public int idFormaLabioInferior { 
	  get{
			return _idFormaLabioInferior;
	  }
	  set{
			_idFormaLabioInferior = value;
	  }
	  }


#endregion

}
}