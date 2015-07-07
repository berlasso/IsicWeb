using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


public partial class Provincia{

#region "Private Variables"
  private int _id;
  private string _provincia;
  private LocalidadList _localidads = new LocalidadList();
  private PartidoList _partidos = new PartidoList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the Provincia.
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
/// Gets or sets the Provincia of the Provincia.
/// </summary>


public string provincia { 
	  get{
			return _provincia;
	  }
	  set{
			_provincia = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Localidad" /> instances for the Provincia.
/// </summary>

	public LocalidadList localidads {
	  get{
			return _localidads;
	  }
	  set{
			_localidads = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="Partido" /> instances for the Provincia.
/// </summary>

	public PartidoList partidos {
	  get{
			return _partidos;
	  }
	  set{
			_partidos = value;
	  }
	}

#endregion

}
}
