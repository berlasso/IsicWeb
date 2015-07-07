using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.SIAC.BusinessEntities;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseArma{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private DelitosList _delitoss = new DelitosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseArma.
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
/// Gets or sets the descripcion of the NNClaseArma.
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
///Gets or sets a collection of <see cref="Delitos" /> instances for the NNClaseArma.
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
