using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class PBClaseGrupoSanguineo{

#region "Private Variables"
  private int _id;
  private string _descripcion;
  private BusquedaGrupoSanguineoList _busquedaGrupoSanguineos = new BusquedaGrupoSanguineoList();
  private PersonasDesaparecidasList _personasDesaparecidass = new PersonasDesaparecidasList();
  private PersonasHalladasList _personasHalladass = new PersonasHalladasList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the Id of the PBClaseGrupoSanguineo.
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
/// Gets or sets the Descripcion of the PBClaseGrupoSanguineo.
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
///Gets or sets a collection of <see cref="BusquedaGrupoSanguineo" /> instances for the PBClaseGrupoSanguineo.
/// </summary>

	public BusquedaGrupoSanguineoList busquedaGrupoSanguineos {
	  get{
			return _busquedaGrupoSanguineos;
	  }
	  set{
			_busquedaGrupoSanguineos = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="PersonasDesaparecidas" /> instances for the PBClaseGrupoSanguineo.
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
///Gets or sets a collection of <see cref="PersonasHalladas" /> instances for the PBClaseGrupoSanguineo.
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
