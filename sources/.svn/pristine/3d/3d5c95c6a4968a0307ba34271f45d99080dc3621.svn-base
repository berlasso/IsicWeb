using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseLugar{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private DelitosList _delitoss = new DelitosList();
  private NNClaseRubroList _nNClaseRubros = new NNClaseRubroList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseLugar.
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
/// Gets or sets the descripcion of the NNClaseLugar.
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
///Gets or sets a collection of <see cref="Delitos" /> instances for the NNClaseLugar.
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
///Gets or sets a collection of <see cref="NNClaseRubro" /> instances for the NNClaseLugar.
/// </summary>

	public NNClaseRubroList nNClaseRubros {
	  get{
			return _nNClaseRubros;
	  }
	  set{
			_nNClaseRubros = value;
	  }
	}

#endregion

}
}
