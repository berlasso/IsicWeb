using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseBienSustraido{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private string _tipo;
  private BienesSustraidosList _bienesSustraidoss = new BienesSustraidosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseBienSustraido.
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
/// Gets or sets the descripcion of the NNClaseBienSustraido.
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
/// Gets or sets the tipo of the NNClaseBienSustraido.
/// </summary>


public string tipo { 
	  get{
			return _tipo;
	  }
	  set{
			_tipo = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="BienesSustraidos" /> instances for the NNClaseBienSustraido.
/// </summary>

	public BienesSustraidosList bienesSustraidoss {
	  get{
			return _bienesSustraidoss;
	  }
	  set{
			_bienesSustraidoss = value;
	  }
	}

#endregion

}
}
