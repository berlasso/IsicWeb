using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseGanado{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private BienesSustraidosAnimalList _bienesSustraidosAnimals = new BienesSustraidosAnimalList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseGanado.
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
/// Gets or sets the descripcion of the NNClaseGanado.
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
///Gets or sets a collection of <see cref="BienesSustraidosAnimal" /> instances for the NNClaseGanado.
/// </summary>

	public BienesSustraidosAnimalList bienesSustraidosAnimals {
	  get{
			return _bienesSustraidosAnimals;
	  }
	  set{
			_bienesSustraidosAnimals = value;
	  }
	}

#endregion

}
}
