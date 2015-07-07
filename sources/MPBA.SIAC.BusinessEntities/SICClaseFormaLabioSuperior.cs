using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.BusinessEntities
{


public partial class SICClaseFormaLabioSuperior{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private string _letra;
  private AutoresList _autoress = new AutoresList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the Id of the SICClaseFormaLabioSuperior.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public int Id { 
	  get{
			return _id;
	  }
	  set{
			_id = value;
	  }
	  }

/// <summary>
/// Gets or sets the Descripcion of the SICClaseFormaLabioSuperior.
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
/// Gets or sets the Letra of the SICClaseFormaLabioSuperior.
/// </summary>


public string Letra { 
	  get{
			return _letra;
	  }
	  set{
			_letra = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Autores" /> instances for the SICClaseFormaLabioSuperior.
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
