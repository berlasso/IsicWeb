using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.BusinessEntities
{


public partial class MarcaVehiculo{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private ModeloVehiculoList _modeloVehiculos = new ModeloVehiculoList();
  private VehiculosList _vehiculoss = new VehiculosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the MarcaVehiculo.
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
/// Gets or sets the Descripcion of the MarcaVehiculo.
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
///Gets or sets a collection of <see cref="ModeloVehiculo" /> instances for the MarcaVehiculo.
/// </summary>

	public ModeloVehiculoList modeloVehiculos {
	  get{
			return _modeloVehiculos;
	  }
	  set{
			_modeloVehiculos = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="Vehiculos" /> instances for the MarcaVehiculo.
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
