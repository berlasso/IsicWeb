using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.BusinessEntities
{


public partial class Comisaria{

#region "Private Variables"
  private int _id;
  private string _comisaria;
  private int _idDepartamento;
  private DelitosList _delitoss = new DelitosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the Comisaria.
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
/// Gets or sets the Comisaria of the Comisaria.
/// </summary>


public string comisaria { 
	  get{
			return _comisaria;
	  }
	  set{
			_comisaria = value;
	  }
	  }

/// <summary>
/// Gets or sets the idDepartamento of the Comisaria.
/// </summary>


public int idDepartamento { 
	  get{
			return _idDepartamento;
	  }
	  set{
			_idDepartamento = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Delitos" /> instances for the Comisaria.
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
