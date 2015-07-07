using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.BusinessEntities
{


public partial class ModeloVehiculo{

#region "Private Variables"
  private int _id;
  private string _Descripcion;
  private int _idMarcaVehiculo;
  private VehiculosList _vehiculoss = new VehiculosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the ModeloVehiculo.
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
/// Gets or sets the Descripcion of the ModeloVehiculo.
/// </summary>


public string Descripcion { 
	  get{
			return _Descripcion;
	  }
	  set{
			_Descripcion = value;
	  }
	  }

/// <summary>
/// Gets or sets the idMarcaVehiculo of the ModeloVehiculo.
/// </summary>


public int idMarcaVehiculo { 
	  get{
			return _idMarcaVehiculo;
	  }
	  set{
			_idMarcaVehiculo = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Vehiculos" /> instances for the ModeloVehiculo.
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
