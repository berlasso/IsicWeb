using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseRubro{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private int _idClaseLugar;
  private DelitosList _delitoss = new DelitosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseRubro.
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
/// Gets or sets the descripcion of the NNClaseRubro.
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
/// Gets or sets the idClaseLugar of the NNClaseRubro.
/// </summary>


public int idClaseLugar { 
	  get{
			return _idClaseLugar;
	  }
	  set{
			_idClaseLugar = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Delitos" /> instances for the NNClaseRubro.
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
