using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.AutoresIgnorados.BusinessEntities
{


public partial class Delitos{

#region "Private Variables"
  private int _id;
  private string _idCausa;
  private int _idClaseFecha;
  private int _idClaseDelito;
  private int _idTipoAutor;
  private DateTime?  _fechaDesde = null;
  private DateTime?  _fechaHasta = null;
  private int _idClaseHora;
  private string _horaDesde;
  private string _horaHasta;
  private int _idClaseMomentoDelDia;
  private int _idPartido;
  private int _idLocalidad;
  private int _idCalle;
  private string _idOtraCalle;
  private int _idEntreCalle1;
  private string _idOtraEntreCalle;
  private int _idEntreCalle2;
  private string _idOtraEntreCalle2;
  private string _nroH;
  private string _pisoH;
  private string _deptoH;
  private string _parajeBarrioH;
  private int _idComisariaH;
  private int _idClaseLugar;
  private int _idClaseRubro;
  private string _nomRefLugarRubro;
  private int _idClaseModoArriboHuida;
  private int _idClaseModusOperandis;
  private string _exprUtilizadaComienzoDelHecho;
  private string _exprReiteradaDuranteHecho;
  private string _ingresaronPor;
  private int _victimasEnElLugar;
  private int _usoDeArmas;
  private int _idClaseArma;
  private int _idClaseSubtipoArma;
  private string _otraClaseArma;
  private string _otraCaracteristica;
  private int _huboAgresionFisicaAVictima;
  private int _idClaseAgresion;
  private int _idClaseZonaCuerpoLesionada;
  private int _victimaTrasladadaAOtroLugar;
  private int _idPartidoL;
  private int _idLocalidadL;
  private int _idCalleL;
  private string _idOtraCalleL;
  private int _idEntreCalle1L;
  private string _otraEntreCalle1L;
  private int _idEntreCalle2L;
  private string _otraEntreCalle2L;
  private string _parajeBarrioL;
  private int _idComisariaL;
  private int _idClaseCantidadAutores;
  private float _montoTotalEstimadoBienSustraido;
  private int _idVicTestRecRueda;
  private int _idClaseCondicionVictima;
  private int _idClaseCantAutorReconocidos;
  private bool _baja;
  private string _idUsuarioUltimaModificacion;
  private string _idUsuarioAlta;
  private string _motivoBaja;
  private DateTime? _fechaBaja;
  private DateTime?  _fechaUltimaModificacion = null;
  private DateTime? _fechaAlta;
  private AutoresList _autoress = new AutoresList();
  private BienesSustraidosList _bienesSustraidoss = new BienesSustraidosList();
  private LugaresDeTrasladoDeVictimasList _lugaresDeTrasladoDeVictimass = new LugaresDeTrasladoDeVictimasList();
  private RastrosList _rastross = new RastrosList();
  private VehiculosList _vehiculoss = new VehiculosList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the Delitos.
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
/// Gets or sets the FechaAlta of the Delitos.
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
/// Gets or sets the idUsuarioAlta of the Delitos.
/// </summary>


public string idUsuarioAlta
{
    get
    {
        return _idUsuarioAlta;
    }
    set
    {
        _idUsuarioAlta = value;
    }
}

// <summary>
/// Gets or sets the motivoBaja of the Delitos.
/// </summary>


public string motivoBaja
{
    get
    {
        return _motivoBaja;
    }
    set
    {
        _motivoBaja = value;
    }
}

// <summary>
/// Gets or sets the fechaBaja of the Delitos.
/// </summary>


public DateTime? FechaBaja
{
    get
    {
        return _fechaBaja;
    }
    set
    {
        _fechaBaja = value;
    }
}


/// <summary>
/// Gets or sets the idCausa of the Delitos.
/// </summary>


public string idCausa { 
	  get{
			return _idCausa;
	  }
	  set{
			_idCausa = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseFecha of the Delitos.
/// </summary>


public int idClaseFecha { 
	  get{
			return _idClaseFecha;
	  }
	  set{
			_idClaseFecha = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseDelito of the Delitos.
/// </summary>


public int idClaseDelito
{
    get
    {
        return _idClaseDelito;
    }
    set
    {
        _idClaseDelito = value;
    }
}

/// <summary>
/// Gets or sets the idTipoAutor of the Delitos.
/// </summary>


public int idTipoAutor
{
    get
    {
        return _idTipoAutor;
    }
    set
    {
        _idTipoAutor = value;
    }
}

/// <summary>
/// Gets or sets the FechaDesde of the Delitos.
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
/// Gets or sets the FechaHasta of the Delitos.
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
/// Gets or sets the idClaseHora of the Delitos.
/// </summary>


public int idClaseHora { 
	  get{
			return _idClaseHora;
	  }
	  set{
			_idClaseHora = value;
	  }
	  }

/// <summary>
/// Gets or sets the HoraDesde of the Delitos.
/// </summary>


public string HoraDesde { 
	  get{
			return _horaDesde;
	  }
	  set{
			_horaDesde = value;
	  }
	  }


/// <summary>
/// Gets or sets the OtraCaracteristica of the Delitos.
/// </summary>


public string OtraCaracteristica
{
    get
    {
        return _otraCaracteristica;
    }
    set
    {
        _otraCaracteristica = value;
    }
}

/// <summary>
/// Gets or sets the HoraHasta of the Delitos.
/// </summary>


public string HoraHasta { 
	  get{
			return _horaHasta;
	  }
	  set{
			_horaHasta = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseMomentoDelDia of the Delitos.
/// </summary>


public int idClaseMomentoDelDia { 
	  get{
			return _idClaseMomentoDelDia;
	  }
	  set{
			_idClaseMomentoDelDia = value;
	  }
	  }

/// <summary>
/// Gets or sets the idPartido of the Delitos.
/// </summary>


public int idPartido { 
	  get{
			return _idPartido;
	  }
	  set{
			_idPartido = value;
	  }
	  }

/// <summary>
/// Gets or sets the idLocalidad of the Delitos.
/// </summary>


public int idLocalidad { 
	  get{
			return _idLocalidad;
	  }
	  set{
			_idLocalidad = value;
	  }
	  }

/// <summary>
/// Gets or sets the idCalle of the Delitos.
/// </summary>


public int idCalle { 
	  get{
			return _idCalle;
	  }
	  set{
			_idCalle = value;
	  }
	  }

/// <summary>
/// Gets or sets the idOtraCalle of the Delitos.
/// </summary>


public string idOtraCalle { 
	  get{
			return _idOtraCalle;
	  }
	  set{
			_idOtraCalle = value;
	  }
	  }

/// <summary>
/// Gets or sets the idEntreCalle1 of the Delitos.
/// </summary>


public int idEntreCalle1 { 
	  get{
			return _idEntreCalle1;
	  }
	  set{
			_idEntreCalle1 = value;
	  }
	  }

/// <summary>
/// Gets or sets the idOtraEntreCalle of the Delitos.
/// </summary>


public string idOtraEntreCalle { 
	  get{
			return _idOtraEntreCalle;
	  }
	  set{
			_idOtraEntreCalle = value;
	  }
	  }

/// <summary>
/// Gets or sets the idEntreCalle2 of the Delitos.
/// </summary>


public int idEntreCalle2 { 
	  get{
			return _idEntreCalle2;
	  }
	  set{
			_idEntreCalle2 = value;
	  }
	  }

/// <summary>
/// Gets or sets the idOtraEntreCalle2 of the Delitos.
/// </summary>


public string idOtraEntreCalle2 { 
	  get{
			return _idOtraEntreCalle2;
	  }
	  set{
			_idOtraEntreCalle2 = value;
	  }
	  }

/// <summary>
/// Gets or sets the NroH of the Delitos.
/// </summary>


public string NroH { 
	  get{
			return _nroH;
	  }
	  set{
			_nroH = value;
	  }
	  }

/// <summary>
/// Gets or sets the PisoH of the Delitos.
/// </summary>


public string PisoH { 
	  get{
			return _pisoH;
	  }
	  set{
			_pisoH = value;
	  }
	  }

/// <summary>
/// Gets or sets the DeptoH of the Delitos.
/// </summary>


public string DeptoH { 
	  get{
			return _deptoH;
	  }
	  set{
			_deptoH = value;
	  }
	  }

/// <summary>
/// Gets or sets the ParajeBarrioH of the Delitos.
/// </summary>


public string ParajeBarrioH { 
	  get{
			return _parajeBarrioH;
	  }
	  set{
			_parajeBarrioH = value;
	  }
	  }

/// <summary>
/// Gets or sets the idComisariaH of the Delitos.
/// </summary>


public int idComisariaH { 
	  get{
			return _idComisariaH;
	  }
	  set{
			_idComisariaH = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseLugar of the Delitos.
/// </summary>


public int idClaseLugar { 
	  get{
			return _idClaseLugar;
	  }
	  set{
			_idClaseLugar = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseRubro of the Delitos.
/// </summary>


public int idClaseRubro { 
	  get{
			return _idClaseRubro;
	  }
	  set{
			_idClaseRubro = value;
	  }
	  }

/// <summary>
/// Gets or sets the NomRefLugarRubro of the Delitos.
/// </summary>


public string NomRefLugarRubro { 
	  get{
			return _nomRefLugarRubro;
	  }
	  set{
			_nomRefLugarRubro = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseModoArriboHuida of the Delitos.
/// </summary>


public int idClaseModoArriboHuida { 
	  get{
			return _idClaseModoArriboHuida;
	  }
	  set{
			_idClaseModoArriboHuida = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseModusOperandis of the Delitos.
/// </summary>


public int idClaseModusOperandis { 
	  get{
			return _idClaseModusOperandis;
	  }
	  set{
			_idClaseModusOperandis = value;
	  }
	  }

/// <summary>
/// Gets or sets the ExprUtilizadaComienzoDelHecho of the Delitos.
/// </summary>


public string ExprUtilizadaComienzoDelHecho { 
	  get{
			return _exprUtilizadaComienzoDelHecho;
	  }
	  set{
			_exprUtilizadaComienzoDelHecho = value;
	  }
	  }

/// <summary>
/// Gets or sets the ExprReiteradaDuranteHecho of the Delitos.
/// </summary>


public string ExprReiteradaDuranteHecho { 
	  get{
			return _exprReiteradaDuranteHecho;
	  }
	  set{
			_exprReiteradaDuranteHecho = value;
	  }
	  }

/// <summary>
/// Gets or sets the IngresaronPor of the Delitos.
/// </summary>


public string IngresaronPor { 
	  get{
			return _ingresaronPor;
	  }
	  set{
			_ingresaronPor = value;
	  }
	  }

/// <summary>
/// Gets or sets the VictimasEnElLugar of the Delitos.
/// </summary>


public int VictimasEnElLugar { 
	  get{
			return _victimasEnElLugar;
	  }
	  set{
			_victimasEnElLugar = value;
	  }
	  }

/// <summary>
/// Gets or sets the UsoDeArmas of the Delitos.
/// </summary>


public int UsoDeArmas { 
	  get{
			return _usoDeArmas;
	  }
	  set{
			_usoDeArmas = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseArma of the Delitos.
/// </summary>


public int idClaseArma { 
	  get{
			return _idClaseArma;
	  }
	  set{
			_idClaseArma = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseSubtipoArma of the Delitos.
/// </summary>


public int idClaseSubtipoArma
{
    get
    {
        return _idClaseSubtipoArma;
    }
    set
    {
        _idClaseSubtipoArma = value;
    }
}

/// <summary>
/// Gets or sets the OtraClaseArma of the Delitos.
/// </summary>


public string OtraClaseArma { 
	  get{
			return _otraClaseArma;
	  }
	  set{
			_otraClaseArma = value;
	  }
	  }

/// <summary>
/// Gets or sets the HuboAgresionFisicaAVictima of the Delitos.
/// </summary>


public int HuboAgresionFisicaAVictima { 
	  get{
			return _huboAgresionFisicaAVictima;
	  }
	  set{
			_huboAgresionFisicaAVictima = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseAgresion of the Delitos.
/// </summary>


public int idClaseAgresion { 
	  get{
			return _idClaseAgresion;
	  }
	  set{
			_idClaseAgresion = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseZonaCuerpoLesionada of the Delitos.
/// </summary>


public int idClaseZonaCuerpoLesionada { 
	  get{
			return _idClaseZonaCuerpoLesionada;
	  }
	  set{
			_idClaseZonaCuerpoLesionada = value;
	  }
	  }

/// <summary>
/// Gets or sets the VictimaTrasladadaAOtroLugar of the Delitos.
/// </summary>


public int VictimaTrasladadaAOtroLugar { 
	  get{
			return _victimaTrasladadaAOtroLugar;
	  }
	  set{
			_victimaTrasladadaAOtroLugar = value;
	  }
	  }

/// <summary>
/// Gets or sets the idPartidoL of the Delitos.
/// </summary>


public int idPartidoL { 
	  get{
			return _idPartidoL;
	  }
	  set{
			_idPartidoL = value;
	  }
	  }

/// <summary>
/// Gets or sets the idLocalidadL of the Delitos.
/// </summary>


public int idLocalidadL { 
	  get{
			return _idLocalidadL;
	  }
	  set{
			_idLocalidadL = value;
	  }
	  }

/// <summary>
/// Gets or sets the idCalleL of the Delitos.
/// </summary>


public int idCalleL { 
	  get{
			return _idCalleL;
	  }
	  set{
			_idCalleL = value;
	  }
	  }

/// <summary>
/// Gets or sets the idOtraCalleL of the Delitos.
/// </summary>


public string idOtraCalleL { 
	  get{
			return _idOtraCalleL;
	  }
	  set{
			_idOtraCalleL = value;
	  }
	  }

/// <summary>
/// Gets or sets the idEntreCalle1L of the Delitos.
/// </summary>


public int idEntreCalle1L { 
	  get{
			return _idEntreCalle1L;
	  }
	  set{
			_idEntreCalle1L = value;
	  }
	  }

/// <summary>
/// Gets or sets the OtraEntreCalle1L of the Delitos.
/// </summary>


public string OtraEntreCalle1L { 
	  get{
			return _otraEntreCalle1L;
	  }
	  set{
			_otraEntreCalle1L = value;
	  }
	  }

/// <summary>
/// Gets or sets the idEntreCalle2L of the Delitos.
/// </summary>


public int idEntreCalle2L { 
	  get{
			return _idEntreCalle2L;
	  }
	  set{
			_idEntreCalle2L = value;
	  }
	  }

/// <summary>
/// Gets or sets the OtraEntreCalle2L of the Delitos.
/// </summary>


public string OtraEntreCalle2L { 
	  get{
			return _otraEntreCalle2L;
	  }
	  set{
			_otraEntreCalle2L = value;
	  }
	  }

/// <summary>
/// Gets or sets the ParajeBarrioL of the Delitos.
/// </summary>


public string ParajeBarrioL { 
	  get{
			return _parajeBarrioL;
	  }
	  set{
			_parajeBarrioL = value;
	  }
	  }

/// <summary>
/// Gets or sets the idComisariaL of the Delitos.
/// </summary>


public int idComisariaL { 
	  get{
			return _idComisariaL;
	  }
	  set{
			_idComisariaL = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseCantidadAutores of the Delitos.
/// </summary>


public int idClaseCantidadAutores { 
	  get{
			return _idClaseCantidadAutores;
	  }
	  set{
			_idClaseCantidadAutores = value;
	  }
	  }

/// <summary>
/// Gets or sets the MontoTotalEstimadoBienSustraido of the Delitos.
/// </summary>


public float MontoTotalEstimadoBienSustraido { 
	  get{
			return _montoTotalEstimadoBienSustraido;
	  }
	  set{
			_montoTotalEstimadoBienSustraido = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseCantVicTestRecRueda of the Delitos.
/// </summary>


public int idVicTestRecRueda { 
	  get{
			return _idVicTestRecRueda;
	  }
	  set{
			_idVicTestRecRueda = value;
	  }
	  }

/// <summary>
/// Gets or sets the idClaseCondicionVictima of the Delitos.
/// </summary>


public int idClaseCondicionVictima
{
    get
    {
        return _idClaseCondicionVictima;
    }
    set
    {
        _idClaseCondicionVictima = value;
    }
}

/// <summary>
/// Gets or sets the idClaseCantAutorReconocidos of the Delitos.
/// </summary>


public int idClaseCantAutorReconocidos { 
	  get{
			return _idClaseCantAutorReconocidos;
	  }
	  set{
			_idClaseCantAutorReconocidos = value;
	  }
	  }

/// <summary>
/// Gets or sets the Baja of the Delitos.
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
/// Gets or sets the idUsuarioUltimaModificacion of the Delitos.
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
/// Gets or sets the FechaUltimaModificacion of the Delitos.
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
///Gets or sets a collection of <see cref="Autores" /> instances for the Delitos.
/// </summary>

	public AutoresList autoress {
	  get{
			return _autoress;
	  }
	  set{
			_autoress = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="BienesSustraidos" /> instances for the Delitos.
/// </summary>

	public BienesSustraidosList bienesSustraidoss {
	  get{
			return _bienesSustraidoss;
	  }
	  set{
			_bienesSustraidoss = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="LugaresDeTrasladoDeVictimas" /> instances for the Delitos.
/// </summary>

	public LugaresDeTrasladoDeVictimasList lugaresDeTrasladoDeVictimass {
	  get{
			return _lugaresDeTrasladoDeVictimass;
	  }
	  set{
			_lugaresDeTrasladoDeVictimass = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="Rastros" /> instances for the Delitos.
/// </summary>

	public RastrosList rastross {
	  get{
			return _rastross;
	  }
	  set{
			_rastross = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="Vehiculos" /> instances for the Delitos.
/// </summary>

	public VehiculosList vehiculoss {
	  get{
			return _vehiculoss;
	  }
	  set{
			_vehiculoss = value;
	  }
	}

#endregion

}
}
