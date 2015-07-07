using System;
using System.Collections.Generic;
using System.Net;

using System.Xml.XPath;
using System.Text;
using System.Globalization;

namespace MPBA.SIAC.BusinessEntities
{
    public class GoogleRepositorio
    {

   
        public static Boolean ValidaDireccionGoggle(GoogleMarker lugar, out int resultado)
        {
            resultado = 0;
            int formattedResp = 0;
            System.Net.WebResponse response = null;
            string url = "https://maps.googleapis.com/maps/api/geocode/xml?address=" + lugar.domicilio.Trim() + ",Argentina&sensor=false&language=es";
            WebProxy myProxy = new WebProxy();
            myProxy.Address = new Uri("http://proxy.mpba.gov.ar:3128");

            myProxy.Credentials = CredentialCache.DefaultCredentials;
            String loingStr = string.Format(url);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(loingStr);
            myRequest.Proxy = myProxy;
            myRequest.Method = "GET";
            response = myRequest.GetResponse();

            if (lugar.Longitude != 0 && lugar.Latitude != 0)
            { return true; }
            lugar.Latitude = 0;
            lugar.Latitude = 0;

            if (response != null)
                {
                  XPathDocument document = new XPathDocument(response.GetResponseStream());
                  XPathNavigator navigator = document.CreateNavigator();
                 // get response status
                 XPathNodeIterator statusIterator = navigator.Select("/GeocodeResponse/status");
                 while (statusIterator.MoveNext())
                    {
                    if (statusIterator.Current.Value != "OK")
                       {// da ZERO_RESULTS SI ESTA MAL LA DIRECCION 
                       resultado = 1;
                       continue;
                       //Console.WriteLine("Error: response status = '" + statusIterator.Current.Value + "'");
                      //    return;
                        }
                        }  
                     // get results
                   XPathNodeIterator resultIterator = navigator.Select("/GeocodeResponse/result");
                   while (resultIterator.MoveNext())
                   {
                       XPathNodeIterator formattedAddressIterator = resultIterator.Current.Select("formatted_address");
                     if (formattedAddressIterator.MoveNext())
                       {
                           // ACA ESTA LA DIRECCION JUNTO CON LA LOCALIDAD Y PROVINCIA
                           if (formattedResp==0)
                           { lugar.InfoWindow += formattedAddressIterator.Current.Value.Trim();
                              formattedResp=1;}
                       }

                       XPathNodeIterator geometryIterator = resultIterator.Current.Select("geometry");
                       while (geometryIterator.MoveNext())
                       {
                           // Geometria
                           XPathNodeIterator locationIterator = geometryIterator.Current.Select("location");
                           while (locationIterator.MoveNext())
                           {
                               if (lugar.Latitude != 0 && lugar.Longitude !=0)
                               { continue; }
                               // Location

                               XPathNodeIterator latIterator = locationIterator.Current.Select("lat");

                               while (latIterator.MoveNext())
                               {

                                   lugar.Latitude = double.Parse(latIterator.Current.Value.Trim(), CultureInfo.InvariantCulture);


                               }

                               XPathNodeIterator lngIterator = locationIterator.Current.Select("lng");

                               while (lngIterator.MoveNext())
                               {
                                   lugar.Longitude = double.Parse(lngIterator.Current.Value.Trim(), CultureInfo.InvariantCulture);
                               }

                              
                           }

                           XPathNodeIterator locationTypeIterator = geometryIterator.Current.Select("location_type");
                       }


                   }
         

                        }
            if (lugar.Longitude != 0 && lugar.Latitude != 0)
            { return true; }
            return false;
        }

        public static List<GoogleMarker> GetMarcadores(List<GoogleMarker> ubicaciones, out int resultado)
        {
            System.Net.WebResponse response = null;
            
            List<GoogleMarker>  marcadorResultado = new List<GoogleMarker>();
            try
            {
                // Por defecto OK
                // Posibles valores de retorno
                // resultado = 0   ok
                // resultado =-1  Error con el acceso a la URL
                // resultado = 1;  La direccion no es valida

                resultado = 0;

                foreach (var elemento in ubicaciones)
                {  
                    // recorro la lista de marcadores para completar la longitud y latitud
                                   

                       Boolean validar = ValidaDireccionGoggle(elemento,out resultado);


                        if (Convert.ToBoolean(validar)== true)
                        {
                            marcadorResultado.Add(elemento);
                        }
                    
                    }


                }


           catch (Exception ex)
            {
                // ACA INFORMAR ERROR SI NO SE PUDO CONECTAR A GOOGLE MAPS
                // Error al conectarse a la URL
                resultado = -1;
              
            }

            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }


            return marcadorResultado;
        }


       
    }
}

