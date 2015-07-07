using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


public partial class Persona{

#region "Private Variables"
  private int _id;
  private string _nombre;
  private string _apellido;
  private string _apodo;
  private string _nombreCompleto;
  private int _idTipoDNI;
  private int _documentoNumero;
  private string _sexo;
  private string _direccion;
  private string _telefono;
  private string _eMail;
  private DateTime?  _fechaNacimiento = null;
  private int _localidad;
  private int _partido;
  private int _idProvincia;
  private string _idCreador;
  private string _colegio;
  private string _tomo;
  private string _folio;
  private DateTime?  _fechaAlta = null;
  private int _personalPoderJudicial;
  private bool _activo;
  private bool _muerto;
  private int _idEstadoCivil;
  private string _profesion;
  private string _lugarNacimiento;
  private int _idNacionalidad;
  private string _padre;
  private string _madre;
  private string _profesionPadre;
  private string _profesionMadre;
  private string _conyuge;
  private string _numeroIRNR;
  private string _numeroIDAPMS;
  private string _defensorParticular;
  private int  _edad;
  private int _idEstadoCivilMaterno;
  private int _idEstadoCivilPaterno;
  private int _idTipoPersona;

#endregion

#region "Public Properties"

  /// <summary>
  /// Gets or sets the id of the Persona.
  /// </summary>


  public int id
  {
      get
      {
          return _id;
      }
      set
      {
          _id = value;
      }
  }





/// <summary>
/// Gets or sets the Nombre of the Persona.
/// </summary>


public string Nombre { 
	  get{
			return _nombre;
	  }
	  set{
			_nombre = value;
	  }
	  }

/// <summary>
/// Gets or sets the Apellido of the Persona.
/// </summary>


public string Apellido { 
	  get{
			return _apellido;
	  }
	  set{
			_apellido = value;
	  }
	  }

/// <summary>
/// Gets or sets the Apodo of the Persona.
/// </summary>


public string Apodo { 
	  get{
			return _apodo;
	  }
	  set{
			_apodo = value;
	  }
	  }

/// <summary>
/// Gets or sets the Apodo of the Persona.
/// </summary>


public string NombreCompleto
{
    get
    {
        return _nombreCompleto;
    }
    set
    {
        _nombreCompleto = value;
    }
}

/// <summary>
/// Gets or sets the idTipoDNI of the Persona.
/// </summary>


public int idTipoDNI { 
	  get{
			return _idTipoDNI;
	  }
	  set{
			_idTipoDNI = value;
	  }
	  }

/// <summary>
/// Gets or sets the DocumentoNumero of the Persona.
/// </summary>


public int DocumentoNumero { 
	  get{
			return _documentoNumero;
	  }
	  set{
			_documentoNumero = value;
	  }
	  }

/// <summary>
/// Gets or sets the Sexo of the Persona.
/// </summary>


public string Sexo { 
	  get{
			return _sexo;
	  }
	  set{
			_sexo = value;
	  }
	  }

/// <summary>
/// Gets or sets the Direccion of the Persona.
/// </summary>


public string Direccion { 
	  get{
			return _direccion;
	  }
	  set{
			_direccion = value;
	  }
	  }

/// <summary>
/// Gets or sets the Telefono of the Persona.
/// </summary>


public string Telefono { 
	  get{
			return _telefono;
	  }
	  set{
			_telefono = value;
	  }
	  }

/// <summary>
/// Gets or sets the EMail of the Persona.
/// </summary>


public string EMail { 
	  get{
			return _eMail;
	  }
	  set{
			_eMail = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaNacimiento of the Persona.
/// </summary>

	public DateTime? FechaNacimiento { 
	  get{
			return _fechaNacimiento;
	  }
	  set{
			_fechaNacimiento = value;
	  }
	  }

/// <summary>
/// Gets or sets the Localidad of the Persona.
/// </summary>


public int Localidad { 
	  get{
			return _localidad;
	  }
	  set{
			_localidad = value;
	  }
	  }

/// <summary>
/// Gets or sets the Partido of the Persona.
/// </summary>


public int Partido { 
	  get{
			return _partido;
	  }
	  set{
			_partido = value;
	  }
	  }

/// <summary>
/// Gets or sets the idProvincia of the Persona.
/// </summary>


public int idProvincia { 
	  get{
			return _idProvincia;
	  }
	  set{
			_idProvincia = value;
	  }
	  }

/// <summary>
/// Gets or sets the idCreador of the Persona.
/// </summary>


public string idCreador { 
	  get{
			return _idCreador;
	  }
	  set{
			_idCreador = value;
	  }
	  }

/// <summary>
/// Gets or sets the colegio of the Persona.
/// </summary>


public string colegio { 
	  get{
			return _colegio;
	  }
	  set{
			_colegio = value;
	  }
	  }

/// <summary>
/// Gets or sets the Tomo of the Persona.
/// </summary>


public string Tomo { 
	  get{
			return _tomo;
	  }
	  set{
			_tomo = value;
	  }
	  }

/// <summary>
/// Gets or sets the Folio of the Persona.
/// </summary>


public string Folio { 
	  get{
			return _folio;
	  }
	  set{
			_folio = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaAlta of the Persona.
/// </summary>

	public DateTime? FechaAlta { 
	  get{
			return _fechaAlta;
	  }
	  set{
			_fechaAlta = value;
	  }
	  }

/// <summary>
/// Gets or sets the PersonalPoderJudicial of the Persona.
/// </summary>


public int PersonalPoderJudicial { 
	  get{
			return _personalPoderJudicial;
	  }
	  set{
			_personalPoderJudicial = value;
	  }
	  }

/// <summary>
/// Gets or sets the activo of the Persona.
/// </summary>


public bool activo { 
	  get{
			return _activo;
	  }
	  set{
			_activo = value;
	  }
	  }

/// <summary>
/// Gets or sets the Muerto of the Persona.
/// </summary>


public bool Muerto { 
	  get{
			return _muerto;
	  }
	  set{
			_muerto = value;
	  }
	  }

/// <summary>
/// Gets or sets the idEstadoCivil of the Persona.
/// </summary>


public int idEstadoCivil { 
	  get{
			return _idEstadoCivil;
	  }
	  set{
			_idEstadoCivil = value;
	  }
	  }

/// <summary>
/// Gets or sets the profesion of the Persona.
/// </summary>


public string profesion { 
	  get{
			return _profesion;
	  }
	  set{
			_profesion = value;
	  }
	  }

/// <summary>
/// Gets or sets the LugarNacimiento of the Persona.
/// </summary>


public string LugarNacimiento { 
	  get{
			return _lugarNacimiento;
	  }
	  set{
			_lugarNacimiento = value;
	  }
	  }

/// <summary>
/// Gets or sets the idNacionalidad of the Persona.
/// </summary>


public int idNacionalidad { 
	  get{
			return _idNacionalidad;
	  }
	  set{
			_idNacionalidad = value;
	  }
	  }

/// <summary>
/// Gets or sets the Padre of the Persona.
/// </summary>


public string Padre { 
	  get{
			return _padre;
	  }
	  set{
			_padre = value;
	  }
	  }

/// <summary>
/// Gets or sets the Madre of the Persona.
/// </summary>


public string Madre { 
	  get{
			return _madre;
	  }
	  set{
			_madre = value;
	  }
	  }

/// <summary>
/// Gets or sets the ProfesionPadre of the Persona.
/// </summary>


public string ProfesionPadre { 
	  get{
			return _profesionPadre;
	  }
	  set{
			_profesionPadre = value;
	  }
	  }

/// <summary>
/// Gets or sets the ProfesionMadre of the Persona.
/// </summary>


public string ProfesionMadre { 
	  get{
			return _profesionMadre;
	  }
	  set{
			_profesionMadre = value;
	  }
	  }

/// <summary>
/// Gets or sets the Conyuge of the Persona.
/// </summary>


public string Conyuge { 
	  get{
			return _conyuge;
	  }
	  set{
			_conyuge = value;
	  }
	  }

/// <summary>
/// Gets or sets the NumeroIRNR of the Persona.
/// </summary>


public string NumeroIRNR { 
	  get{
			return _numeroIRNR;
	  }
	  set{
			_numeroIRNR = value;
	  }
	  }

/// <summary>
/// Gets or sets the NumeroIDAPMS of the Persona.
/// </summary>


public string NumeroIDAPMS { 
	  get{
			return _numeroIDAPMS;
	  }
	  set{
			_numeroIDAPMS = value;
	  }
	  }

/// <summary>
/// Gets or sets the DefensorParticular of the Persona.
/// </summary>


public string DefensorParticular { 
	  get{
			return _defensorParticular;
	  }
	  set{
			_defensorParticular = value;
	  }
	  }

/// <summary>
/// Gets or sets the Edad of the Persona.
/// </summary>
	public int Edad { 
	  get{
			return _edad;
	  }
	  set{
			_edad = value;
	  }
	  }
	  
/// <summary>
/// Gets or sets the IdEstadoCivilMaterno of the Persona.
/// </summary>


public int IdEstadoCivilMaterno { 
	  get{
			return _idEstadoCivilMaterno;
	  }
	  set{
			_idEstadoCivilMaterno = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdEstadoCivilPaterno of the Persona.
/// </summary>


public int IdEstadoCivilPaterno { 
	  get{
			return _idEstadoCivilPaterno;
	  }
	  set{
			_idEstadoCivilPaterno = value;
	  }
	  }

/// <summary>
/// Gets or sets the idTipoPersona of the Persona.
/// </summary>


public int idTipoPersona
{
    get
    {
        return _idTipoPersona;
    }
    set
    {
        _idTipoPersona = value;
    }
}
#endregion

}
}
