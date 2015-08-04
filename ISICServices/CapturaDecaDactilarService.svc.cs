using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Neurotec;
using Neurotec.Biometrics;
using ISIC.Entities;
using System.Threading.Tasks;
using MPBA.DataAccess;

namespace ISIC.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CapturaDecaDactilarService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CapturaDecaDactilarService.svc or CapturaDecaDactilarService.svc.cs at the Solution Explorer and start debugging.
    public class CapturaDecaDactilarService : ICapturaDecaDactilarService
    {
     
            private static Logger logger = LogManager.GetCurrentClassLogger();
            private IImputadoService VImputado;
            private IBioDactilarService VBioDactilar;



            public static int ConvertNFingerToIndex(NFPosition pos)
            {
                switch (pos)
                {
                    case NFPosition.LeftIndexFinger:
                        return 1;
                    case NFPosition.LeftThumb:
                        return 0;
                    case NFPosition.LeftMiddleFinger:
                        return 2;
                    case NFPosition.LeftRingFinger:
                        return 3;
                    case NFPosition.LeftLittleFinger:
                        return 4;
                    case NFPosition.RightIndexFinger:
                        return 6;
                    case NFPosition.RightThumb:
                        return 5;
                    case NFPosition.RightMiddleFinger:
                        return 7;
                    case NFPosition.RightRingFinger:
                        return 8;
                    case NFPosition.RightLittleFinger:
                        return 9;
                    default: return 0;

                }

            }


            public static Enums.ClaseMano ConvertNFingerToHand(NFPosition pos)
            {
                switch (pos)
                {
                    case   NFPosition.LeftThumb: case NFPosition.LeftIndexFinger: case NFPosition.LeftMiddleFinger: case NFPosition.LeftRingFinger: case NFPosition.LeftLittleFinger :
                        return Enums.ClaseMano.Izquierda;

                    case NFPosition.RightThumb: case NFPosition.RightIndexFinger: case NFPosition.RightMiddleFinger: case NFPosition.RightRingFinger: case NFPosition.RightLittleFinger:
                        return Enums.ClaseMano.Derecha;
                
                    
                    default:
                        return Enums.ClaseMano.Izquierda;
                }

            }




         public  CapturaDecaDactilarService(IImputadoService VImputadoService, IBioDactilarService VBioDeca) 
        {
            logger.Info("Iniciando Servicio");
            this.VImputado = VImputadoService;
            this.VBioDactilar = VBioDeca;
            List<Imputado> imp = (List<Imputado>)this.VImputado.GetAll().Where(x => x.CodigoDeBarras == "011700002900M").ToList();
          

            logger.Info("Servicio Iniciado Cantidad de imputados: "+imp.Count());
        }



            /// <summary>
            /// 
            /// Retorno del procedimiento  :
            /// 0: OK 
            /// 1: El imputado NO esta creado
            /// 2: Indico menos de 10 dedos incluyendo faltantes!
            /// </summary>
            /// <param name="composite"></param>
            /// <returns> 1 ok, 0 Error</returns>
            public int CapturaHuellasCliente(ImputadoDatosPers imputado, HuellasImputado sujeto)
            {
                int resp;
                
                logger.Info("Datos transacción");
                logger.Info("CODIGO BARRAS {0},DNI: {1}, Apellido: {2} Nombres: {3}, sexo: {4}", imputado.CodigoBarras,imputado.Apellido, imputado.DNI, imputado.Nombres, imputado.Sexo);

                Imputado imp = VImputado.GetByCodigoTodasHuellas(imputado.CodigoBarras.ToString());

                if (imp == null)
                { /* Son Huellas y el imputado NO esta creado*/

                    logger.Info("Enviaron las Huellas y el imputado NO esta creado");
                    resp = 1;
                    return resp;

                }

                VImputado.BorrarHuellas(imp);
                if (sujeto.DedosCapturados.Count() + sujeto.DedosFaltantes.Count() < 10)
                {  // Ver porque reporto menos dedos
                    resp = 2;
                    logger.Info("Los dedos son menos que 10 {0}:", sujeto.DedosCapturados.Count() + sujeto.DedosFaltantes.Count());
                    return resp;
                }

                /* Recuperar los datos del imputado y verificar si existe*/
              


              
                /*Ver el acceso al Renaper si accedio en el cliente esta en imputado clase y habria que enviarlo a algun metodo para su registro*/
                /*Update de las huellas */


                logger.Info("Antes de Borrar,Huellas mano derecha " + imp.BioManoDerecha.ToList().Count());
                logger.Info("Antes de borrar, Huellas mano Izquierda " + imp.BioManoIzquierda.ToList().Count());

              /*  List<BioDactilar> bioDerecha = VBioDactilar.GetBioManoDerechaByCodigoBarra(imputado.CodigoBarras);
                List<BioDactilar> bioIzq = VBioDactilar.GetBioManoIzquierdaByCodigoBarra(imputado.CodigoBarras);*/
               
           /*
                for (int i = imp.BioManoDerecha.ToList().Count - 1; i >= 0; i--)
                {
                    imp.BioManoDerecha.ToList().RemoveAt(i);
                }


                for (int i = imp.BioManoIzquierda.ToList().Count - 1; i >= 0; i--)
                {
                    imp.BioManoIzquierda.ToList().RemoveAt(i);
                }

*/

                /*
                var itemsToRemove =  imp.BioManoIzquierda.ToArray();
                foreach (var item in itemsToRemove) {
                                 

                    imp.BioManoIzquierda.Remove(item);
                    VBioDactilar.BorrarBio(item);

                }
        
               itemsToRemove = imp.BioManoDerecha.ToArray();

                foreach (var item in itemsToRemove)
                {
                    imp.BioManoDerecha.Remove(item);
                    VBioDactilar.BorrarBio(item);
                }
             */


              
                logger.Info("Se borraron las huellas mano derecha " + imp.BioManoDerecha.Count());
                logger.Info("Se borraron las huellas mano Izquierda " + imp.BioManoIzquierda.Count());

                /*Creo tantas BioDactilares como dedos*/
                foreach(var item in sujeto.DedosFaltantes)
                {
                    BioDactilar unDedo = new BioDactilar();
                    unDedo.CodigoDeBarra = imp.CodigoDeBarras;
                    int dedoEn5 = ConvertNFingerToIndex(item.Position) > 4 ? ConvertNFingerToIndex(item.Position) - 5 : ConvertNFingerToIndex(item.Position);
                   
                    unDedo.Dedo = (Enums.ClaseDedo)dedoEn5;
                    unDedo.Mano = (Enums.ClaseMano) ConvertNFingerToHand(item.Position);
                    unDedo.imagen = null;
                    unDedo.EstadoDedo = Enums.ClaseEstadoDedo.Faltante;
                    unDedo.FechaDigital = DateTime.Now;
                    unDedo.Baja = false;
                    if (unDedo.Mano == Enums.ClaseMano.Derecha)
                    { imp.BioManoDerecha.Add(unDedo); }
                    if (unDedo.Mano == Enums.ClaseMano.Izquierda)
                    { imp.BioManoIzquierda.Add(unDedo); }

                   
                 }
                

                foreach (var item in sujeto.DedosCapturados)
                {
                    BioDactilar unDedo = new BioDactilar();
                    unDedo.CodigoDeBarra = imputado.CodigoBarras;
                    int dedoEn5 = ConvertNFingerToIndex(item.Position) > 4 ? ConvertNFingerToIndex(item.Position) - 5 : ConvertNFingerToIndex(item.Position);
                  
                    unDedo.Dedo = (Enums.ClaseDedo)dedoEn5;
                    unDedo.Mano = (Enums.ClaseMano)ConvertNFingerToHand(item.Position);
                    unDedo.imagen = item.Imagen;
                    unDedo.EstadoDedo = Enums.ClaseEstadoDedo.Normal;
                    unDedo.FechaDigital = DateTime.Now; 
                    unDedo.Baja = false;
                    if (unDedo.Mano == Enums.ClaseMano.Derecha)
                    { imp.BioManoDerecha.Add(unDedo); }
                    if (unDedo.Mano == Enums.ClaseMano.Izquierda)
                    { imp.BioManoIzquierda.Add(unDedo); }

                }

                
              
                logger.Info("BioManoDerecha" + imp.BioManoDerecha.Count());
                logger.Info("BioManoIzquierda" + imp.BioManoIzquierda.Count());
                if (sujeto.DedosFaltantes.Count() == 10)
                {
                    // Le faltan ambas Manos
                    imp.ExisteDecadactilar = 0;
                    imp.ManoDerecha = (Enums.ClaseEstadoMano)3;
                    imp.ManoIzquierda = (Enums.ClaseEstadoMano)3;
                }
                else
                {
                    imp.ExisteDecadactilar = 1;
                }


                
                if (sujeto.DedosFaltantes.Where(x => (Enums.ClaseMano)ConvertNFingerToHand(x.Position) == Enums.ClaseMano.Derecha).Count() == 5)
                {
                    // Tiene 5 dedos faltantes de la Mano Derecha => Mano Derecha Faltante/Amputada
                    imp.ManoDerecha = (Enums.ClaseEstadoMano)3;
                }
                else
                {
                    imp.ManoDerecha = (Enums.ClaseEstadoMano)1;
                }
                // Idem Mano Izquierda
                if (sujeto.DedosFaltantes.Where(x => (Enums.ClaseMano)ConvertNFingerToHand(x.Position) == Enums.ClaseMano.Izquierda).Count() == 5)
                {
                    imp.ManoIzquierda = (Enums.ClaseEstadoMano)3;
                }
                else
                {
                    imp.ManoIzquierda = (Enums.ClaseEstadoMano)1;
                }
                 
                VImputado.Actualizar(imp);
                logger.Info("Actualiza el Imputado");
                return 0;
            }
       
    }
}
