using System;
using System.ComponentModel;
using System.Diagnostics;
 

namespace MPBA.AutoresIgnorados.BusinessEntities
{  


public partial class BusquedaRobosDelitosSexuales{

#region "Private Variables"
  private int _id;
  private string _horaDesde;
  private string _horaHasta;
  private string _parajeBarrioH;
  private string _idCalle;
  private string _idEntreCalle1;
  private string _idEntreCalle2;
  private string _idOtraCalle;
  private string _idOtraEntreCalle;
  private string _idOtraEntreCalle2;
  private string _nroH;
  private string _pisoH;
  private string _deptoH;
  private string _idComisariaH;
  private string _nomReferenciaLugarRubro;
  private string _idCausa;
  private string _idMarcaVehiculoMO;
  private string _idModeloVehiculoMO;
  private string _dominioMO;
  private string _idColorVehiculoMO;
  private string _ingresaronPor;
  private string _idLocalidadTraslado;
  private string _idPartidoL;
  private string _idLocalidadL;
  private string _parajeBarrioL;
  private string _idCalleL;
  private string _idOtraCalleL;
  private string _idEntreCalle1L;
  private string _otraEntreCalle1L;
  private string _idEntreCalle2L;
  private string _otraEntreCalle2L;
  private string _idComisariaL;
  private string _exprUtilizadaComienzoDelHecho;
  private string _exprReiteradaDuranteHecho;
  private string _marcaGanado;
  private string _marcaBienSustraidoOtro;
  private string _nroSerieBienSustraidoOtro;
  private string _nro;
  private string _cubiertoCon;
  //private string _ubicacionSeniaParticular;
  //private string _otroTatuaje;
  private string _otraCaracteristica;
  //private int _idClaseSeniaParticular;
  //private int _idClaseTatuaje;
  private string _idMarcaVehiculoBS;
  private string _idModeloVehiculoBS;
  private string _anioBS;
  private string _dominioBS;
  private string _idColorVehiculoBS;
  private string _numeroMotorBS;
  private string _numeroChasisBS;
  private string _identificacionGNCBS;
  private string _otraClaseArma;
  private string _idDepartamento;
  private int _idDelito;
  private int _idClaseDelito;
  private int _idClaseModusOperandi;
  private int _idClaseMomentoDelDia;
  private string _idPartido;
  private string _idLocalidad;
  private int _idClaseLugar;
  private int _idClaseRubro;
  private int _idClaseModoArriboHuida;
  private int _idClaseVidrioVehiculoMO;
  private int _idClaseAgresion;
  private int _idClaseZonaCuerpoLesionada;
  private int _idClaseArma;
  private int _idClaseCantidadAutores;
  private int _idClaseEdadAproximada;
  private int _idClaseSexo;
  private int _idClaseRostro;
  private string _idClaseSeniaParticularL;
  //private int _idClaseLugarDelCuerpo;
  private string _idClaseTatuajeL;
    //Listado de valores de caract fisicas del SIC pasado como string separado por coma
  private string _idClaseEstaturaL;
  private string _idClaseRobustezL;
  private string _idClaseColorPielL;
  private string _idClaseColorOjosL;
  private string _idClaseColorCabelloL;
  private string _idClaseTipoCabelloL;
  private string _idClaseCalvicieL;
  private string _idClaseFormaCaraL;
  private string _idDimensionCejaL;
  private string _idTipoCejaL;
  private string _idFormaMentonL;
  private string _idFormaOrejaL;
  private string _idFormaNarizL;
  private string _idFormaBocaL;
  private string _idFormaLabioInferiorL;
  private string _idFormaLabioSuperiorL;
  private int _idClaseBienSustraido;
  private int _idClaseVidrioVehiculoBS;
  private int _idClaseGanado;
  private int _cantidadGanado;
  private int _cantidadBienSustraidoOtro;
  private int _idVicTestRecRueda;
  private int _idClaseCondicionVictima;
  private DateTime?  _fechaDesde = null;
  private DateTime?  _fechaHasta = null;
  private int _victimasEnElLugar;
  private int _huboAgresionFisicaAVictima;
  private int _victimaTrasladadaAOtroLugar;
  private int _usoDeArmas;
  private int _gNCBS;
  private decimal _montoTotalEstimadoBienSustraido;
  private bool _susceptibleCotejoRastro;
  private int _idClaseRastro;
  private int _idClaseEstadoInformeRastro;
  private DateTime?  _fechaCreacion = null;
  private string _idPuntoGestion;
  private string _descripcionBusqueda;
  private DateTime?  _fechaUltimaModificacion = null;
  private string _usuarioUltimaModificacion;
  private int _idTipoAutor;
  private string _nombreAutor;
  private string _apellidoAutor;
  private string _apodoAutor;
  private int _docNroAutor;
  private BusquedaRobosDelitosSexualesComisariasList _busquedaRobosDelitosSexualesComisariass = new BusquedaRobosDelitosSexualesComisariasList();
  private BusquedaRobosDelitosSexualesLocalidadesList _busquedaRobosDelitosSexualesLocalidadess = new BusquedaRobosDelitosSexualesLocalidadesList();
  private BusquedaRobosDelitosSexualesSeniasList _busquedaRobosDelitosSexualesSeniass = new BusquedaRobosDelitosSexualesSeniasList();
  private BusquedaRoboDelitosSexualesCejaDimensionList _busquedaRoboDelitosSexualesCejaDimensions = new BusquedaRoboDelitosSexualesCejaDimensionList();
  private BusquedaRoboDelitosSexualesCejaFormaList _busquedaRoboDelitosSexualesCejaFormas = new BusquedaRoboDelitosSexualesCejaFormaList();
  private BusquedaRoboDelitosSexualesColorCabelloList _busquedaRoboDelitosSexualesColorCabellos = new BusquedaRoboDelitosSexualesColorCabelloList();
  private BusquedaRoboDelitosSexualesFormaBocaList _busquedaRoboDelitosSexualesFormaBocas = new BusquedaRoboDelitosSexualesFormaBocaList();
  private BusquedaRoboDelitosSexualesFormaCaraList _busquedaRoboDelitosSexualesFormaCaras = new BusquedaRoboDelitosSexualesFormaCaraList();
  private BusquedaRoboDelitosSexualesFormaLabioinfList _busquedaRoboDelitosSexualesFormaLabioinfs = new BusquedaRoboDelitosSexualesFormaLabioinfList();
  private BusquedaRoboDelitosSexualesFormaLabioSupList _busquedaRoboDelitosSexualesFormaLabioSups = new BusquedaRoboDelitosSexualesFormaLabioSupList();
  private BusquedaRoboDelitosSexualesFormaMentonList _busquedaRoboDelitosSexualesFormaMentons = new BusquedaRoboDelitosSexualesFormaMentonList();
  private BusquedaRoboDelitosSexualesFormaNarizList _busquedaRoboDelitosSexualesFormaNarizs = new BusquedaRoboDelitosSexualesFormaNarizList();
  private BusquedaRoboDelitosSexualesFormaOrejaList _busquedaRoboDelitosSexualesFormaOrejas = new BusquedaRoboDelitosSexualesFormaOrejaList();
  private BusquedaRoboDelitosSexualesRobustezList _busquedaRoboDelitosSexualesRobustezs = new BusquedaRoboDelitosSexualesRobustezList();
  private BusquedaRoboDelitosSexualesTipoCabelloList _busquedaRoboDelitosSexualesTipoCabellos = new BusquedaRoboDelitosSexualesTipoCabelloList();
  private BusquedaRoboDelitosSexualesTipoCalvicieList _busquedaRoboDelitosSexualesTipoCalvicies = new BusquedaRoboDelitosSexualesTipoCalvicieList();
  private BusquedaRobosDelitosSexualesColorOjosList _busquedaRobosDelitosSexualesColorOjoss = new BusquedaRobosDelitosSexualesColorOjosList();
  private BusquedaRobosDelitosSexualesColorPielList _busquedaRobosDelitosSexualesColorPiels = new BusquedaRobosDelitosSexualesColorPielList();
  private BusquedaRobosDelitosSexualesEstaturaList _busquedaRobosDelitosSexualesEstaturas = new BusquedaRobosDelitosSexualesEstaturaList();
  private BusquedaRobosDelitosSexualesTatuajesList _busquedaRobosDelitosSexualesTatuajess = new BusquedaRobosDelitosSexualesTatuajesList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the HoraDesde of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the HoraHasta of the BusquedaRobosDelitosSexuales.
/// </summary>


public string HoraHasta { 
	  get{
			return _horaHasta;
	  }
	  set{
			_horaHasta = value;
	  }
	  }

public string NombreAutor
{
    get
    {
        return _nombreAutor;
    }
    set
    {
        _nombreAutor = value;
    }
}

public string ApellidoAutor
{
    get
    {
        return _apellidoAutor;
    }
    set
    {
        _apellidoAutor = value;
    }
}

public string ApodoAutor
{
    get
    {
        return _apodoAutor;
    }
    set
    {
        _apodoAutor = value;
    }
}




/// <summary>
/// Gets or sets the ParajeBarrioH of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the IdCalle of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdCalle { 
	  get{
			return _idCalle;
	  }
	  set{
			_idCalle = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdEntreCalle1 of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdEntreCalle1 { 
	  get{
			return _idEntreCalle1;
	  }
	  set{
			_idEntreCalle1 = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdEntreCalle2 of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdEntreCalle2 { 
	  get{
			return _idEntreCalle2;
	  }
	  set{
			_idEntreCalle2 = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdOtraCalle of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdOtraCalle { 
	  get{
			return _idOtraCalle;
	  }
	  set{
			_idOtraCalle = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdOtraEntreCalle of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdOtraEntreCalle { 
	  get{
			return _idOtraEntreCalle;
	  }
	  set{
			_idOtraEntreCalle = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdOtraEntreCalle2 of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdOtraEntreCalle2 { 
	  get{
			return _idOtraEntreCalle2;
	  }
	  set{
			_idOtraEntreCalle2 = value;
	  }
	  }

/// <summary>
/// Gets or sets the NroH of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the PisoH of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the DeptoH of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the IdComisariaH of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdComisariaH { 
	  get{
			return _idComisariaH;
	  }
	  set{
			_idComisariaH = value;
	  }
	  }

/// <summary>
/// Gets or sets the NomReferenciaLugarRubro of the BusquedaRobosDelitosSexuales.
/// </summary>


public string NomReferenciaLugarRubro { 
	  get{
			return _nomReferenciaLugarRubro;
	  }
	  set{
			_nomReferenciaLugarRubro = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdCausa of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdCausa { 
	  get{
			return _idCausa;
	  }
	  set{
			_idCausa = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdMarcaVehiculoMO of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdMarcaVehiculoMO { 
	  get{
			return _idMarcaVehiculoMO;
	  }
	  set{
			_idMarcaVehiculoMO = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdModeloVehiculoMO of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdModeloVehiculoMO { 
	  get{
			return _idModeloVehiculoMO;
	  }
	  set{
			_idModeloVehiculoMO = value;
	  }
	  }

/// <summary>
/// Gets or sets the DominioMO of the BusquedaRobosDelitosSexuales.
/// </summary>


public string DominioMO { 
	  get{
			return _dominioMO;
	  }
	  set{
			_dominioMO = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdColorVehiculoMO of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdColorVehiculoMO { 
	  get{
			return _idColorVehiculoMO;
	  }
	  set{
			_idColorVehiculoMO = value;
	  }
	  }

/// <summary>
/// Gets or sets the IngresaronPor of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the IdLocalidadTraslado of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdLocalidadTraslado { 
	  get{
			return _idLocalidadTraslado;
	  }
	  set{
			_idLocalidadTraslado = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdPartidoL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdPartidoL { 
	  get{
			return _idPartidoL;
	  }
	  set{
			_idPartidoL = value;
	  }
	  }

/// <summary>
/// Gets or sets the idLocalidadL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idLocalidadL { 
	  get{
			return _idLocalidadL;
	  }
	  set{
			_idLocalidadL = value;
	  }
	  }

/// <summary>
/// Gets or sets the ParajeBarrioL of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the IdCalleL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdCalleL { 
	  get{
			return _idCalleL;
	  }
	  set{
			_idCalleL = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdOtraCalleL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdOtraCalleL { 
	  get{
			return _idOtraCalleL;
	  }
	  set{
			_idOtraCalleL = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdEntreCalle1L of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdEntreCalle1L { 
	  get{
			return _idEntreCalle1L;
	  }
	  set{
			_idEntreCalle1L = value;
	  }
	  }

/// <summary>
/// Gets or sets the OtraEntreCalle1L of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the IdEntreCalle2L of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdEntreCalle2L { 
	  get{
			return _idEntreCalle2L;
	  }
	  set{
			_idEntreCalle2L = value;
	  }
	  }

/// <summary>
/// Gets or sets the OtraEntreCalle2L of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the IdComisariaL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdComisariaL { 
	  get{
			return _idComisariaL;
	  }
	  set{
			_idComisariaL = value;
	  }
	  }

/// <summary>
/// Gets or sets the ExprUtilizadaComienzoDelHecho of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the ExprReiteradaDuranteHecho of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the MarcaGanado of the BusquedaRobosDelitosSexuales.
/// </summary>


public string MarcaGanado { 
	  get{
			return _marcaGanado;
	  }
	  set{
			_marcaGanado = value;
	  }
	  }

/// <summary>
/// Gets or sets the MarcaBienSustraidoOtro of the BusquedaRobosDelitosSexuales.
/// </summary>


public string MarcaBienSustraidoOtro { 
	  get{
			return _marcaBienSustraidoOtro;
	  }
	  set{
			_marcaBienSustraidoOtro = value;
	  }
	  }

/// <summary>
/// Gets or sets the NroSerieBienSustraidoOtro of the BusquedaRobosDelitosSexuales.
/// </summary>


public string NroSerieBienSustraidoOtro { 
	  get{
			return _nroSerieBienSustraidoOtro;
	  }
	  set{
			_nroSerieBienSustraidoOtro = value;
	  }
	  }

/// <summary>
/// Gets or sets the Nro of the BusquedaRobosDelitosSexuales.
/// </summary>


public string Nro { 
	  get{
			return _nro;
	  }
	  set{
			_nro = value;
	  }
	  }

/// <summary>
/// Gets or sets the CubiertoCon of the BusquedaRobosDelitosSexuales.
/// </summary>


public string CubiertoCon { 
	  get{
			return _cubiertoCon;
	  }
	  set{
			_cubiertoCon = value;
	  }
	  }

/// <summary>
/// Gets or sets the UbicacionSeniaParticular of the BusquedaRobosDelitosSexuales.
/// </summary>


//public string UbicacionSeniaParticular { 
//      get{
//            return _ubicacionSeniaParticular;
//      }
//      set{
//            _ubicacionSeniaParticular = value;
//      }
//      }

/// <summary>
/// Gets or sets the OtroTatuaje of the BusquedaRobosDelitosSexuales.
/// </summary>


//public string OtroTatuaje { 
//      get{
//            return _otroTatuaje;
//      }
//      set{
//            _otroTatuaje = value;
//      }
//      }

/// <summary>
/// Gets or sets the OtraCaracteristica of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the IdMarcaVehiculoBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdMarcaVehiculoBS { 
	  get{
			return _idMarcaVehiculoBS;
	  }
	  set{
			_idMarcaVehiculoBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdModeloVehiculoBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdModeloVehiculoBS { 
	  get{
			return _idModeloVehiculoBS;
	  }
	  set{
			_idModeloVehiculoBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the AnioBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public string AnioBS { 
	  get{
			return _anioBS;
	  }
	  set{
			_anioBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the DominioBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public string DominioBS { 
	  get{
			return _dominioBS;
	  }
	  set{
			_dominioBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdColorVehiculoBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdColorVehiculoBS { 
	  get{
			return _idColorVehiculoBS;
	  }
	  set{
			_idColorVehiculoBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the NumeroMotorBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public string NumeroMotorBS { 
	  get{
			return _numeroMotorBS;
	  }
	  set{
			_numeroMotorBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the NumeroChasisBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public string NumeroChasisBS { 
	  get{
			return _numeroChasisBS;
	  }
	  set{
			_numeroChasisBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdentificacionGNCBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdentificacionGNCBS { 
	  get{
			return _identificacionGNCBS;
	  }
	  set{
			_identificacionGNCBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the OtraClaseArma of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the IdDepartamento of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdDepartamento { 
	  get{
			return _idDepartamento;
	  }
	  set{
			_idDepartamento = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdDelito of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdDelito { 
	  get{
			return _idDelito;
	  }
	  set{
			_idDelito = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseDelito of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseDelito { 
	  get{
			return _idClaseDelito;
	  }
	  set{
			_idClaseDelito = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseModusOperandi of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseModusOperandi { 
	  get{
			return _idClaseModusOperandi;
	  }
	  set{
			_idClaseModusOperandi = value;
	  }
	  }


public int IdTipoAutor
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

public int DocNroAutor
{
    get
    {
        return _docNroAutor;
    }
    set
    {
        _docNroAutor = value;
    }
}

/// <summary>
/// Gets or sets the IdClaseMomentoDelDia of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseMomentoDelDia { 
	  get{
			return _idClaseMomentoDelDia;
	  }
	  set{
			_idClaseMomentoDelDia = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdPartido of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdPartido { 
	  get{
			return _idPartido;
	  }
	  set{
			_idPartido = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdLocalidad of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdLocalidad { 
	  get{
			return _idLocalidad;
	  }
	  set{
			_idLocalidad = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseLugar of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseLugar { 
	  get{
			return _idClaseLugar;
	  }
	  set{
			_idClaseLugar = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseRubro of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseRubro { 
	  get{
			return _idClaseRubro;
	  }
	  set{
			_idClaseRubro = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseModoArriboHuida of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseModoArriboHuida { 
	  get{
			return _idClaseModoArriboHuida;
	  }
	  set{
			_idClaseModoArriboHuida = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseVidrioVehiculoMO of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseVidrioVehiculoMO { 
	  get{
			return _idClaseVidrioVehiculoMO;
	  }
	  set{
			_idClaseVidrioVehiculoMO = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseAgresion of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseAgresion { 
	  get{
			return _idClaseAgresion;
	  }
	  set{
			_idClaseAgresion = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseZonaCuerpoLesionada of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseZonaCuerpoLesionada { 
	  get{
			return _idClaseZonaCuerpoLesionada;
	  }
	  set{
			_idClaseZonaCuerpoLesionada = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseArma of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseArma { 
	  get{
			return _idClaseArma;
	  }
	  set{
			_idClaseArma = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseCantidadAutores of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseCantidadAutores { 
	  get{
			return _idClaseCantidadAutores;
	  }
	  set{
			_idClaseCantidadAutores = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseEdadAproximada of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseEdadAproximada { 
	  get{
			return _idClaseEdadAproximada;
	  }
	  set{
			_idClaseEdadAproximada = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseSexo of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseSexo { 
	  get{
			return _idClaseSexo;
	  }
	  set{
			_idClaseSexo = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseRostro of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseRostro { 
	  get{
			return _idClaseRostro;
	  }
	  set{
			_idClaseRostro = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseSeniaParticular of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdClaseSeniaParticularL{

    get
    {
        return _idClaseSeniaParticularL;
    }
    set
    {
        _idClaseSeniaParticularL = value;
    }
}

/// <summary>
/// Gets or sets the IdClaseLugarDelCuerpo of the BusquedaRobosDelitosSexuales.
/// </summary>


//public int IdClaseLugarDelCuerpo { 
//      get{
//            return _idClaseLugarDelCuerpo;
//      }
//      set{
//            _idClaseLugarDelCuerpo = value;
//      }
//      }

/// <summary>
/// Gets or sets the IdClaseTatuaje of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdClaseTatuajeL
{
    get
    {
        return _idClaseTatuajeL;
    }
    set
    {
        _idClaseTatuajeL = value;
    }
}

/// <summary>
/// Gets or sets the idClaseEstaturaL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idClaseEstaturaL
{
    get
    {
        return _idClaseEstaturaL;
    }
    set
    {
        _idClaseEstaturaL = value;
    }
}

/// <summary>
/// Gets or sets the idClaseRobustezL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idClaseRobustezL
{
    get
    {
        return _idClaseRobustezL;
    }
    set
    {
        _idClaseRobustezL = value;
    }
}

/// <summary>
/// Gets or sets the idClaseColorPielL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idClaseColorPielL
{
    get
    {
        return _idClaseColorPielL;
    }
    set
    {
        _idClaseColorPielL = value;
    }
}

/// <summary>
/// Gets or sets the idClaseColorOjosL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idClaseColorOjosL
{
    get
    {
        return _idClaseColorOjosL;
    }
    set
    {
        _idClaseColorOjosL = value;
    }
}

/// <summary>
/// Gets or sets the idClaseColorCabelloL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idClaseColorCabelloL
{
    get
    {
        return _idClaseColorCabelloL;
    }
    set
    {
        _idClaseColorCabelloL = value;
    }
}

/// <summary>
/// Gets or sets the idClaseTipoCabelloL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idClaseTipoCabelloL
{
    get
    {
        return _idClaseTipoCabelloL;
    }
    set
    {
        _idClaseTipoCabelloL = value;
    }
}

/// <summary>
/// Gets or sets the idClaseCalvicieL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idClaseCalvicieL
{
    get
    {
        return _idClaseCalvicieL;
    }
    set
    {
        _idClaseCalvicieL = value;
    }
}

/// <summary>
/// Gets or sets the idClaseFormaCaraL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idClaseFormaCaraL
{
    get
    {
        return _idClaseFormaCaraL;
    }
    set
    {
        _idClaseFormaCaraL = value;
    }
}

/// <summary>
/// Gets or sets the idDimensionCejaL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idDimensionCejaL
{
    get
    {
        return _idDimensionCejaL;
    }
    set
    {
        _idDimensionCejaL = value;
    }
}

/// <summary>
/// Gets or sets the idTipoCejaL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idTipoCejaL
{
    get
    {
        return _idTipoCejaL;
    }
    set
    {
        _idTipoCejaL = value;
    }
}

/// <summary>
/// Gets or sets the idFormaMentonL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idFormaMentonL
{
    get
    {
        return _idFormaMentonL;
    }
    set
    {
        _idFormaMentonL = value;
    }
}

/// <summary>
/// Gets or sets the idFormaOrejaL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idFormaOrejaL
{
    get
    {
        return _idFormaOrejaL;
    }
    set
    {
        _idFormaOrejaL = value;
    }
}

/// <summary>
/// Gets or sets the idFormaNarizL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idFormaNarizL
{
    get
    {
        return _idFormaNarizL;
    }
    set
    {
        _idFormaNarizL = value;
    }
}

/// <summary>
/// Gets or sets the idFormaBocaL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idFormaBocaL
{
    get
    {
        return _idFormaBocaL;
    }
    set
    {
        _idFormaBocaL = value;
    }
}

/// <summary>
/// Gets or sets the idFormaLabioInferiorL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idFormaLabioInferiorL
{
    get
    {
        return _idFormaLabioInferiorL;
    }
    set
    {
        _idFormaLabioInferiorL = value;
    }
}

/// <summary>
/// Gets or sets the idFormaLabioSuperiorL of the BusquedaRobosDelitosSexuales.
/// </summary>


public string idFormaLabioSuperiorL
{
    get
    {
        return _idFormaLabioSuperiorL;
    }
    set
    {
        _idFormaLabioSuperiorL = value;
    }
}

/// <summary>
/// Gets or sets the IdClaseBienSustraido of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseBienSustraido { 
	  get{
			return _idClaseBienSustraido;
	  }
	  set{
			_idClaseBienSustraido = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseVidrioVehiculoBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseVidrioVehiculoBS { 
	  get{
			return _idClaseVidrioVehiculoBS;
	  }
	  set{
			_idClaseVidrioVehiculoBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseGanado of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseGanado { 
	  get{
			return _idClaseGanado;
	  }
	  set{
			_idClaseGanado = value;
	  }
	  }

/// <summary>
/// Gets or sets the CantidadGanado of the BusquedaRobosDelitosSexuales.
/// </summary>


public int CantidadGanado { 
	  get{
			return _cantidadGanado;
	  }
	  set{
			_cantidadGanado = value;
	  }
	  }

/// <summary>
/// Gets or sets the CantidadBienSustraidoOtro of the BusquedaRobosDelitosSexuales.
/// </summary>


public int CantidadBienSustraidoOtro { 
	  get{
			return _cantidadBienSustraidoOtro;
	  }
	  set{
			_cantidadBienSustraidoOtro = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdVicTestRecRueda of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdVicTestRecRueda { 
	  get{
			return _idVicTestRecRueda;
	  }
	  set{
			_idVicTestRecRueda = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseCondicionVictima of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseCondicionVictima { 
	  get{
			return _idClaseCondicionVictima;
	  }
	  set{
			_idClaseCondicionVictima = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaDesde of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the FechaHasta of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the VictimasEnElLugar of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the HuboAgresionFisicaAVictima of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the VictimaTrasladadaAOtroLugar of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the UsoDeArmas of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the GNCBS of the BusquedaRobosDelitosSexuales.
/// </summary>


public int GNCBS { 
	  get{
			return _gNCBS;
	  }
	  set{
			_gNCBS = value;
	  }
	  }

/// <summary>
/// Gets or sets the MontoTotalEstimadoBienSustraido of the BusquedaRobosDelitosSexuales.
/// </summary>


public decimal MontoTotalEstimadoBienSustraido { 
	  get{
			return _montoTotalEstimadoBienSustraido;
	  }
	  set{
			_montoTotalEstimadoBienSustraido = value;
	  }
	  }

/// <summary>
/// Gets or sets the SusceptibleCotejoRastro of the BusquedaRobosDelitosSexuales.
/// </summary>


public bool SusceptibleCotejoRastro { 
	  get{
			return _susceptibleCotejoRastro;
	  }
	  set{
			_susceptibleCotejoRastro = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseRastro of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseRastro { 
	  get{
			return _idClaseRastro;
	  }
	  set{
			_idClaseRastro = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdClaseEstadoInformeRastro of the BusquedaRobosDelitosSexuales.
/// </summary>


public int IdClaseEstadoInformeRastro { 
	  get{
			return _idClaseEstadoInformeRastro;
	  }
	  set{
			_idClaseEstadoInformeRastro = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaCreacion of the BusquedaRobosDelitosSexuales.
/// </summary>

	public DateTime? FechaCreacion { 
	  get{
			return _fechaCreacion;
	  }
	  set{
			_fechaCreacion = value;
	  }
	  }

/// <summary>
/// Gets or sets the IdPuntoGestion of the BusquedaRobosDelitosSexuales.
/// </summary>


public string IdPuntoGestion { 
	  get{
			return _idPuntoGestion;
	  }
	  set{
			_idPuntoGestion = value;
	  }
	  }

/// <summary>
/// Gets or sets the DescripcionBusqueda of the BusquedaRobosDelitosSexuales.
/// </summary>


public string DescripcionBusqueda { 
	  get{
			return _descripcionBusqueda;
	  }
	  set{
			_descripcionBusqueda = value;
	  }
	  }

/// <summary>
/// Gets or sets the FechaUltimaModificacion of the BusquedaRobosDelitosSexuales.
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
/// Gets or sets the UsuarioUltimaModificacion of the BusquedaRobosDelitosSexuales.
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
///Gets or sets a collection of <see cref="BusquedaRobosDelitosSexualesComisarias" /> instances for the BusquedaRobosDelitosSexuales.
/// </summary>

	public BusquedaRobosDelitosSexualesComisariasList busquedaRobosDelitosSexualesComisariass {
	  get{
			return _busquedaRobosDelitosSexualesComisariass;
	  }
	  set{
			_busquedaRobosDelitosSexualesComisariass = value;
	  }
	}
/// <summary>
///Gets or sets a collection of <see cref="BusquedaRobosDelitosSexualesLocalidades" /> instances for the BusquedaRobosDelitosSexuales.
/// </summary>

	public BusquedaRobosDelitosSexualesLocalidadesList busquedaRobosDelitosSexualesLocalidadess {
	  get{
			return _busquedaRobosDelitosSexualesLocalidadess;
	  }
	  set{
			_busquedaRobosDelitosSexualesLocalidadess = value;
	  }
	}
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRobosDelitosSexualesSenias" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRobosDelitosSexualesSeniasList busquedaRobosDelitosSexualesSeniass
    {
        get
        {
            return _busquedaRobosDelitosSexualesSeniass;
        }
        set
        {
            _busquedaRobosDelitosSexualesSeniass = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRobosDelitosSexualesTatuajes" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRobosDelitosSexualesTatuajesList busquedaRobosDelitosSexualesTatuajess
    {
        get
        {
            return _busquedaRobosDelitosSexualesTatuajess;
        }
        set
        {
            _busquedaRobosDelitosSexualesTatuajess = value;
        }
    }

  

    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesCejaDimension" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesCejaDimensionList busquedaRoboDelitosSexualesCejaDimensions
    {
        get
        {
            return _busquedaRoboDelitosSexualesCejaDimensions;
        }
        set
        {
            _busquedaRoboDelitosSexualesCejaDimensions = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesCejaForma" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesCejaFormaList busquedaRoboDelitosSexualesCejaFormas
    {
        get
        {
            return _busquedaRoboDelitosSexualesCejaFormas;
        }
        set
        {
            _busquedaRoboDelitosSexualesCejaFormas = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesColorCabello" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesColorCabelloList busquedaRoboDelitosSexualesColorCabellos
    {
        get
        {
            return _busquedaRoboDelitosSexualesColorCabellos;
        }
        set
        {
            _busquedaRoboDelitosSexualesColorCabellos = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesFormaBoca" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesFormaBocaList busquedaRoboDelitosSexualesFormaBocas
    {
        get
        {
            return _busquedaRoboDelitosSexualesFormaBocas;
        }
        set
        {
            _busquedaRoboDelitosSexualesFormaBocas = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesFormaCara" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesFormaCaraList busquedaRoboDelitosSexualesFormaCaras
    {
        get
        {
            return _busquedaRoboDelitosSexualesFormaCaras;
        }
        set
        {
            _busquedaRoboDelitosSexualesFormaCaras = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesFormaLabioinf" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesFormaLabioinfList busquedaRoboDelitosSexualesFormaLabioinfs
    {
        get
        {
            return _busquedaRoboDelitosSexualesFormaLabioinfs;
        }
        set
        {
            _busquedaRoboDelitosSexualesFormaLabioinfs = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesFormaLabioSup" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesFormaLabioSupList busquedaRoboDelitosSexualesFormaLabioSups
    {
        get
        {
            return _busquedaRoboDelitosSexualesFormaLabioSups;
        }
        set
        {
            _busquedaRoboDelitosSexualesFormaLabioSups = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesFormaMenton" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesFormaMentonList busquedaRoboDelitosSexualesFormaMentons
    {
        get
        {
            return _busquedaRoboDelitosSexualesFormaMentons;
        }
        set
        {
            _busquedaRoboDelitosSexualesFormaMentons = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesFormaNariz" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesFormaNarizList busquedaRoboDelitosSexualesFormaNarizs
    {
        get
        {
            return _busquedaRoboDelitosSexualesFormaNarizs;
        }
        set
        {
            _busquedaRoboDelitosSexualesFormaNarizs = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesFormaOreja" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesFormaOrejaList busquedaRoboDelitosSexualesFormaOrejas
    {
        get
        {
            return _busquedaRoboDelitosSexualesFormaOrejas;
        }
        set
        {
            _busquedaRoboDelitosSexualesFormaOrejas = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesRobustez" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesRobustezList busquedaRoboDelitosSexualesRobustezs
    {
        get
        {
            return _busquedaRoboDelitosSexualesRobustezs;
        }
        set
        {
            _busquedaRoboDelitosSexualesRobustezs = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesTipoCabello" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesTipoCabelloList busquedaRoboDelitosSexualesTipoCabellos
    {
        get
        {
            return _busquedaRoboDelitosSexualesTipoCabellos;
        }
        set
        {
            _busquedaRoboDelitosSexualesTipoCabellos = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRoboDelitosSexualesTipoCalvicie" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRoboDelitosSexualesTipoCalvicieList busquedaRoboDelitosSexualesTipoCalvicies
    {
        get
        {
            return _busquedaRoboDelitosSexualesTipoCalvicies;
        }
        set
        {
            _busquedaRoboDelitosSexualesTipoCalvicies = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRobosDelitosSexualesColorOjos" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRobosDelitosSexualesColorOjosList busquedaRobosDelitosSexualesColorOjoss
    {
        get
        {
            return _busquedaRobosDelitosSexualesColorOjoss;
        }
        set
        {
            _busquedaRobosDelitosSexualesColorOjoss = value;
        }
    }
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRobosDelitosSexualesColorPiel" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRobosDelitosSexualesColorPielList busquedaRobosDelitosSexualesColorPiels
    {
        get
        {
            return _busquedaRobosDelitosSexualesColorPiels;
        }
        set
        {
            _busquedaRobosDelitosSexualesColorPiels = value;
        }
    }
  
    /// <summary>
    ///Gets or sets a collection of <see cref="BusquedaRobosDelitosSexualesEstatura" /> instances for the BusquedaRobosDelitosSexuales.
    /// </summary>

    public BusquedaRobosDelitosSexualesEstaturaList busquedaRobosDelitosSexualesEstaturas
    {
        get
        {
            return _busquedaRobosDelitosSexualesEstaturas;
        }
        set
        {
            _busquedaRobosDelitosSexualesEstaturas = value;
        }
    }

#endregion

}
}
