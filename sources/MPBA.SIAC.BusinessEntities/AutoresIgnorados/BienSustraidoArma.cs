using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BienSustraidoArma{

#region "Private Variables"
  private int _id;
  private int _idNNBienSustraido;
  private string _marca;
  private int _clase_tipo;
  private string _nroSerie;
  private int _diametro_calibre;
  private bool _baja;
  private string _idUsuarioUltimaModificacion;
  private DateTime?  _fechaUltimaModificacion = null;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BienSustraidoArma.
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
/// Gets or sets the idNNBienSustraido of the BienSustraidoArma.
/// </summary>


public int idNNBienSustraido { 
	  get{
			return _idNNBienSustraido;
	  }
	  set{
			_idNNBienSustraido = value;
	  }
	  }

/// <summary>
/// Gets or sets the Marca of the BienSustraidoArma.
/// </summary>


public string Marca { 
	  get{
			return _marca;
	  }
	  set{
			_marca = value;
	  }
	  }

/// <summary>
/// Gets or sets the clase_tipo of the BienSustraidoArma.
/// </summary>


public int clase_tipo { 
	  get{
			return _clase_tipo;
	  }
	  set{
			_clase_tipo = value;
	  }
	  }

/// <summary>
/// Gets or sets the NroSerie of the BienSustraidoArma.
/// </summary>


public string NroSerie { 
	  get{
			return _nroSerie;
	  }
	  set{
			_nroSerie = value;
	  }
	  }

/// <summary>
/// Gets or sets the diametro_calibre of the BienSustraidoArma.
/// </summary>


public int diametro_calibre { 
	  get{
			return _diametro_calibre;
	  }
	  set{
			_diametro_calibre = value;
	  }
	  }

/// <summary>
/// Gets or sets the Baja of the BienSustraidoArma.
/// </summary>


public bool Baja { 
	  get{
			return _baja;
	  }
	  set{
			_baja = value;
	  }
	  }

/// <summary>
/// Gets or sets the idUsuarioUltimaModificacion of the BienSustraidoArma.
/// </summary>


public string idUsuarioUltimaModificacion { 
	  get{
			return _idUsuarioUltimaModificacion;
	  }
	  set{
			_idUsuarioUltimaModificacion = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaUltimaModificacion of the BienSustraidoArma.
/// </summary>

	public DateTime? FechaUltimaModificacion { 
	  get{
			return _fechaUltimaModificacion;
	  }
	  set{
			_fechaUltimaModificacion = value;
	  }
	  }


#endregion

}
}
