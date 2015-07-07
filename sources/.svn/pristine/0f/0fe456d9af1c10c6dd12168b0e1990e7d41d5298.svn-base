using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;



public partial class LoginSIAC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            tbNombreUsuario.Focus();

            if (Request.QueryString["msj"] == "SinPermiso")
            {
                MsgBox1.Text = "No tiene permisos para realizar ninguna función en el sistema";
                MsgBox1.Visible = true;
            }
        }


    }
   
    protected void LBTNIngresar_Click(object sender, ImageClickEventArgs e)
    {
      
        if (tbNombreUsuario.Text.Trim().Length > 0 && tbClaveUsuario.Text.Trim().Length > 0)
        {

            LoginDomain myLD = new LoginDomain();
            string usuario, clave;
            Boolean usuarioValido;
            usuario = tbNombreUsuario.Text;
            clave = tbClaveUsuario.Text;
            
            
            
            //**********************
            //**********************
            //DESHABILITAR
            //usuarioValido = true;
            //**********************
            //**********************
            usuarioValido = myLD.Authenticate(usuario, clave, "rootDSE");


            if (usuarioValido) //acá se debería consultar por la validez del usuario ingresado en el login
            { //el usuario existe.....
                FormsAuthentication.SetAuthCookie(usuario, false);
                Session["miUsuario"] = usuario;
                //*****************************
                Session["miUfi"] = "xx";
                //*****************************
                Response.Redirect("Home.aspx");
                //Response.Redirect("/AutoresIgnorados/BusquedaAutores.aspx?tipo=21&tipob=1");
            }
            else
            {
                MsgBox1.Text = "El Usuario ingresado es inválido";
                MsgBox1.Visible = true; ;
            }
        }
        else
        {
            MsgBox1.Text = "Debe ingresar usuario y contraseña";
            MsgBox1.Visible = true; ;
        }
    }

    //protected void btn_Click(object sender, EventArgs e)
    //{
    //    this.lblSic.Visible = false;
    //    string clave = Encriptar("siacsic");
    //    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader("http://www.sic.mpba.gov.ar/cons1/admin/webservice.php?user=siacsic&clave=" + clave + "&num=100");
    //    while (reader.Read())
    //    {
    //        this.lblSic.Visible = true;
    //    }
    //}


    ///// <summary>
    ///// Encripta el password para acceder a la base del SIC
    ///// </summary>
    ///// <param name="pass"></param>
    ///// <returns></returns>
    //private string Encriptar(string pass)
    //{
    //    int j = 0;
    //    string aux = "";
    //    string qwerty = "qwertyuiop";
    //    int valor = 0;
    //    string c = "";
    //    for (int i = 0; i < pass.Length; i++)
    //    {
    //        if (j == qwerty.Length)
    //        {
    //            j = 0;
    //        }
    //        valor = (int)(Convert.ToChar(qwerty.Substring(j, 1)) ^ Convert.ToChar(pass.Substring(i, 1)));
    //        j++;

    //        switch (valor)
    //        {
    //            case 0:
    //                c = Convert.ToString((char)255) + "0";
    //                break;
    //            case 255:
    //                c = Convert.ToString((char)255) + " ";
    //                break;
    //            default:
    //                c = Convert.ToString((char)valor);
    //                break;
    //        }
    //        aux += c;
    //    }
    //    return aux;
    //}

   

  
}
