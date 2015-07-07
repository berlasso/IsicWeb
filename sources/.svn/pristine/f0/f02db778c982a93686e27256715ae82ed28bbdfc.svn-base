using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class PBClaseUbicacionSeniaPart{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private BusquedaList _busquedas = new BusquedaList();
  private PersonasDesaparecidasList _personasDesaparecidass = new PersonasDesaparecidasList();
  private PersonasHalladasList _personasHalladass = new PersonasHalladasList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the Id of the PBClaseUbicacionSeniaPart.
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
/// Gets or sets the Descripcion of the PBClaseUbicacionSeniaPart.
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
///Gets or sets a collection of <see cref="Busqueda" /> instances for the PBClaseUbicacionSeniaPart.
/// </summary>

	public BusquedaList busquedas {
	  get{
			return _busquedas;
	  }
	  set{
			_busquedas = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="PersonasDesaparecidas" /> instances for the PBClaseUbicacionSeniaPart.
/// </summary>

	public PersonasDesaparecidasList personasDesaparecidass {
	  get{
			return _personasDesaparecidass;
	  }
	  set{
			_personasDesaparecidass = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="PersonasHalladas" /> instances for the PBClaseUbicacionSeniaPart.
/// </summary>

	public PersonasHalladasList personasHalladass {
	  get{
			return _personasHalladass;
	  }
	  set{
			_personasHalladass = value;
	  }
	}

#endregion

}
}
