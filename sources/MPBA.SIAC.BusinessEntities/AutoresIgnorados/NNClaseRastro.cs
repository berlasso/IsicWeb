using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseRastro{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private RastrosList _rastross = new RastrosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseRastro.
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
/// Gets or sets the descripcion of the NNClaseRastro.
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
///Gets or sets a collection of <see cref="Rastros" /> instances for the NNClaseRastro.
/// </summary>

	public RastrosList rastross {
	  get{
			return _rastross;
	  }
	  set{
			_rastross = value;
	  }
	}

#endregion

}
}
