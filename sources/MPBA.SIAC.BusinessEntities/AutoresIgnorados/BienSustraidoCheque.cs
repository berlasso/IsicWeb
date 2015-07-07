using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class BienSustraidoCheque{

#region "Private Variables"
  private int _id;
  private int _idNNBienSustraido;
  private string _banco;
  private float _monto;
  private string _nroSerie;
  private int _idTipoMoneda;
  private string _descripcionMoneda;
  private bool _baja;
  private string _idUsuarioUltimaModificacion;
  private DateTime?  _fechaUltimaModificacion = null;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BienSustraidoCheque.
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
/// Gets or sets the idNNBienSustraido of the BienSustraidoCheque.
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
/// Gets or sets the Banco of the BienSustraidoCheque.
/// </summary>


public string Banco { 
	  get{
			return _banco;
	  }
	  set{
			_banco = value;
	  }
	  }

/// <summary>
/// Gets or sets the monto of the BienSustraidoCheque.
/// </summary>


public float monto { 
	  get{
			return _monto;
	  }
	  set{
			_monto = value;
	  }
	  }

/// <summary>
/// Gets or sets the NroSerie of the BienSustraidoCheque.
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
/// Gets or sets the idTipoMoneda of the BienSustraidoCheque.
/// </summary>


public int idTipoMoneda { 
	  get{
			return _idTipoMoneda;
	  }
	  set{
			_idTipoMoneda = value;
	  }
	  }

/// <summary>
/// Gets or sets the descripcionMoneda of the BienSustraidoCheque.
/// </summary>


public string descripcionMoneda { 
	  get{
			return _descripcionMoneda;
	  }
	  set{
			_descripcionMoneda = value;
	  }
	  }

/// <summary>
/// Gets or sets the Baja of the BienSustraidoCheque.
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
/// Gets or sets the idUsuarioUltimaModificacion of the BienSustraidoCheque.
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
/// Gets or sets the FechaUltimaModificacion of the BienSustraidoCheque.
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
