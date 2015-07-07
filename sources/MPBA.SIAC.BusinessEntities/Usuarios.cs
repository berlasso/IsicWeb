using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Configuration;
using System.Web;



using MPBA.SIAC.BusinessEntities;



namespace MPBA.SIAC.BusinessEntities
{


public partial class Usuarios{
    public Usuarios()
        {
        
        }

        public Usuarios(MPBA.ConfigurationCL.BusinessObject.Usuarios pUsuario) {
            
            
            
        }

#region "Private Variables"
  private string _id;
  private string _idPersonalPoderJudicial;
  private string _nombreUsuario;
  private string _claveUsuario;
  private string _idGrupoUsuario;
  private bool _activo;
  private DateTime?  _actividad = null;
  private string _version;
  private bool _bitacoraMemoria;
  private int  _margenArriba;
  private int  _margenIzquierda;
  private int  _margenAbajo;
  private int  _margenDerecha;
  private bool _esReferenteTrata;
  private PermisoUsuarioList _permisoUsuarios = new PermisoUsuarioList();

#endregion

#region "Public Properties"
/// <summary>
/// Gets or sets the id of the Usuarios.
/// </summary>
[DataObjectFieldAttribute(true, true, false)]


public string id { 
	  get{
			return _id;
	  }
	  set{
			_id = value;
	  }
	  }

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
/// Gets or sets the ClaveUsuario of the Usuarios.
/// </summary>


public string ClaveUsuario { 
	  get{
			return _claveUsuario;
	  }
	  set{
			_claveUsuario = value;
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

/// <summary>
/// Gets or sets the Actividad of the Usuarios.
/// </summary>

	public DateTime? Actividad { 
	  get{
			return _actividad;
	  }
	  set{
			_actividad = value;
	  }
	  }

/// <summary>
/// Gets or sets the version of the Usuarios.
/// </summary>


public string version { 
	  get{
			return _version;
	  }
	  set{
			_version = value;
	  }
	  }

/// <summary>
/// Gets or sets the bitacoraMemoria of the Usuarios.
/// </summary>


public bool bitacoraMemoria { 
	  get{
			return _bitacoraMemoria;
	  }
	  set{
			_bitacoraMemoria = value;
	  }
	  }

/// <summary>
/// Gets or sets the MargenArriba of the Usuarios.
/// </summary>
	public int MargenArriba { 
	  get{
			return _margenArriba;
	  }
	  set{
			_margenArriba = value;
	  }
	  }
	  
/// <summary>
/// Gets or sets the MargenIzquierda of the Usuarios.
/// </summary>
	public int MargenIzquierda { 
	  get{
			return _margenIzquierda;
	  }
	  set{
			_margenIzquierda = value;
	  }
	  }
	  
/// <summary>
/// Gets or sets the MargenAbajo of the Usuarios.
/// </summary>
	public int MargenAbajo { 
	  get{
			return _margenAbajo;
	  }
	  set{
			_margenAbajo = value;
	  }
	  }
	  
/// <summary>
/// Gets or sets the MargenDerecha of the Usuarios.
/// </summary>
	public int MargenDerecha { 
	  get{
			return _margenDerecha;
	  }
	  set{
			_margenDerecha = value;
	  }
	  }

    /// <summary>
    /// Gets or sets the MargenDerecha of the Usuarios.
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
///Gets or sets a collection of <see cref="PermisoUsuario" /> instances for the Usuarios.
/// </summary>

	public PermisoUsuarioList permisoUsuarios {
	  get{
			return _permisoUsuarios;
	  }
	  set{
			_permisoUsuarios = value;
	  }
	}

#endregion

}
}
