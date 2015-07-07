using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class PBClaseTatuaje{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private BusquedaTatuajesList _busquedaTatuajess = new BusquedaTatuajesList();
  private TatuajesPersonaList _tatuajesPersonas = new TatuajesPersonaList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the PBClaseTatuaje.
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
/// Gets or sets the descripcion of the PBClaseTatuaje.
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
///Gets or sets a collection of <see cref="BusquedaTatuajes" /> instances for the PBClaseTatuaje.
/// </summary>

	public BusquedaTatuajesList busquedaTatuajess {
	  get{
			return _busquedaTatuajess;
	  }
	  set{
			_busquedaTatuajess = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="TatuajesPersona" /> instances for the PBClaseTatuaje.
/// </summary>

	public TatuajesPersonaList tatuajesPersonas {
	  get{
			return _tatuajesPersonas;
	  }
	  set{
			_tatuajesPersonas = value;
	  }
	}

#endregion

}
}
