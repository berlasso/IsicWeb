using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class Busqueda{

#region "Private Variables"
  private decimal _id;
  private string _uFI;
  private int _idOrigen;
  private string _usuario;
  private string _tablaDestino;
  private string _dNI;
  private string _apellido;
  private string _nombre;
  private DateTime?  _fechaDesde = null;
  private DateTime?  _fechaHasta = null;
  private int? _edadDesde;
  private int? _edadHasta;
  private int? _tieneADN;
  private int _idsexo;
  private float? _tallaDesde;
  private float? _tallaHasta;
  private float? _pesoDesde;
  private float? _pesoHasta;
  private int _faltanPiezasDentales;
  private string _codigoADN;
  private int? _cantidadCoincidencias = null;
  private DateTime?  _fechaUltimaCoincidencia = null;
  private int _idComisariaIntervinoAparcicion;
  private DateTime?  _fechaActuaciones = null;
  private int _idMotivoHallazgo;
  private string _motivoHallazgoDescripcion;
  private DateTime?  _fechaUltimaModificacion;
  private string _usuarioUltimaModificacion;
  private DateTime? _fechaAlta;
  private string _usuarioAlta;
  private bool _baja;
  private string _iPP;
  private BusquedaAspectoCabelloList _busquedaAspectoCabellos = new BusquedaAspectoCabelloList();
  private BusquedaCalvicieList _busquedaCalvicies = new BusquedaCalvicieList();
  private BusquedaColorCabelloList _busquedaColorCabellos = new BusquedaColorCabelloList();
  private BusquedaColorOjosList _busquedaColorOjoss = new BusquedaColorOjosList();
  private BusquedaColorPielList _busquedaColorPiels = new BusquedaColorPielList();
  private BusquedaColorTenidoList _busquedaColorTenidos = new BusquedaColorTenidoList();
  private BusquedaGrupoSanguineoList _busquedaGrupoSanguineos = new BusquedaGrupoSanguineoList();
  private BusquedaLongitudCabelloList _busquedaLongitudCabellos = new BusquedaLongitudCabelloList();
  private BusquedaSeniasParticularesList _busquedaSeniasParticularess = new BusquedaSeniasParticularesList();
  private PersonasDesaparecidasList _personasDesaparecidass = new PersonasDesaparecidasList();
  private PersonasHalladasList _personasHalladass = new PersonasHalladasList();
  private BusquedaRostroList _busquedaRostros = new BusquedaRostroList();
  private BusquedaTatuajesList _busquedaTatuajess = new BusquedaTatuajesList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the Id of the Busqueda.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public decimal Id { 
	  get{
			return _id;
	  }
	  set{
			_id = value;
	  }
	  }

/// <summary>
/// Gets or sets the UFI of the Busqueda.
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
/// Gets or sets the idOrigen of the Busqueda.
/// </summary>


public int idOrigen { 
	  get{
			return _idOrigen;
	  }
	  set{
			_idOrigen = value;
	  }
	  }

/// <summary>
/// Gets or sets the tieneADN of the Busqueda.
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
/// Gets or sets the Usuario of the Busqueda.
/// </summary>


public string Usuario { 
	  get{
			return _usuario;
	  }
	  set{
			_usuario = value;
	  }
	  }

/// <summary>
/// Gets or sets the TablaDestino of the Busqueda.
/// </summary>


public string TablaDestino { 
	  get{
			return _tablaDestino;
	  }
	  set{
			_tablaDestino = value;
	  }
	  }

/// <summary>
/// Gets or sets the DNI of the Busqueda.
/// </summary>


public string DNI { 
	  get{
			return _dNI;
	  }
	  set{
			_dNI = value;
	  }
	  }

/// <summary>
/// Gets or sets the Apellido of the Busqueda.
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
/// Gets or sets the Nombre of the Busqueda.
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
/// Gets or sets the FechaDesde of the Busqueda.
/// </summary>

	public DateTime? FechaDesde { 
	  get{
			return _fechaDesde;
	  }
	  set{
			_fechaDesde = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaHasta of the Busqueda.
/// </summary>

	public DateTime? FechaHasta { 
	  get{
			return _fechaHasta;
	  }
	  set{
			_fechaHasta = value;
	  }
	  }

/// <summary>
/// Gets or sets the EdadDesde of the Busqueda.
/// </summary>


public int? EdadDesde { 
	  get{
			return _edadDesde;
	  }
	  set{
			_edadDesde = value;
	  }
	  }

/// <summary>
/// Gets or sets the EdadHasta of the Busqueda.
/// </summary>


public int? EdadHasta { 
	  get{
			return _edadHasta;
	  }
	  set{
			_edadHasta = value;
	  }
	  }

/// <summary>
/// Gets or sets the idsexo of the Busqueda.
/// </summary>


public int idsexo { 
	  get{
			return _idsexo;
	  }
	  set{
			_idsexo = value;
	  }
	  }

/// <summary>
/// Gets or sets the TallaDesde of the Busqueda.
/// </summary>


public float? TallaDesde { 
	  get{
			return _tallaDesde;
	  }
	  set{
			_tallaDesde = value;
	  }
	  }

/// <summary>
/// Gets or sets the TallaHasta of the Busqueda.
/// </summary>


public float? TallaHasta { 
	  get{
			return _tallaHasta;
	  }
	  set{
			_tallaHasta = value;
	  }
	  }

/// <summary>
/// Gets or sets the PesoDesde of the Busqueda.
/// </summary>


public float? PesoDesde { 
	  get{
			return _pesoDesde;
	  }
	  set{
			_pesoDesde = value;
	  }
	  }

/// <summary>
/// Gets or sets the PesoHasta of the Busqueda.
/// </summary>


public float? PesoHasta { 
	  get{
			return _pesoHasta;
	  }
	  set{
			_pesoHasta = value;
	  }
	  }

/// <summary>
/// Gets or sets the FaltanPiezasDentales of the Busqueda.
/// </summary>


public int FaltanPiezasDentales { 
	  get{
			return _faltanPiezasDentales;
	  }
	  set{
			_faltanPiezasDentales = value;
	  }
	  }

/// <summary>
/// Gets or sets the CodigoADN of the Busqueda.
/// </summary>


public string CodigoADN { 
	  get{
			return _codigoADN;
	  }
	  set{
			_codigoADN = value;
	  }
	  }

/// <summary>
/// Gets or sets the CantidadCoincidencias of the Busqueda.
/// </summary>


public int? CantidadCoincidencias { 
	  get{
			return _cantidadCoincidencias;
	  }
	  set{
			_cantidadCoincidencias = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaUltimaCoincidencia of the Busqueda.
/// </summary>

	public DateTime? FechaUltimaCoincidencia { 
	  get{
			return _fechaUltimaCoincidencia;
	  }
	  set{
			_fechaUltimaCoincidencia = value;
	  }
	  }

/// <summary>
/// Gets or sets the idComisariaIntervinoAparcicion of the Busqueda.
/// </summary>


public int idComisariaIntervinoAparcicion { 
	  get{
			return _idComisariaIntervinoAparcicion;
	  }
	  set{
			_idComisariaIntervinoAparcicion = value;
	  }
	  }

/// <summary>
/// Gets or sets the fechaActuaciones of the Busqueda.
/// </summary>

	public DateTime? fechaActuaciones { 
	  get{
			return _fechaActuaciones;
	  }
	  set{
			_fechaActuaciones = value;
	  }
	  }

/// <summary>
/// Gets or sets the idMotivoHallazgo of the Busqueda.
/// </summary>


public int idMotivoHallazgo { 
	  get{
			return _idMotivoHallazgo;
	  }
	  set{
			_idMotivoHallazgo = value;
	  }
	  }

/// <summary>
/// Gets or sets the MotivoHallazgoDescripcion of the Busqueda.
/// </summary>


public string MotivoHallazgoDescripcion { 
	  get{
			return _motivoHallazgoDescripcion;
	  }
	  set{
			_motivoHallazgoDescripcion = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaUltimaModificacion of the Busqueda.
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
/// Gets or sets the UsuarioUltimaModificacion of the Busqueda.
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
/// Gets or sets the FechaAlta of the Busqueda.
/// </summary>

public DateTime? FechaAlta
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
/// Gets or sets the UsuarioAlta of the Busqueda.
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
/// Gets or sets the Baja of the Busqueda.
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
/// Gets or sets the IPP of the Busqueda.
/// </summary>


public string IPP { 
	  get{
			return _iPP;
	  }
	  set{
			_iPP = value;
	  }
	  }

/// <summary>
///Gets or sets a collection of <see cref="BusquedaAspectoCabello" /> instances for the Busqueda.
/// </summary>

	public BusquedaAspectoCabelloList busquedaAspectoCabellos {
	  get{
			return _busquedaAspectoCabellos;
	  }
	  set{
			_busquedaAspectoCabellos = value;
	  }
	}
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRostro" /> instances for the Busqueda.
    /// </summary>

    public BusquedaRostroList busquedaRostros
    {
        get
        {
            return _busquedaRostros;
        }
        set
        {
            _busquedaRostros = value;
        }
    }
/// <summary>
///Gets or sets a collection of <see cref="BusquedaCalvicie" /> instances for the Busqueda.
/// </summary>

	public BusquedaCalvicieList busquedaCalvicies {
	  get{
			return _busquedaCalvicies;
	  }
	  set{
			_busquedaCalvicies = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="BusquedaColorCabello" /> instances for the Busqueda.
/// </summary>

	public BusquedaColorCabelloList busquedaColorCabellos {
	  get{
			return _busquedaColorCabellos;
	  }
	  set{
			_busquedaColorCabellos = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="BusquedaColorOjos" /> instances for the Busqueda.
/// </summary>

	public BusquedaColorOjosList busquedaColorOjoss {
	  get{
			return _busquedaColorOjoss;
	  }
	  set{
			_busquedaColorOjoss = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="BusquedaColorPiel" /> instances for the Busqueda.
/// </summary>

	public BusquedaColorPielList busquedaColorPiels {
	  get{
			return _busquedaColorPiels;
	  }
	  set{
			_busquedaColorPiels = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="BusquedaColorTenido" /> instances for the Busqueda.
/// </summary>

	public BusquedaColorTenidoList busquedaColorTenidos {
	  get{
			return _busquedaColorTenidos;
	  }
	  set{
			_busquedaColorTenidos = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="BusquedaGrupoSanguineo" /> instances for the Busqueda.
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
///Gets or sets a collection of <see cref="BusquedaLongitudCabello" /> instances for the Busqueda.
/// </summary>

	public BusquedaLongitudCabelloList busquedaLongitudCabellos {
	  get{
			return _busquedaLongitudCabellos;
	  }
	  set{
			_busquedaLongitudCabellos = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="BusquedaSeniasParticulares" /> instances for the Busqueda.
/// </summary>

	public BusquedaSeniasParticularesList busquedaSeniasParticularess {
	  get{
			return _busquedaSeniasParticularess;
	  }
	  set{
			_busquedaSeniasParticularess = value;
	  }
	}
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaTatuajes" /> instances for the Busqueda.
    /// </summary>

    public BusquedaTatuajesList busquedaTatuajess
    {
        get
        {
            return _busquedaTatuajess;
        }
        set
        {
            _busquedaTatuajess = value;
        }
    }
/// <summary>
///Gets or sets a collection of <see cref="PersonasDesaparecidas" /> instances for the Busqueda.
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
///Gets or sets a collection of <see cref="PersonasHalladas" /> instances for the Busqueda.
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
