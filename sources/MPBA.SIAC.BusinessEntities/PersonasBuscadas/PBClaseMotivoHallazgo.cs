using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class PBClaseMotivoHallazgo{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private BusquedaList _busquedas = new BusquedaList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the Id of the PBClaseMotivoHallazgo.
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
/// Gets or sets the Descripcion of the PBClaseMotivoHallazgo.
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
///Gets or sets a collection of <see cref="Busqueda" /> instances for the PBClaseMotivoHallazgo.
/// </summary>

	public BusquedaList busquedas {
	  get{
			return _busquedas;
	  }
	  set{
			_busquedas = value;
	  }
	}

#endregion

}
}
