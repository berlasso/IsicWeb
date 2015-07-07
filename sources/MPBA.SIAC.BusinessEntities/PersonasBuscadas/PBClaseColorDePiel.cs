using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class PBClaseColorDePiel{

#region "Private Variables"
  private int _id;
  private string _descirpcion;
  private BusquedaList _busquedas = new BusquedaList();
  private PersonasDesaparecidasList _personasDesaparecidass = new PersonasDesaparecidasList();
  private PersonasHalladasList _personasHalladass = new PersonasHalladasList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the Id of the PBClaseColorDePiel.
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
/// Gets or sets the Descirpcion of the PBClaseColorDePiel.
/// </summary>


public string Descripcion { 
	  get{
			return _descirpcion;
	  }
	  set{
			_descirpcion = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Busqueda" /> instances for the PBClaseColorDePiel.
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
///Gets or sets a collection of <see cref="PersonasDesaparecidas" /> instances for the PBClaseColorDePiel.
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
///Gets or sets a collection of <see cref="PersonasHalladas" /> instances for the PBClaseColorDePiel.
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
