using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseModoArriboHuida{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private bool _esVehiculo;
  private DelitosList _delitoss = new DelitosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseModoArriboHuida.
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
/// Gets or sets the descripcion of the NNClaseModoArriboHuida.
/// </summary>


public string descripcion { 
	  get{
			return _descripcion;
	  }
	  set{
			_descripcion = value;
	  }
	  }

/// <summary>
/// Gets or sets the esVehiculo of the NNClaseModoArriboHuida.
/// </summary>


public bool esVehiculo { 
	  get{
			return _esVehiculo;
	  }
	  set{
			_esVehiculo = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Delitos" /> instances for the NNClaseModoArriboHuida.
/// </summary>

	public DelitosList delitoss {
	  get{
			return _delitoss;
	  }
	  set{
			_delitoss = value;
	  }
	}

#endregion

}
}
