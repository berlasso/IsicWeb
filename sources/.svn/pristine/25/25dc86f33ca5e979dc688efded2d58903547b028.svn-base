using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class PBClaseFoto{

#region "Private Variables"
  private int _id;
  private string _tipoFoto;
  private PBFotosList _fotoss = new PBFotosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the PBClaseFoto.
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
/// Gets or sets the tipoFoto of the PBClaseFoto.
/// </summary>


public string tipoFoto { 
	  get{
			return _tipoFoto;
	  }
	  set{
			_tipoFoto = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Fotos" /> instances for the PBClaseFoto.
/// </summary>

public PBFotosList fotoss
{
	  get{
			return _fotoss;
	  }
	  set{
			_fotoss = value;
	  }
	}

#endregion

}
}
