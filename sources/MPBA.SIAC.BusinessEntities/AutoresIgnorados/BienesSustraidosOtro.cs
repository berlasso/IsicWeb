using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BienesSustraidosOtro{

#region "Private Variables"
  private int _id;
  private int _idNNBienSustraido;
  private string _marca;
  private int _cantidad;
  private string _nroSerie;
  private bool _baja;
  private string _idUsuarioUltimaModificacion;
  private DateTime?  _fechaUltimaModificacion = null;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BienesSustraidosOtro.
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
/// Gets or sets the idNNBienSustraido of the BienesSustraidosOtro.
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
/// Gets or sets the Marca of the BienesSustraidosOtro.
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
/// Gets or sets the Cantidad of the BienesSustraidosOtro.
/// </summary>


public int Cantidad { 
	  get{
			return _cantidad;
	  }
	  set{
			_cantidad = value;
	  }
	  }

/// <summary>
/// Gets or sets the NroSerie of the BienesSustraidosOtro.
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
/// Gets or sets the Baja of the BienesSustraidosOtro.
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
/// Gets or sets the idUsuarioUltimaModificacion of the BienesSustraidosOtro.
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
/// Gets or sets the FechaUltimaModificacion of the BienesSustraidosOtro.
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
