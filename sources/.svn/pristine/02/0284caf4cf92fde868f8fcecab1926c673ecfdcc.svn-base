using System;
using System.ComponentModel;
using System.Diagnostics;
using MPBA.SIAC.Bll;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


public partial class PBCausaExtranaJurisdiccion{

#region "Private Variables"
  private int _id;
  private string _organoRequirente;
  private string _jurisdiccion;
  private string _provincia;
  private string _telefono;
  private string _mail;
  private string _caratula;
  private int _idTipoBusqueda;
  private string _nroCausa;
  private string _nombreProvincia;


#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the PBCausaExtranaJurisdiccion.
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
/// Gets or sets the OrganoRequirente of the PBCausaExtranaJurisdiccion.
/// </summary>


public string OrganoRequirente { 
	  get{
			return _organoRequirente;
	  }
	  set{
			_organoRequirente = value;
	  }
	  }

/// <summary>
/// Gets or sets the Jurisdiccion of the PBCausaExtranaJurisdiccion.
/// </summary>


public string Jurisdiccion { 
	  get{
			return _jurisdiccion;
	  }
	  set{
			_jurisdiccion = value;
	  }
	  }

/// <summary>
/// Gets or sets the Provincia of the PBCausaExtranaJurisdiccion.
/// </summary>


public string Provincia { 
	  get{
			return _provincia;
	  }
	  set{
			_provincia = value;
	  }
	  }

/// <summary>
/// Gets the Provincia of the PBCausaExtranaJurisdiccion.
/// </summary>
public string NombreProvincia
{
    get
    {
        int prov = 0;
        if (Int32.TryParse(_provincia, out prov))
            return ProvinciaManager.GetItem(prov).provincia.Trim();
        else
            return "";
    }

}


/// <summary>
/// Gets or sets the telefono of the PBCausaExtranaJurisdiccion.
/// </summary>


public string telefono { 
	  get{
			return _telefono;
	  }
	  set{
			_telefono = value;
	  }
	  }

/// <summary>
/// Gets or sets the mail of the PBCausaExtranaJurisdiccion.
/// </summary>


public string mail { 
	  get{
			return _mail;
	  }
	  set{
			_mail = value;
	  }
	  }

/// <summary>
/// Gets or sets the caratula of the PBCausaExtranaJurisdiccion.
/// </summary>


public string caratula { 
	  get{
			return _caratula;
	  }
	  set{
			_caratula = value;
	  }
	  }

/// <summary>
/// Gets or sets the idTipoBusqueda of the PBCausaExtranaJurisdiccion.
/// </summary>


public int idTipoBusqueda { 
	  get{
			return _idTipoBusqueda;
	  }
	  set{
			_idTipoBusqueda = value;
	  }
	  }

/// <summary>
/// Gets or sets the idPersonaBuscada of the PBCausaExtranaJurisdiccion.
/// </summary>


public string NroCausa
{ 
	  get{
          return _nroCausa;
	  }
	  set{
          _nroCausa = value;
	  }
	  }


#endregion

}
}
