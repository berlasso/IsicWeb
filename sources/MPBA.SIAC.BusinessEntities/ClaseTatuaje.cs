using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.SIAC.BusinessEntities
{


public partial class ClaseTatuaje{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private BusquedaRobosDelitosSexualesTatuajesList _busquedaRobosDelitosSexualesTatuajess = new BusquedaRobosDelitosSexualesTatuajesList();
  private TatuajesPersonaList _tatuajesPersonas = new TatuajesPersonaList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the ClaseTatuaje.
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
/// Gets or sets the descripcion of the ClaseTatuaje.
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
///Gets or sets a collection of <see cref="BusquedaRobosDelitosSexualesTatuajes" /> instances for the ClaseTatuaje.
/// </summary>

	public BusquedaRobosDelitosSexualesTatuajesList busquedaRobosDelitosSexualesTatuajess {
	  get{
			return _busquedaRobosDelitosSexualesTatuajess;
	  }
	  set{
			_busquedaRobosDelitosSexualesTatuajess = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="TatuajesPersona" /> instances for the ClaseTatuaje.
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
