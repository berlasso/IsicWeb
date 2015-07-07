using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;



namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The PathFotosManager class is responsible for managing Business Entities.PathFotos objects in the system PARA EL REPORTVIEWER.
    /// </summary>
    [DataObjectAttribute()]
    public partial class PathFotosManager
    {
       
      
        #region "Public Methods"

        
        /// <summary>
        /// Gets a list with all PathFotos objects in the database that match idpersona and tipopersona
        /// </summary>
        /// <returns>A list with all PathFotos from the database when the database contains any, or null otherwise.</returns>
        /// <param name="idPersona">idpersona de las fotos que busco</param>
        /// <param name="tipoPersona">si es fotos para halladas o desap</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PathFotosList GetList(int idPersona, int tipoPersona, string pathServer)
        {
            PBFotosList fl = new PBFotosList();
            fl = PBFotosDB.GetListByidPersonaYTablaDestino(idPersona, tipoPersona);
           // return FotosDB.GetListByidPersonaYTablaDestino(idPersona, tipoPersona);
            PathFotosList pfl = new PathFotosList();
            foreach (PBFotos f in fl)
            {
                //if (f.idTipoFoto != tipoFoto)
                //    continue;
                PathFotos pf = new PathFotos();
                switch (f.idTablaDestino)
                {
                    case 1: //desap
                        switch (f.idTipoFoto)
                        {
                            case 1: //gral
                                //pf.path = "~/Fotos/Generales/Desaparecidas/";
                                pf.path = pathServer+"\\Fotos\\Generales\\Desaparecidas\\";
                                break;
                            case 2: //senias
                                //pf.path = "~/Fotos/SenasParticulares/Desaparecidas/";
                                pf.path = pathServer+"\\Fotos\\SenasParticulares\\Desaparecidas\\";
                                break;
                        }
                        break;
                    case 2: //halladas
                        switch (f.idTipoFoto)
                        {
                            case 1: //gral
                                pf.path = pathServer+"\\Fotos\\Generales\\Halladas\\";
                                break;
                            case 2: //senias
                                pf.path = pathServer+"\\Fotos\\SenasParticulares\\Halladas\\";
                                break;
                        }
                        break;

                }
                //pf.path += f.nombreFoto;
                if (!System.IO.File.Exists(pf.path))
                    continue;
                //using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                //{

                //    System.Drawing.Image img = System.Drawing.Image.FromFile(pf.path);
                //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //    pf.imgFoto = Convert.ToBase64String(ms.ToArray());
                //    ms.Close();
                //}
                byte[] imgArray;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {

                    System.Drawing.Image img = System.Drawing.Image.FromFile(pf.path);
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imgArray = new byte[ms.Length];
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    ms.Read(imgArray, 0, (int)ms.Length);
                    pf.imgFoto = Convert.ToBase64String(imgArray);
                    //ms.Close();
                }
                pf.tipoFoto = f.idTipoFoto;
                pfl.Add(pf);
            }
            return pfl;
        }

        public void InsertServerPath(string path)
        {
            
        }

     


        /// <summary>
        /// Saves a PathFotos in the database.
        /// </summary>
        /// <param name="myFotos">The PathFotos instance to save.</param>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static void Save(PathFotos myFotos)
        {
            //using (TransactionScope myTransactionScope = new TransactionScope())
            //{
            //    decimal fotosid = FotosDB.Save(myFotos);

            //    //  Assign the Fotos its new (or existing id).
            //    myFotos.id = fotosid;

            //    myTransactionScope.Complete();

            //    return fotosid;
            //}
        }


      

        /// <summary>
        /// Deletes a PathFotos from the database.
        /// </summary>
        /// <param name="myFotos">The PathFotos instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(PathFotos myFotos)
        {
           // return FotosDB.Delete(myFotos.id);
            return true;
        }

        #endregion

    }

}
