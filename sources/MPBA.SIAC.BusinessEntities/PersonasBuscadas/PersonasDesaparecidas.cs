using System;
using System.ComponentModel;
using System.Diagnostics;

using MPBA.SIAC.BusinessEntities;

namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class PersonasDesaparecidas{

#region "Private Variables"
  private int _id;
  private string _ipp;
  private string _uFI;
  private int _idOrganismoInterviniente;
  private int _idComisaria;
  private int _idLugarDesaparicion;
  private int _idTipoDNI;
  private string _dNI;
  private string _apellido;
  private string _nombre;
  private DateTime?  _fechaDesaparicion = null;
  private int _idSexo;
  private DateTime?  _fechaNacimiento = null;
  private int? _edadMomentoDesaparicion;
  private float? _talla;
  private float? _peso;
  private int _idColorPiel;
  private int _idColorCabello;
  private int _idColorTenido;
  private int _idLongitudCabello;
  private int _idAspectoCabello;
  private int _idCalvicie;
  private int _idColorOjos;
  private int _idRostro;
  private int? _cantidadDiasNoAfeitado;
  private int? _faltanPiezasDentales;
  private int _idDentadura;
  /*private int _idSeniaParticular;
  private int _idUbicacionSeniaParticular;*/
  private int? _tieneADN;
  private string _aDN;
  private int _idGrupoSanguineo;
  private int? _foto;
  private int? _fichasDactilares;
  private string _ropa;
  private string _articulosPersonales;
  private int? _existenRadiografia;
  private DateTime?  _fechaUltimaModificacion = null;
  private DateTime _fechaAlta;
  private decimal _idBusqueda;
  private string _usuarioUltimaModificacion;
  private string _usuarioAlta;
  private bool _baja;
  private Busqueda _busqueda = new Busqueda();
    //coincidencias
  private int _coincidenciaEdad;
  private int _coincidenciaFecha;
  private int _coincidenciaTalla;
  private int _coincidenciaPeso;
  private int _coincidenciaSexo;
  private int _coincidenciaColorPiel;
  private int _coincidenciaColorCabello;
  private int _coincidenciaColorTenido;
  private int _coincidenciaLongitudCabello;
  private int _coincidenciaAspectoCabello;
  private int _coincidenciaCalvicie;
  private int _coincidenciaColorOjos;
  private int _coincidenciaFaltanDientes;
  private int _coincidenciaSeniasParticulares;
  private int _coincidenciaTatuajes;  
  private int _coincidenciaAdn;
  private int _coincidenciaNombreyApellido;
  private int _coincidenciaDNI;
  private int _coincidenciaCantidad;
  private bool _esExtJur;
  private int _motivoDeBaja;
  SeniasParticularesList _seniasParticularess;
  TatuajesPersonaList _tatuajesPersonas;
  PBCausaExtranaJurisdiccion _extJurisdiccion;
  PBFotosList _fotoss;

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the PersonasDesaparecidas.
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
/// Gets or sets the Ipp of the PersonasDesaparecidas.
/// </summary>

[DataObjectFieldAttribute(true, true, false)]


public int MotivoDeBaja
{
    get
    {
        return _motivoDeBaja;
    }
    set
    {
        _motivoDeBaja = value;
    }
}

public string Ipp { 
	  get{
			return _ipp;
	  }
	  set{
			_ipp = value;
	  }
	  }

/// <summary>
/// Gets or sets the esExtJurisdiccion of the PersonasHalladas.
/// </summary>


public bool esExtJurisdiccion
{
    get
    {
        return _esExtJur;
    }
    set
    {
        _esExtJur = value;
    }
}

/// <summary>
/// Gets or sets the UFI of the PersonasDesaparecidas.
/// </summary>


public string UFI { 
	  get{
			return _uFI;
	  }
	  set{
			_uFI = value;
	  }
	  }

/// <summary>
/// Gets or sets the idOrganismoInterviniente of the PersonasDesaparecidas.
/// </summary>


public int idOrganismoInterviniente { 
	  get{
			return _idOrganismoInterviniente;
	  }
	  set{
			_idOrganismoInterviniente = value;
	  }
	  }

/// <summary>
/// Gets or sets the idComisaria of the PersonasDesaparecidas.
/// </summary>


public int idComisaria { 
	  get{
			return _idComisaria;
	  }
	  set{
			_idComisaria = value;
	  }
	  }


/// <summary>
/// Gets or sets the tipoDNI of the PersonasDesaparecidas.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public int idTipoDNI
{
    get
    {
        return _idTipoDNI;
    }
    set
    {
        _idTipoDNI = value;
    }
}

/// <summary>
/// Gets or sets the dNI of the PersonasDesaparecidas.
/// </summary>


public string DNI
{
    get
    {
        return _dNI;
    }
    set
    {
        _dNI = value;
    }
}

/// <summary>
/// Gets or sets the Apellido of the PersonasDesaparecidas.
/// </summary>


public string Apellido
{
    get
    {
        return _apellido;
    }
    set
    {
        _apellido = value;
    }
}

/// <summary>
/// Gets or sets the Nombre of the PersonasDesaparecidas.
/// </summary>


public string Nombre
{
    get
    {
        return _nombre;
    }
    set
    {
        _nombre = value;
    }
}
/// <summary>
/// Gets or sets the idLugarDesaparicion of the PersonasDesaparecidas.
/// </summary>
public int idLugarDesaparicion { 
	  get{
			return _idLugarDesaparicion;
	  }
	  set{
			_idLugarDesaparicion = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaDesaparicion of the PersonasDesaparecidas.
/// </summary>

	public DateTime? FechaDesaparicion { 
	  get{
			return _fechaDesaparicion;
	  }
	  set{
			_fechaDesaparicion = value;
	  }
	  }

/// <summary>
/// Gets or sets the idSexo of the PersonasDesaparecidas.
/// </summary>


public int idSexo { 
	  get{
			return _idSexo;
	  }
	  set{
			_idSexo = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaNacimiento of the PersonasDesaparecidas.
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
/// Gets or sets the EdadMomentoDesaparicion of the PersonasDesaparecidas.
/// </summary>


public int? EdadMomentoDesaparicion { 
	  get{
			return _edadMomentoDesaparicion;
	  }
	  set{
			_edadMomentoDesaparicion = value;
	  }
	  }

/// <summary>
/// Gets or sets the Talla of the PersonasDesaparecidas.
/// </summary>


public float? Talla { 
	  get{
			return _talla;
	  }
	  set{
			_talla = value;
	  }
	  }

/// <summary>
/// Gets or sets the Peso of the PersonasDesaparecidas.
/// </summary>


public float? Peso { 
	  get{
			return _peso;
	  }
	  set{
			_peso = value;
	  }
	  }

/// <summary>
/// Gets or sets the idColorPiel of the PersonasDesaparecidas.
/// </summary>


public int idColorPiel { 
	  get{
			return _idColorPiel;
	  }
	  set{
			_idColorPiel = value;
	  }
	  }

/// <summary>
/// Gets or sets the idColorCabello of the PersonasDesaparecidas.
/// </summary>


public int idColorCabello { 
	  get{
			return _idColorCabello;
	  }
	  set{
			_idColorCabello = value;
	  }
	  }

/// <summary>
/// Gets or sets the idColorTenido of the PersonasDesaparecidas.
/// </summary>


public int idColorTenido { 
	  get{
			return _idColorTenido;
	  }
	  set{
			_idColorTenido = value;
	  }
	  }

/// <summary>
/// Gets or sets the idLongitudCabello of the PersonasDesaparecidas.
/// </summary>


public int idLongitudCabello { 
	  get{
			return _idLongitudCabello;
	  }
	  set{
			_idLongitudCabello = value;
	  }
	  }

/// <summary>
/// Gets or sets the idAspectoCabello of the PersonasDesaparecidas.
/// </summary>


public int idAspectoCabello { 
	  get{
			return _idAspectoCabello;
	  }
	  set{
			_idAspectoCabello = value;
	  }
	  }

/// <summary>
/// Gets or sets the idCalvicie of the PersonasDesaparecidas.
/// </summary>


public int idCalvicie { 
	  get{
			return _idCalvicie;
	  }
	  set{
			_idCalvicie = value;
	  }
	  }

/// <summary>
/// Gets or sets the idColorOjos of the PersonasDesaparecidas.
/// </summary>


public int idColorOjos { 
	  get{
			return _idColorOjos;
	  }
	  set{
			_idColorOjos = value;
	  }
	  }

/// <summary>
/// Gets or sets the idRostro of the PersonasDesaparecidas.
/// </summary>


public int idRostro { 
	  get{
			return _idRostro;
	  }
	  set{
			_idRostro = value;
	  }
	  }

/// <summary>
/// Gets or sets the CantidadDiasNoAfeitado of the PersonasDesaparecidas.
/// </summary>


public int? CantidadDiasNoAfeitado { 
	  get{
			return _cantidadDiasNoAfeitado;
	  }
	  set{
			_cantidadDiasNoAfeitado = value;
	  }
	  }

/// <summary>
/// Gets or sets the FaltanPiezasDentales of the PersonasDesaparecidas.
/// </summary>


public int? FaltanPiezasDentales { 
	  get{
			return _faltanPiezasDentales;
	  }
	  set{
			_faltanPiezasDentales = value;
	  }
	  }

/// <summary>
/// Gets or sets the idDentadura of the PersonasDesaparecidas.
/// </summary>


public int idDentadura { 
	  get{
			return _idDentadura;
	  }
	  set{
			_idDentadura = value;
	  }
	  }

/// <summary>
/// Gets or sets the idSeniaParticular of the PersonasDesaparecidas.
/// </summary>


/*public int idSeniaParticular { 
	  get{
			return _idSeniaParticular;
	  }
	  set{
			_idSeniaParticular = value;
	  }
	  }

/// <summary>
/// Gets or sets the idUbicacionSeniaParticular of the PersonasDesaparecidas.
/// </summary>


public int idUbicacionSeniaParticular { 
	  get{
			return _idUbicacionSeniaParticular;
	  }
	  set{
			_idUbicacionSeniaParticular = value;
	  }
	  }
    */



/// <summary>
/// Gets or sets the tieneADN of the PersonasDesaparecidas.
/// </summary>


public int? tieneADN
{
    get
    {
        return _tieneADN;
    }
    set
    {
        _tieneADN = value;
    }
}

/// <summary>
/// Gets or sets the ADN of the PersonasDesaparecidas.
/// </summary>
public string ADN { 
	  get{
			return _aDN;
	  }
	  set{
			_aDN = value;
	  }
	  }

/// <summary>
/// Gets or sets the idGrupoSanguineo of the PersonasDesaparecidas.
/// </summary>


public int idGrupoSanguineo
{
    get
    {
        return _idGrupoSanguineo;
    }
    set
    {
        _idGrupoSanguineo = value;
    }
}
/// <summary>
/// Gets or sets the Foto of the PersonasDesaparecidas.
/// </summary>


public int? Foto { 
	  get{
			return _foto;
	  }
	  set{
			_foto = value;
	  }
	  }

/// <summary>
/// Gets or sets the FichasDactilares of the PersonasDesaparecidas.
/// </summary>


public int? FichasDactilares { 
	  get{
			return _fichasDactilares;
	  }
	  set{
			_fichasDactilares = value;
	  }
	  }

/// <summary>
/// Gets or sets the Ropa of the PersonasDesaparecidas.
/// </summary>


public string Ropa { 
	  get{
			return _ropa;
	  }
	  set{
			_ropa = value;
	  }
	  }

/// <summary>
/// Gets or sets the ArticulosPersonales of the PersonasDesaparecidas.
/// </summary>


public string ArticulosPersonales { 
	  get{
			return _articulosPersonales;
	  }
	  set{
			_articulosPersonales = value;
	  }
	  }

/// <summary>
/// Gets or sets the ExistenRadiografia of the PersonasDesaparecidas.
/// </summary>


public int? ExistenRadiografia { 
	  get{
			return _existenRadiografia;
	  }
	  set{
			_existenRadiografia = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaUltimaModificacion of the PersonasDesaparecidas.
/// </summary>

	public DateTime? FechaUltimaModificacion { 
	  get{
			return _fechaUltimaModificacion;
	  }
	  set{
			_fechaUltimaModificacion = value;
	  }
	  }

    /// <summary>
    /// Gets or sets the FechaAlta of the PersonasDesaparecidas.
    /// </summary>

    public DateTime FechaAlta
    {
        get
        {
            return _fechaAlta;
        }
        set
        {
            _fechaAlta = value;
        }
    }

    /// <summary>
    /// Gets or sets the UsuarioAlta of the PersonasDesaparecidas.
    /// </summary>


    public string UsuarioAlta
    {
        get
        {
            return _usuarioAlta;
        }
        set
        {
            _usuarioAlta = value;
        }
    }

/// <summary>
/// Gets or sets the UsuarioUltimaModificacion of the PersonasDesaparecidas.
/// </summary>


public string UsuarioUltimaModificacion { 
	  get{
			return _usuarioUltimaModificacion;
	  }
	  set{
			_usuarioUltimaModificacion = value;
	  }
	  }

/// <summary>
/// Gets or sets the Baja of the PersonasDesaparecidas.
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
///Gets or sets a collection of <see cref="Busqueda" /> instances for the PersonasDesaparecidas.
/// </summary>

	public Busqueda busqueda {
	  get{
			return _busqueda;
	  }
	  set{
			_busqueda = value;
	  }
	}

    /// <summary>
    /// Gets or sets the CoincidenciaEdad of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaEdad
    {
        get
        {
            return _coincidenciaEdad;
        }
        set
        {
            _coincidenciaEdad = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaFecha of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaFecha
    {
        get
        {
            return _coincidenciaFecha;
        }
        set
        {
            _coincidenciaFecha = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaTalla of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaTalla
    {
        get
        {
            return _coincidenciaTalla;
        }
        set
        {
            _coincidenciaTalla = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaPeso of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaPeso
    {
        get
        {
            return _coincidenciaPeso;
        }
        set
        {
            _coincidenciaPeso = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaSexo of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaSexo
    {
        get
        {
            return _coincidenciaSexo;
        }
        set
        {
            _coincidenciaSexo = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaColorPiel of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaColorPiel
    {
        get
        {
            return _coincidenciaColorPiel;
        }
        set
        {
            _coincidenciaColorPiel = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaColorCabello of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaColorCabello
    {
        get
        {
            return _coincidenciaColorCabello;
        }
        set
        {
            _coincidenciaColorCabello = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaColorTenido of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaColorTenido
    {
        get
        {
            return _coincidenciaColorTenido;
        }
        set
        {
            _coincidenciaColorTenido = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaLongitudCabello of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaLongitudCabello
    {
        get
        {
            return _coincidenciaLongitudCabello;
        }
        set
        {
            _coincidenciaLongitudCabello = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaAspectoCabello of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaAspectoCabello
    {
        get
        {
            return _coincidenciaAspectoCabello;
        }
        set
        {
            _coincidenciaAspectoCabello = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaCalvicie of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaCalvicie
    {
        get
        {
            return _coincidenciaCalvicie;
        }
        set
        {
            _coincidenciaCalvicie = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaColorOjos of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaColorOjos
    {
        get
        {
            return _coincidenciaColorOjos;
        }
        set
        {
            _coincidenciaColorOjos = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaFaltanDientes of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaFaltanDientes
    {
        get
        {
            return _coincidenciaFaltanDientes;
        }
        set
        {
            _coincidenciaFaltanDientes = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaSeniasParticulares of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaSeniasParticulares
    {
        get
        {
            return _coincidenciaSeniasParticulares;
        }
        set
        {
            _coincidenciaSeniasParticulares = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaTatuajes of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaTatuajes
    {
        get
        {
            return _coincidenciaTatuajes;
        }
        set
        {
            _coincidenciaTatuajes = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaAdn of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaAdn
    {
        get
        {
            return _coincidenciaAdn;
        }
        set
        {
            _coincidenciaAdn = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaCantidad of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaCantidad
    {
        get
        {
            return _coincidenciaCantidad;
        }
        set
        {
            _coincidenciaCantidad = value;
        }
    }

    /// <summary>
    /// Gets or sets the PBCausaExtranaJurisdiccion of the PersonasDesaparecidas.
    /// </summary>


    public PBCausaExtranaJurisdiccion PBCausaExtranaJurisdiccion
    {
        get
        {
            return _extJurisdiccion;
        }
        set
        {
            _extJurisdiccion = value;
        }
    }

    /// <summary>
    /// Gets or sets the CoincidenciaNombreYApellido of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaNombreyApellido
    {
        get
        {
            return _coincidenciaNombreyApellido;
        }
        set
        {
            _coincidenciaNombreyApellido = value;
        }
    }
    /// <summary>
    /// Gets or sets the CoincidenciaDNI of the PersonasDesaparecidas.
    /// </summary>


    public int CoincidenciaDNI
    {
        get
        {
            return _coincidenciaDNI;
        }
        set
        {
            _coincidenciaDNI = value;
        }
    }

    /// <summary>
    ///Gets or sets a collection of <see cref="SeniasParticulares" /> instances for the PersonasDesaparecidas
    /// </summary>

    public SeniasParticularesList seniasParticularess
    {
        get
        {
            return _seniasParticularess;
        }
        set
        {
            _seniasParticularess = value;
        }
    }

    /// <summary>
    ///Gets or sets a collection of <see cref="TatuajesPersona" /> instances for the PersonasDesaparecidas
    /// </summary>

    public TatuajesPersonaList tatuajesPersonas
    {
        get
        {
            return _tatuajesPersonas;
        }
        set
        {
            _tatuajesPersonas = value;
        }
    }

    // <summary>
    ///Gets or sets a collection of <see cref="Fotos" /> instances for the PersonasDesaparecidas
    /// </summary>

    public PBFotosList fotoss
    {
        get
        {
            return _fotoss;
        }
        set
        {
            _fotoss = value;
        }
    }

    /// <summary>
    /// Gets or sets the idBusqueda of the PersonasDesaparecidas.
    /// </summary>


    public decimal idBusqueda
    {
        get
        {
            return _idBusqueda;
        }
        set
        {
            _idBusqueda = value;
        }
    }

#endregion

}
}