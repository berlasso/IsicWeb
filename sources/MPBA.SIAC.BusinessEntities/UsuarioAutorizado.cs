using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Configuration;
using System.Web;

using MPBA.SIAC.BusinessEntities;

namespace MPBA.SIAC.BusinessEntities
{
  public partial class  UsuarioAutorizado
    {
  

         #region "Private Variables"

          private string _idUsuario;
          private string _nombreUsuario;
          private string _idGrupoUsuario;
          private bool _activo;
          private string _idPersonalPoderJudicial;
          private int _idJerarquia;
          private string _idPuntoGestion;
          private int _idPersona;
          private string _nombre;
          private string _apellido;
          private bool _esReferenteTrata;
          private int _idDepartamento;

          #endregion

         #region "Public Properties"


/// <summary>
/// Gets or sets the idPersonalPoderJudicial of the Usuarios.
/// </summary>


public string idPersonalPoderJudicial { 
	  get{
			return _idPersonalPoderJudicial;
	  }
	  set{
			_idPersonalPoderJudicial = value;
	  }
	  }

/// <summary>
/// Gets or sets the NombreUsuario of the Usuarios.
/// </summary>


public string NombreUsuario { 
	  get{
			return _nombreUsuario;
	  }
	  set{
			_nombreUsuario = value;
	  }
	  }



/// <summary>
/// Gets or sets the idGrupoUsuario of the Usuarios.
/// </summary>


public string idGrupoUsuario { 
	  get{
			return _idGrupoUsuario;
	  }
	  set{
			_idGrupoUsuario = value;
	  }
	  }

/// <summary>
/// Gets or sets the activo of the Usuarios.
/// </summary>


public bool activo { 
	  get{
			return _activo;
	  }
	  set{
			_activo = value;
	  }
	  }
// <summary>
/// Gets or sets the idPersona of the PersonalPoderJudicial.
/// </summary>


public string idUsuario
{
    get
    {
        return _idUsuario;
    }
    set
    {
        _idUsuario = value;
    }
}

/// <summary>
/// Gets or sets the idJerarquia of the PersonalPoderJudicial.
/// </summary>


public int idJerarquia
{
    get
    {
        return _idJerarquia;
    }
    set
    {
        _idJerarquia = value;
    }
}

/// <summary>
/// Gets or sets the idPuntoGestion of the PersonalPoderJudicial.
/// </summary>


public string idPuntoGestion
{
    get
    {
        return _idPuntoGestion;
    }
    set
    {
        _idPuntoGestion = value;
    }
}
/// <summary>
/// Gets or sets the id of the Persona.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public int idPersona
{
    get
    {
        return _idPersona;
    }
    set
    {
        _idPersona = value;
    }
}

/// <summary>
/// Gets or sets the Nombre of the Persona.
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
/// Gets or sets the Apellido of the Persona.
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
/// Gets or sets the esRefrenteTrata of the Usuarios.
/// </summary>
public bool EsReferenteTrata
{
    get
    {
        return _esReferenteTrata;
    }
    set
    {
        _esReferenteTrata = value;
    }
}
/// <summary>
/// Gets or sets the idDepartamento of the PuntoGestion.
/// </summary>


public int idDepartamento
{
    get
    {
        return _idDepartamento;
    }
    set
    {
        _idDepartamento = value;
    }
}


#endregion

}


}
 