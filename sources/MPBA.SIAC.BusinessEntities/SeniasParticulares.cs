using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{
  public partial class SeniasParticulares
    {

#region "Private Variables"
  private int _id;
  private int? _idPersona;
  private int _idSeniaParticular;
  private int _idUbicacionSeniaParticular;
  private int _idTablaDestino;
  private string _descripcion;
  private int? _idAutor;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the SeniasParticulares.
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
/// Gets or sets the idPersona of the SeniasParticulares.
/// </summary>


public int? idPersona { 
	  get{
			return _idPersona;
	  }
	  set{
			_idPersona = value;
	  }
	  }

/// <summary>
/// Gets or sets the idSeniaParticular of the SeniasParticulares.
/// </summary>


public int idSeniaParticular { 
	  get{
			return _idSeniaParticular;
	  }
	  set{
			_idSeniaParticular = value;
	  }
	  }

/// <summary>
/// Gets or sets the idUbicacionSeniaParticular of the SeniasParticulares.
/// </summary>


public int idUbicacionSeniaParticular { 
	  get{
			return _idUbicacionSeniaParticular;
	  }
	  set{
			_idUbicacionSeniaParticular = value;
	  }
	  }

/// <summary>
/// Gets or sets the idTablaDestino of the SeniasParticulares.
/// </summary>


public int idTablaDestino { 
	  get{
			return _idTablaDestino;
	  }
	  set{
			_idTablaDestino = value;
	  }
	  }

/// <summary>
/// Gets or sets the descripcion of the SeniasParticulares.
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
/// Gets or sets the idAutor of the SeniasParticulares.
/// </summary>


public int? idAutor { 
	  get{
			return _idAutor;
	  }
	  set{
			_idAutor = value;
	  }
	  }


#endregion

}
}
