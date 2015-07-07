using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class NNClaseEdadAproximada{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private int _idSICEdad;

  private AutoresList _autoress = new AutoresList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the NNClaseEdadAproximada.
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
/// Gets or sets the descripcion of the NNClaseEdadAproximada.
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
/// Gets or sets the idSICEdad of the NNClaseEdadAproximada.
/// </summary>


public int idSICEdad
{
    get
    {
        return _idSICEdad;
    }
    set
    {
        _idSICEdad = value;
    }
}



/// <summary>
///Gets or sets a collection of <see cref="Autores" /> instances for the NNClaseEdadAproximada.
/// </summary>

	public AutoresList autoress {
	  get{
			return _autoress;
	  }
	  set{
			_autoress = value;
	  }
	}

#endregion

}
}
