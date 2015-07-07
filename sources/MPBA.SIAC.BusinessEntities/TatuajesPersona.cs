using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


public partial class TatuajesPersona{

#region "Private Variables"
  private int _id;
  private int _idPersona;
  private int _idTablaDestino;
  private int _idTatuaje;
  private int _idUbicacionTatuaje;
  private string _descripcion;
  private int _idAutor;
#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the TatuajesPersona.
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
/// Gets or sets the id of the idAutor.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public int idAutor
{
    get
    {
        return _idAutor;
    }
    set
    {
        _idAutor = value;
    }
}
/// <summary>
/// Gets or sets the idPersona of the TatuajesPersona.
/// </summary>


public int idPersona { 
	  get{
			return _idPersona;
	  }
	  set{
			_idPersona = value;
	  }
	  }

/// <summary>
/// Gets or sets the idTablaDestino of the TatuajesPersona.
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
/// Gets or sets the idTatuaje of the TatuajesPersona.
/// </summary>


public int idTatuaje { 
	  get{
			return _idTatuaje;
	  }
	  set{
			_idTatuaje = value;
	  }
	  }

/// <summary>
/// Gets or sets the idUbicacionTatuaje of the TatuajesPersona.
/// </summary>


public int idUbicacionTatuaje { 
	  get{
			return _idUbicacionTatuaje;
	  }
	  set{
			_idUbicacionTatuaje = value;
	  }
	  }
/// <summary>
/// Gets or sets the descripcion of the SeniasParticulares.
/// </summary>


public string descripcion
{
    get
    {
        return _descripcion;
    }
    set
    {
        _descripcion = value;
    }
}

#endregion

}
}
