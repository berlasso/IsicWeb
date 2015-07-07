using System;
using System.ComponentModel;
using System.Diagnostics;



namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseBoolean{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private DelitosList _delitoss = new DelitosList();
  private VehiculosList _vehiculoss = new VehiculosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the Id of the NNClaseBoolean.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public int Id { 
	  get{
			return _id;
	  }
	  set{
			_id = value;
	  }
	  }

/// <summary>
/// Gets or sets the Descripcion of the NNClaseBoolean.
/// </summary>


public string Descripcion { 
	  get{
			return _descripcion;
	  }
	  set{
			_descripcion = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Delitos" /> instances for the NNClaseBoolean.
/// </summary>

	public DelitosList delitoss {
	  get{
			return _delitoss;
	  }
	  set{
			_delitoss = value;
	  }
	}

/// <summary>
///Gets or sets a collection of <see cref="Vehiculos" /> instances for the NNClaseBoolean.
/// </summary>

	public VehiculosList vehiculoss {
	  get{
			return _vehiculoss;
	  }
	  set{
			_vehiculoss = value;
	  }
	}

#endregion

}
}
