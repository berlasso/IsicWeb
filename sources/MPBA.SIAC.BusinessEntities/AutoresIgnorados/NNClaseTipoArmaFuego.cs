using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseTipoArmaFuego{

#region "Private Variables"
  private int _id;
  private string _descripcion;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseTipoArmaFuego.
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
/// Gets or sets the descripcion of the NNClaseTipoArmaFuego.
/// </summary>


public string descripcion { 
	  get{
			return _descripcion;
	  }
	  set{
			_descripcion = value;
	  }
	  }


#endregion

}
}
