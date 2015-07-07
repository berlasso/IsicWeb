using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


public partial class Departamento{

#region "Private Variables"
  private int _id;
  private int _idCorte;
  private string _departamento;
  private string _descripcionCorta;
  private ComisariaList _comisarias = new ComisariaList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the Id of the Departamento.
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
/// Gets or sets the Id of the Departamento segun Corte/SIC.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public int IdCorte
{
    get
    {
        return _idCorte;
    }
    set
    {
        _idCorte = value;
    }
}

/// <summary>
/// Gets or sets the Departamento of the Departamento.
/// </summary>


public string departamento { 
	  get{
			return _departamento;
	  }
	  set{
			_departamento = value;
	  }
	  }

/// <summary>
/// Gets or sets the DescripcionCorta of the Departamento.
/// </summary>


public string DescripcionCorta { 
	  get{
			return _descripcionCorta;
	  }
	  set{
			_descripcionCorta = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="Comisaria" /> instances for the Departamento.
/// </summary>

	public ComisariaList comisarias {
	  get{
			return _comisarias;
	  }
	  set{
			_comisarias = value;
	  }
	}

#endregion

}
}
