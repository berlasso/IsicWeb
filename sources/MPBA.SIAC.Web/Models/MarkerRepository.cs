using System;
using System.Collections.Generic;
using System.Net;
using SIACGral.Models;
using System.Xml.XPath;
using System.Text;
using System.Globalization;

namespace SIACGral.Models
{
   public class MarkerRepository
    {
      
  public class GeoLocation
       {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        }

    public class GeoGeometry
        {  public GeoLocation Location { get; set; }
        }
    public class GeoResult
        {public GeoGeometry Geometry { get; set; }
        }

    public class GeoResponse
        {
      public string Status { get; set; }
      public GeoResult[] Results { get; set; }
        }

    public IList<GoogleMarker> GetMarcadores(IList<GoogleMarker> ubicaciones, out int resultado)
    {
        System.Net.WebResponse response = null;
      try
      {
          // Por defecto OK
          // Posibles valores de retorno
          // resultado = 0   ok
          // resultado =-1  Error con el acceso a la URL
          // resultado = 1;  La direccion no es valida

          resultado = 0;
        
        foreach(var lugar in ubicaciones) 
        {  // recorro la lista de marcadores para completar la longitud y latitud

            string url = "https://maps.googleapis.com/maps/api/geocode/xml?address="+lugar.domicilio+",Argentina&sensor=false";
            WebProxy myProxy = new WebProxy();
            myProxy.Address = new Uri("http://proxy.mpba.gov.ar:3128");

            myProxy.Credentials = CredentialCache.DefaultCredentials;
            String loingStr = string.Format(url);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(loingStr);
            myRequest.Proxy = myProxy;
            myRequest.Method = "GET";
            response = myRequest.GetResponse();
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
                        Console.WriteLine("Error: response status = '" + statusIterator.Current.Value + "'");
                        //    return;
                    }
                }
                // get results

                XPathNodeIterator resultIterator = navigator.Select("/GeocodeResponse/result");
                while (resultIterator.MoveNext())
                {
                    XPathNodeIterator formattedAddressIterator = resultIterator.Current.Select("formatted_address");
                    while (formattedAddressIterator.MoveNext())
                    {
                        // ACA ESTA LA DIRECCION JUNTO CON LA LOCALIDAD Y PROVINCIA
                       lugar.InfoWindow = formattedAddressIterator.Current.Value.Trim();
                    }

                    XPathNodeIterator geometryIterator = resultIterator.Current.Select("geometry");
                    while (geometryIterator.MoveNext())
                    {
                        // Geometria
                        XPathNodeIterator locationIterator = geometryIterator.Current.Select("location");
                        while (locationIterator.MoveNext())
                        {

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


        }
        
        
            



        }


        catch (Exception ex)
        {
            // ACA INFORMAR ERROR SI NO SE PUDO CONECTAR A GOOGLE MAPS
            // Error al conectarse a la URL
            resultado = -1;
            Console.WriteLine(ex.Message);
        }

        finally
        {
            if (response != null)
            {
                response.Close();
                response = null;
            }
        }

        
        return ubicaciones;
    }


    public IList<GoogleMarker> GetMarkers()
   {
        System.Net.WebResponse response = null;
        double latitud=1;
        double longitud=1;
        string direccion = " ";
        try
        {
          
            string url = "https://maps.googleapis.com/maps/api/geocode/xml?address=49+1245+La%20Plata,+Buenos+Aires,+Argentina&sensor=false";
            //string url = "https://maps.googleapis.com/maps/api/geocode/xml?components=route:49|locality:La%20Plata|country:AR&sensor=false";


            WebProxy myProxy = new WebProxy();
            myProxy.Address = new Uri("http://proxy.mpba.gov.ar:3128");
        
            myProxy.Credentials = CredentialCache.DefaultCredentials;
           

            String loingStr = string.Format(url);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(loingStr);
            myRequest.Proxy = myProxy;
            myRequest.Method = "GET";
            response = myRequest.GetResponse();
        
       


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
                    Console.WriteLine("Error: response status = '" + statusIterator.Current.Value + "'");
                //    return;
                    }
                }
            // get results

                XPathNodeIterator resultIterator = navigator.Select("/GeocodeResponse/result");
                while (resultIterator.MoveNext())
                {
                    XPathNodeIterator formattedAddressIterator = resultIterator.Current.Select("formatted_address");
                    while (formattedAddressIterator.MoveNext())
                        {
                            // ACA ESTA LA DIRECCION JUNTO CON LA LOCALIDAD Y PROVINCIA
                            direccion = formattedAddressIterator.Current.Value.Trim();
                        }

                       XPathNodeIterator geometryIterator = resultIterator.Current.Select("geometry");
                       while (geometryIterator.MoveNext())
                            {
                             // Geometria
                              XPathNodeIterator locationIterator = geometryIterator.Current.Select("location");
                           while (locationIterator.MoveNext())
                             {

                           // Location

                            XPathNodeIterator latIterator = locationIterator.Current.Select("lat");

                            while (latIterator.MoveNext())

                            {
                                
                                latitud = double.Parse(latIterator.Current.Value.Trim(), CultureInfo.InvariantCulture);


                              }

                        XPathNodeIterator lngIterator = locationIterator.Current.Select("lng");

                        while (lngIterator.MoveNext())

                            {
                                longitud = double.Parse(lngIterator.Current.Value.Trim(), CultureInfo.InvariantCulture); 
                            }
                             }

                    XPathNodeIterator locationTypeIterator = geometryIterator.Current.Select("location_type");
                }
                }
                }
                }


        catch (Exception ex)
        {
            // ACA INFORMAR ERROR SI NO SE PUDO CONECTAR A GOOGLE MAPS
           Console.WriteLine(ex.Message);
        }

finally

{
    if (response != null)
    {
        response.Close();
        response = null;
    }
}
             
           var googleMarkers = new List<GoogleMarker>
                 {
                 new GoogleMarker
                       {
                       SiteName = "Taller de Electronica Malano",
                       Latitude =-34.93104290,
                       Longitude = -57.93606399999999,
                          InfoWindow = "Electronica Malano: Trabajo"
                         },
                new GoogleMarker
                     {
                    SiteName = "Mi casa",
                    Latitude = (Double) latitud,
                    Longitude = (Double) longitud,
                     //Latitude = -34.92644520,
                     //Longitude = -57.96369709999999,
                     InfoWindow = direccion,
                     },
                                        new GoogleMarker
                                            {
                                                SiteName = "Casa de la Abuela",
                                                Latitude = -34.91188410,
                                                Longitude = -57.96985850000001,
                                                InfoWindow = "Casa de la Abuela de Mariana"
                                            }
                                    };

                return googleMarkers;
            }
        }
    }

