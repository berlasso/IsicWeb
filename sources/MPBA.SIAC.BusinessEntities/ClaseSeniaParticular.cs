using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


public partial class ClaseSeniaParticular{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private SeniasParticularesList _seniasParticularess = new SeniasParticularesList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the ClaseSeniaParticular.
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
/// Gets or sets the Descripcion of the ClaseSeniaParticular.
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
///Gets or sets a collection of <see cref="SeniasParticulares" /> instances for the ClaseSeniaParticular.
/// </summary>

	public SeniasParticularesList seniasParticularess {
	  get{
			return _seniasParticularess;
	  }
	  set{
			_seniasParticularess = value;
	  }
	}

#endregion

}
}
