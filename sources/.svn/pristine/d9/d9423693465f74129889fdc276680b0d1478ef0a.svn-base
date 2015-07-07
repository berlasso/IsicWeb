using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal
{
    /// <summary>
    /// The DelitosDB class is responsible for interacting with the database to retrieve and store information
    /// about Delitos objects.
    /// </summary>
    public partial class DelitosDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of Delitos from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the Delitos in the database.</param>
        /// <returns>An Delitos when the id was found in the database, or null otherwise.</returns>
        public static Delitos GetItem(int id)
        {
            Delitos myDelitos = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myDelitos = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myDelitos;
            }
        }

        /// <summary>
        /// Gets an instance of Delitos from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the Delitos in the database.</param>
        /// <returns>An Delitos when the idCausa was found in the database, or null otherwise.</returns>
        public static Delitos GetItemByIdCausa(string idCausa)
        {
            Delitos myDelitos = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectSingleItemByidCausa", myConnection))
                                                             
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idCausa", idCausa);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myDelitos = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myDelitos;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetList(BusquedaRobosDelitosSexuales Criterio)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByFiltroGeneral", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandTimeout = 200;
                    if (Criterio.FechaDesde == null)
                    { 

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@FechaDesde", Criterio.FechaDesde);
                    }
                    if (Criterio.NombreAutor == null || Criterio.NombreAutor.Trim()=="")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NombreAutor", Criterio.NombreAutor);
                    }

                    if (Criterio.ApellidoAutor == null || Criterio.ApellidoAutor.Trim()=="")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ApellidoAutor", Criterio.ApellidoAutor);
                    }
                    if (Criterio.DocNroAutor == null || Criterio.DocNroAutor==0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DocNroAutor", Criterio.DocNroAutor);
                    }


                    if (Criterio.FechaHasta == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@FechaHasta", Criterio.FechaHasta);
                    }

                    if (Criterio.HoraDesde == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HoraDesde", Criterio.HoraDesde);
                    }

                    if (Criterio.HoraHasta == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HoraHasta", Criterio.HoraHasta);
                    }

                    if (Criterio.IdClaseMomentoDelDia == null || Criterio.IdClaseMomentoDelDia ==0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseMomentoDelDia", Criterio.IdClaseMomentoDelDia);
                    }

                    if (Criterio.IdClaseDelito == null || Criterio.IdClaseDelito == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseDelito", Criterio.IdClaseDelito);
                    }

                    if (Criterio.IdDepartamento == null || Criterio.IdDepartamento.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdDepartamento", Criterio.IdDepartamento);
                    }

                    if (Criterio.IdPartido == null || Criterio.IdPartido.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdPartido", Criterio.IdPartido);
                    }

                    if (Criterio.IdLocalidad == null || Criterio.IdLocalidad == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidad", Criterio.IdLocalidad);
                    }

                    if (Criterio.ParajeBarrioH == null || Criterio.ParajeBarrioH.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ParajeBarrioH", Criterio.ParajeBarrioH);
                    }

                    if (Criterio.IdCalle == null || Criterio.IdCalle.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCalle", Criterio.IdCalle);
                    }

                    if (Criterio.IdEntreCalle1 == null || Criterio.IdEntreCalle1.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle1", Criterio.IdEntreCalle1);
                    }

                    if (Criterio.IdEntreCalle2 == null || Criterio.IdEntreCalle2.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle2", Criterio.IdEntreCalle2);
                    }

                    if (Criterio.IdOtraCalle == null || Criterio.IdOtraCalle.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraCalle", Criterio.IdOtraCalle);
                    }

                    if (Criterio.IdOtraEntreCalle == null || Criterio.IdOtraEntreCalle.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraEntreCalle", Criterio.IdOtraEntreCalle);
                    }

                    if (Criterio.IdOtraEntreCalle2 == null || Criterio.IdOtraEntreCalle2.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraEntreCalle2", Criterio.IdOtraEntreCalle2);
                    }

                    if (Criterio.NroH == null || Criterio.NroH.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NroH", Criterio.NroH);
                    }

                    if (Criterio.PisoH == null || Criterio.PisoH.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@PisoH", Criterio.PisoH);
                    }

                    if (Criterio.DeptoH == null || Criterio.DeptoH == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DeptoH", Criterio.DeptoH);
                    }

                    if (Criterio.IdComisariaH == null || Criterio.IdComisariaH.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdComisariaH", Criterio.IdComisariaH);
                    }

                    if (Criterio.IdClaseLugar == null || Criterio.IdClaseLugar == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseLugar", Criterio.IdClaseLugar);
                    }

                    if (Criterio.IdClaseRubro == null || Criterio.IdClaseRubro == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseRubro", Criterio.IdClaseRubro);
                    }

                    if (Criterio.NomReferenciaLugarRubro == null || Criterio.NomReferenciaLugarRubro.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NomReferenciaLugarRubro", Criterio.NomReferenciaLugarRubro);
                    }

                    if (Criterio.IdClaseModusOperandi == null || Criterio.IdClaseModusOperandi == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseModusOperandis", Criterio.IdClaseModusOperandi);
                    }

                    if (Criterio.IdCausa == null || Criterio.IdCausa.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCausa", Criterio.IdCausa);
                    }

                    if (Criterio.IdClaseModoArriboHuida == null || Criterio.IdClaseModoArriboHuida == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseModoArriboHuida", Criterio.IdClaseModoArriboHuida);
                    }

                    if (Criterio.IdMarcaVehiculoMO == null || Criterio.IdMarcaVehiculoMO.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdMarcaVehiculoMO", Criterio.IdMarcaVehiculoMO);
                    }

                    if (Criterio.IdModeloVehiculoMO == null || Criterio.IdModeloVehiculoMO.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdModeloVehiculoMO", Criterio.IdModeloVehiculoMO);
                    }

                    if (Criterio.DominioMO == null || Criterio.DominioMO.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DominioMO", Criterio.DominioMO);
                    }

                    if (Criterio.IdColorVehiculoMO == null || Criterio.IdColorVehiculoMO.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdColorVehiculoMO", Criterio.IdColorVehiculoMO);
                    }

                    if (Criterio.IdClaseVidrioVehiculoMO == null || Criterio.IdClaseVidrioVehiculoMO == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseVidrioVehiculoMO", Criterio.IdClaseVidrioVehiculoMO);
                    }

                    if (Criterio.IngresaronPor == null || Criterio.IngresaronPor.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IngresaronPor", Criterio.IngresaronPor);
                    }

                    if (Criterio.VictimasEnElLugar == null || Criterio.VictimasEnElLugar == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@VictimasEnElLugar", Criterio.VictimasEnElLugar);
                    }

                    if (Criterio.HuboAgresionFisicaAVictima == null || Criterio.HuboAgresionFisicaAVictima == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HuboAgresionFisicaAVictima", Criterio.HuboAgresionFisicaAVictima);
                    }

                    if (Criterio.IdClaseAgresion == null || Criterio.IdClaseAgresion == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseAgresion", Criterio.IdClaseAgresion);
                    }

                    if (Criterio.IdClaseZonaCuerpoLesionada == null || Criterio.IdClaseZonaCuerpoLesionada == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseZonaCuerpoLesionada", Criterio.IdClaseZonaCuerpoLesionada);
                    }

                    if (Criterio.VictimaTrasladadaAOtroLugar == null || Criterio.VictimaTrasladadaAOtroLugar == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@VictimaTrasladadaAOtroLugar", Criterio.VictimaTrasladadaAOtroLugar);
                    }

                    if (Criterio.IdLocalidadTraslado == null || Criterio.IdLocalidadTraslado.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidadTraslado", Criterio.IdLocalidadTraslado);
                    }

                    if (Criterio.IdPartidoL == null || Criterio.IdPartidoL.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdPartidoL", Criterio.IdPartidoL);
                    }

                    if (Criterio.idLocalidadL == null || Criterio.idLocalidadL.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidadL", Criterio.idLocalidadL);
                    }

                    if (Criterio.ParajeBarrioL == null || Criterio.ParajeBarrioL.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ParajeBarrioL", Criterio.ParajeBarrioL);
                    }

                    if (Criterio.IdCalleL == null || Criterio.IdCalleL.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCalleL", Criterio.IdCalleL);
                    }

                    if (Criterio.IdOtraCalleL == null || Criterio.IdOtraCalleL.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraCalleL", Criterio.IdOtraCalleL);
                    }

                    if (Criterio.IdEntreCalle1L == null || Criterio.IdEntreCalle1L.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle1L", Criterio.IdEntreCalle1L);
                    }

                    if (Criterio.IdEntreCalle2L == null || Criterio.IdEntreCalle2L.Trim() == "")
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle2L", Criterio.IdEntreCalle2L);
                    }
                    if (Criterio.OtraEntreCalle1L == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@OtraEntreCalle1L", Criterio.OtraEntreCalle1L);
                    }
                    
                    if (Criterio.OtraEntreCalle2L == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@OtraEntreCalle2L", Criterio.OtraEntreCalle2L);
                    }

                    if (Criterio.IdComisariaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdComisariaL", Criterio.IdComisariaL);
                    }

                    if (Criterio.UsoDeArmas == null || Criterio.UsoDeArmas == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@UsoDeArmas", Criterio.UsoDeArmas);
                    }

                    if (Criterio.IdClaseArma == null || Criterio.IdClaseArma == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseArma", Criterio.IdClaseArma);
                    }
                    if (Criterio.OtraClaseArma == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@OtraClaseArma", Criterio.OtraClaseArma);
                    }


                    if (Criterio.ExprUtilizadaComienzoDelHecho == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ExprUtilizadaComienzodelHecho", Criterio.ExprUtilizadaComienzoDelHecho);
                    }

                    if (Criterio.ExprReiteradaDuranteHecho == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ExprReiteradaDuranteHecho", Criterio.ExprReiteradaDuranteHecho);
                    }

                    if (Criterio.IdClaseCantidadAutores == null || Criterio.IdClaseCantidadAutores == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseCantidadAutores", Criterio.IdClaseCantidadAutores);
                    }

                    if (Criterio.MontoTotalEstimadoBienSustraido == null || Criterio.MontoTotalEstimadoBienSustraido == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MontoTotalEstimadoBienSustraido", Criterio.MontoTotalEstimadoBienSustraido);
                    }

                    if (Criterio.Nro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Nro", Criterio.Nro);
                    }

                    if (Criterio.IdClaseEdadAproximada == null || Criterio.IdClaseEdadAproximada == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseEdadAproximada", Criterio.IdClaseEdadAproximada);
                    }

                    if (Criterio.IdClaseSexo == null || Criterio.IdClaseSexo == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseSexo", Criterio.IdClaseSexo);
                    }

                    if (Criterio.IdClaseRostro == null || Criterio.IdClaseRostro == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseRostro", Criterio.IdClaseRostro);
                    }

                    if (Criterio.CubiertoCon == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CubiertoCon", Criterio.CubiertoCon);
                    }
                    
                    if (Criterio.IdClaseSeniaParticularL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseSeniaParticularL", Criterio.IdClaseSeniaParticularL);
                    }


                    if (Criterio.IdClaseTatuajeL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseTatuajeL", Criterio.IdClaseTatuajeL);
                    }
                    if (Criterio.idDimensionCejaL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseCejasDimensionL", Criterio.idDimensionCejaL);
                    }
                    if (Criterio.idTipoCejaL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseCejasTipoL", Criterio.idTipoCejaL);
                    }
                    if (Criterio.idClaseColorCabelloL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorCabelloL", Criterio.idClaseColorCabelloL);
                    }
                    if (Criterio.idClaseColorOjosL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorOjosL", Criterio.idClaseColorOjosL);
                    }
                    if (Criterio.idClaseColorPielL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorPielL", Criterio.idClaseColorPielL);
                    }
                    if (Criterio.idClaseEstaturaL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseEstaturaL", Criterio.idClaseEstaturaL);
                    }
                    if (Criterio.idClaseFormaCaraL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaCaraL", Criterio.idClaseFormaCaraL);
                    }
                    if (Criterio.idFormaBocaL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaBocaL", Criterio.idFormaBocaL);
                    }
                    if (Criterio.idFormaMentonL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaMentonL", Criterio.idFormaMentonL);
                    }
                    if (Criterio.idFormaLabioInferiorL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaLabioInfL", Criterio.idFormaLabioInferiorL);
                    }
                    if (Criterio.idFormaLabioSuperiorL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaLabioSupL", Criterio.idFormaLabioSuperiorL);
                    }
                    if (Criterio.idFormaNarizL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaNarizL", Criterio.idFormaNarizL);
                    }
                    if (Criterio.idFormaOrejaL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaOrejaL", Criterio.idFormaOrejaL);
                    }
                    if (Criterio.idClaseRobustezL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseRobustezL", Criterio.idClaseRobustezL);
                    }
                    if (Criterio.idClaseTipoCabelloL == null )
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseTipoCabelloL", Criterio.idClaseTipoCabelloL);
                    }
                    if (Criterio.idClaseCalvicieL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseTipoCalvicieL", Criterio.idClaseCalvicieL);
                    }
                    if (Criterio.IdClaseBienSustraido == null || Criterio.IdClaseBienSustraido == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseBienSustraido", Criterio.IdClaseBienSustraido);
                    }

                    if (Criterio.IdMarcaVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdMarcaVehiculoBS", Criterio.IdMarcaVehiculoBS);
                    }

                    if (Criterio.IdModeloVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdModeloVehiculoBS", Criterio.IdModeloVehiculoBS);
                    }

                    if (Criterio.AnioBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@AnioBS", Criterio.AnioBS);
                    }

                    if (Criterio.DominioBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DominioBS", Criterio.DominioBS);
                    }

                    if (Criterio.IdColorVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdColorVehiculoBS", Criterio.IdColorVehiculoBS);
                    }

                    if (Criterio.IdClaseVidrioVehiculoBS == null || Criterio.IdClaseVidrioVehiculoBS == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseVidrioVehiculoBS", Criterio.IdClaseVidrioVehiculoBS);
                    }

                    if (Criterio.NumeroMotorBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NumeroMotorBS", Criterio.NumeroMotorBS);
                    }

                    if (Criterio.NumeroChasisBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NumeroChasisBS", Criterio.NumeroChasisBS);
                    }

                    if (Criterio.GNCBS == null || Criterio.GNCBS == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@GNCBS", Criterio.GNCBS);
                    }

                    if (Criterio.IdentificacionGNCBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdentificacionGNCBS", Criterio.IdentificacionGNCBS);
                    }

                    if (Criterio.IdClaseGanado == null || Criterio.IdClaseGanado == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseGanado", Criterio.IdClaseGanado);
                    }

                    if (Criterio.CantidadGanado == null || Criterio.CantidadGanado == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CantidadGanado", Criterio.CantidadGanado);
                    }

                    if (Criterio.MarcaGanado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MarcaGanado", Criterio.MarcaGanado);
                    }

                    if (Criterio.MarcaBienSustraidoOtro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MarcaBienSustraidoOtro", Criterio.MarcaBienSustraidoOtro);
                    }

                    if (Criterio.NroSerieBienSustraidoOtro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NroSerieBienSustraidoOtro", Criterio.NroSerieBienSustraidoOtro);
                    }

                    if (Criterio.CantidadBienSustraidoOtro == null || Criterio.CantidadBienSustraidoOtro == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CantidadBienSustraidoOtro", Criterio.CantidadBienSustraidoOtro);
                    }

                    if (Criterio.IdVicTestRecRueda == null || Criterio.IdVicTestRecRueda == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdVicTestRecRueda", Criterio.IdVicTestRecRueda);
                    }
                    if (Criterio.IdClaseCondicionVictima == null || Criterio.IdClaseCondicionVictima == 0)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseCondicionVictima", Criterio.IdClaseCondicionVictima);
                    }

                    //if (Criterio.IdClaseCantidadAutores == null || Criterio.IdClaseCantidadAutores == 0)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@IdClaseCantAutorReconocidos", Criterio.IdClaseCantidadAutores);
                    //}

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListSoloAutoresConocidos(BusquedaRobosDelitosSexuales Criterio)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByFiltroGeneralAutoresConocidos", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    if (Criterio.FechaDesde == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@FechaDesde", Criterio.FechaDesde);
                    }
                    if (Criterio.NombreAutor == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NombreAutor", Criterio.NombreAutor);
                    }

                    if (Criterio.ApellidoAutor == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ApellidoAutor", Criterio.ApellidoAutor);
                    }
                    if (Criterio.DocNroAutor == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DocNroAutor", Criterio.DocNroAutor);
                    }


                    if (Criterio.FechaHasta == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@FechaHasta", Criterio.FechaHasta);
                    }

                    if (Criterio.HoraDesde == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HoraDesde", Criterio.HoraDesde);
                    }

                    if (Criterio.HoraHasta == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HoraHasta", Criterio.HoraHasta);
                    }

                    if (Criterio.IdClaseMomentoDelDia == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseMomentoDelDia", Criterio.IdClaseMomentoDelDia);
                    }

                    if (Criterio.IdClaseDelito == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseDelito", Criterio.IdClaseDelito);
                    }

                    if (Criterio.IdDepartamento == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdDepartamento", Criterio.IdDepartamento);
                    }

                    if (Criterio.IdPartido == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdPartido", Criterio.IdPartido);
                    }

                    if (Criterio.IdLocalidad == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidad", Criterio.IdLocalidad);
                    }

                    if (Criterio.ParajeBarrioH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ParajeBarrioH", Criterio.ParajeBarrioH);
                    }

                    if (Criterio.IdCalle == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCalle", Criterio.IdCalle);
                    }

                    if (Criterio.IdEntreCalle1 == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle1", Criterio.IdEntreCalle1);
                    }

                    if (Criterio.IdEntreCalle2 == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle2", Criterio.IdEntreCalle2);
                    }

                    if (Criterio.IdOtraCalle == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraCalle", Criterio.IdOtraCalle);
                    }

                    if (Criterio.IdOtraEntreCalle == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraEntreCalle", Criterio.IdOtraEntreCalle);
                    }

                    if (Criterio.IdOtraEntreCalle2 == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraEntreCalle2", Criterio.IdOtraEntreCalle2);
                    }

                    if (Criterio.NroH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NroH", Criterio.NroH);
                    }

                    if (Criterio.PisoH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@PisoH", Criterio.PisoH);
                    }

                    if (Criterio.DeptoH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DeptoH", Criterio.DeptoH);
                    }

                    if (Criterio.IdComisariaH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdComisariaH", Criterio.IdComisariaH);
                    }

                    if (Criterio.IdClaseLugar == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseLugar", Criterio.IdClaseLugar);
                    }

                    if (Criterio.IdClaseRubro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseRubro", Criterio.IdClaseRubro);
                    }

                    if (Criterio.NomReferenciaLugarRubro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NomReferenciaLugarRubro", Criterio.NomReferenciaLugarRubro);
                    }

                    if (Criterio.IdClaseModusOperandi == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseModusOperandis", Criterio.IdClaseModusOperandi);
                    }

                    if (Criterio.IdCausa == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCausa", Criterio.IdCausa);
                    }

                    if (Criterio.IdClaseModoArriboHuida == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseModoArriboHuida", Criterio.IdClaseModoArriboHuida);
                    }

                    if (Criterio.IdMarcaVehiculoMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdMarcaVehiculoMO", Criterio.IdMarcaVehiculoMO);
                    }

                    if (Criterio.IdModeloVehiculoMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdModeloVehiculoMO", Criterio.IdModeloVehiculoMO);
                    }

                    if (Criterio.DominioMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DominioMO", Criterio.DominioMO);
                    }

                    if (Criterio.IdColorVehiculoMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdColorVehiculoMO", Criterio.IdColorVehiculoMO);
                    }

                    if (Criterio.IdClaseVidrioVehiculoMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseVidrioVehiculoMO", Criterio.IdClaseVidrioVehiculoMO);
                    }

                    if (Criterio.IngresaronPor == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IngresaronPor", Criterio.IngresaronPor);
                    }

                    if (Criterio.VictimasEnElLugar == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@VictimasEnElLugar", Criterio.VictimasEnElLugar);
                    }

                    if (Criterio.HuboAgresionFisicaAVictima == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HuboAgresionFisicaAVictima", Criterio.HuboAgresionFisicaAVictima);
                    }

                    if (Criterio.IdClaseAgresion == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseAgresion", Criterio.IdClaseAgresion);
                    }

                    if (Criterio.IdClaseZonaCuerpoLesionada == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseZonaCuerpoLesionada", Criterio.IdClaseZonaCuerpoLesionada);
                    }

                    if (Criterio.VictimaTrasladadaAOtroLugar == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@VictimaTrasladadaAOtroLugar", Criterio.VictimaTrasladadaAOtroLugar);
                    }

                    if (Criterio.IdLocalidadTraslado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidadTraslado", Criterio.IdLocalidadTraslado);
                    }

                    if (Criterio.IdPartidoL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdPartidoL", Criterio.IdPartidoL);
                    }

                    if (Criterio.idLocalidadL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidadL", Criterio.idLocalidadL);
                    }

                    if (Criterio.ParajeBarrioL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ParajeBarrioL", Criterio.ParajeBarrioL);
                    }

                    if (Criterio.IdCalleL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCalleL", Criterio.IdCalleL);
                    }

                    if (Criterio.IdOtraCalleL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraCalleL", Criterio.IdOtraCalleL);
                    }

                    if (Criterio.IdEntreCalle1L == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle1L", Criterio.IdEntreCalle1L);
                    }

                    if (Criterio.IdEntreCalle2L == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle2L", Criterio.IdEntreCalle2L);
                    }

                    if (Criterio.OtraEntreCalle2L == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@OtraEntreCalle2L", Criterio.OtraEntreCalle2L);
                    }

                    if (Criterio.IdComisariaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdComisariaL", Criterio.IdComisariaL);
                    }

                    if (Criterio.UsoDeArmas == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@UsoDeArmas", Criterio.UsoDeArmas);
                    }

                    if (Criterio.IdClaseArma == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseArma", Criterio.IdClaseArma);
                    }
                    if (Criterio.OtraClaseArma == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@OtraClaseArma", Criterio.OtraClaseArma);
                    }


                    if (Criterio.ExprUtilizadaComienzoDelHecho == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ExprUtilizadaComienzodelHecho", Criterio.ExprUtilizadaComienzoDelHecho);
                    }

                    if (Criterio.ExprReiteradaDuranteHecho == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ExprReiteradaDuranteHecho", Criterio.ExprReiteradaDuranteHecho);
                    }

                    if (Criterio.IdClaseCantidadAutores == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseCantidadAutores", Criterio.IdClaseCantidadAutores);
                    }

                    if (Criterio.MontoTotalEstimadoBienSustraido == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MontoTotalEstimadoBienSustraido", Criterio.MontoTotalEstimadoBienSustraido);
                    }

                    if (Criterio.Nro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Nro", Criterio.Nro);
                    }

                    if (Criterio.IdClaseEdadAproximada == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseEdadAproximada", Criterio.IdClaseEdadAproximada);
                    }

                    if (Criterio.IdClaseSexo == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseSexo", Criterio.IdClaseSexo);
                    }

                    if (Criterio.IdClaseRostro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseRostro", Criterio.IdClaseRostro);
                    }

                    if (Criterio.CubiertoCon == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CubiertoCon", Criterio.CubiertoCon);
                    }

                    if (Criterio.IdClaseSeniaParticularL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseSeniaParticularL", Criterio.IdClaseSeniaParticularL);
                    }

                    //if (Criterio.UbicacionSeniaParticular == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@UbicacionSeniaParticular", Criterio.UbicacionSeniaParticular);
                    //}

                    //if (Criterio.IdClaseLugarDelCuerpo == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@IdClaseLugarDelCuerpo", Criterio.IdClaseLugarDelCuerpo);
                    //}

                    if (Criterio.IdClaseTatuajeL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseTatuajeL", Criterio.IdClaseTatuajeL);
                    }

                    //if (Criterio.OtroTatuaje == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@OtroTatuaje", Criterio.OtroTatuaje);
                    //}

                    //if (Criterio.OtraCaracteristica == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@OtraCaracteristica", Criterio.OtraCaracteristica);
                    //}
                    if (Criterio.idDimensionCejaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseCejasDimensionL", Criterio.idDimensionCejaL);
                    }
                    if (Criterio.idTipoCejaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseCejasTipoL", Criterio.idTipoCejaL);
                    }
                    if (Criterio.idClaseColorCabelloL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorCabelloL", Criterio.idClaseColorCabelloL);
                    }
                    if (Criterio.idClaseColorOjosL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorOjosL", Criterio.idClaseColorOjosL);
                    }
                    if (Criterio.idClaseColorPielL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorPielL", Criterio.idClaseColorPielL);
                    }
                    if (Criterio.idClaseEstaturaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseEstaturaL", Criterio.idClaseEstaturaL);
                    }
                    if (Criterio.idClaseFormaCaraL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaCaraL", Criterio.idClaseFormaCaraL);
                    }
                    if (Criterio.idFormaBocaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaBocaL", Criterio.idFormaBocaL);
                    }
                    if (Criterio.idFormaMentonL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaMentonL", Criterio.idFormaMentonL);
                    }
                    if (Criterio.idFormaLabioInferiorL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue(" @idSICClaseFormaLabioInfL", Criterio.idFormaLabioInferiorL);
                    }
                    if (Criterio.idFormaLabioSuperiorL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaLabioSupL", Criterio.idFormaLabioSuperiorL);
                    }
                    if (Criterio.idFormaNarizL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaNarizL", Criterio.idFormaNarizL);
                    }
                    if (Criterio.idFormaOrejaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaOrejaL", Criterio.idFormaOrejaL);
                    }
                    if (Criterio.idClaseRobustezL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseRobustezL", Criterio.idClaseRobustezL);
                    }
                    if (Criterio.idClaseTipoCabelloL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseTipoCabelloL", Criterio.idClaseTipoCabelloL);
                    }
                    if (Criterio.idClaseCalvicieL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseTipoCalvicieL", Criterio.idClaseCalvicieL);
                    }

                    if (Criterio.IdClaseBienSustraido == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseBienSustraido", Criterio.IdClaseBienSustraido);
                    }

                    if (Criterio.IdMarcaVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdMarcaVehiculoBS", Criterio.IdMarcaVehiculoBS);
                    }

                    if (Criterio.IdModeloVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdModeloVehiculoBS", Criterio.IdModeloVehiculoBS);
                    }

                    if (Criterio.AnioBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@AnioBS", Criterio.AnioBS);
                    }

                    if (Criterio.DominioBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DominioBS", Criterio.DominioBS);
                    }

                    if (Criterio.IdColorVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdColorVehiculoBS", Criterio.IdColorVehiculoBS);
                    }

                    if (Criterio.IdClaseVidrioVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseVidrioVehiculoBS", Criterio.IdClaseVidrioVehiculoBS);
                    }

                    if (Criterio.NumeroMotorBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NumeroMotorBS", Criterio.NumeroMotorBS);
                    }

                    if (Criterio.NumeroChasisBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NumeroChasisBS", Criterio.NumeroChasisBS);
                    }

                    if (Criterio.GNCBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@GNCBS", Criterio.GNCBS);
                    }

                    if (Criterio.IdentificacionGNCBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdentificacionGNCBS", Criterio.IdentificacionGNCBS);
                    }

                    if (Criterio.IdClaseGanado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseGanado", Criterio.IdClaseGanado);
                    }

                    if (Criterio.CantidadGanado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CantidadGanado", Criterio.CantidadGanado);
                    }

                    if (Criterio.MarcaGanado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MarcaGanado", Criterio.MarcaGanado);
                    }

                    if (Criterio.MarcaBienSustraidoOtro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MarcaBienSustraidoOtro", Criterio.MarcaBienSustraidoOtro);
                    }

                    if (Criterio.NroSerieBienSustraidoOtro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NroSerieBienSustraidoOtro", Criterio.NroSerieBienSustraidoOtro);
                    }

                    if (Criterio.CantidadBienSustraidoOtro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CantidadBienSustraidoOtro", Criterio.CantidadBienSustraidoOtro);
                    }

                    if (Criterio.IdVicTestRecRueda == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdVicTestRecRueda", Criterio.IdVicTestRecRueda);
                    }
                    if (Criterio.IdClaseCondicionVictima == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseCondicionVictima", Criterio.IdClaseCondicionVictima);
                    }

                    //if (Criterio.IdClaseCantidadAutores == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@IdClaseCantAutorReconocidos", Criterio.IdClaseCantidadAutores);
                    //}

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListSoloAutoresDesconocidos(BusquedaRobosDelitosSexuales Criterio)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByFiltroGeneralAutoresDesconocidos", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    if (Criterio.FechaDesde == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@FechaDesde", Criterio.FechaDesde);
                    }
                    if (Criterio.NombreAutor == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NombreAutor", Criterio.NombreAutor);
                    }

                    if (Criterio.ApellidoAutor == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ApellidoAutor", Criterio.ApellidoAutor);
                    }
                    if (Criterio.DocNroAutor == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DocNroAutor", Criterio.DocNroAutor);
                    }


                    if (Criterio.FechaHasta == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@FechaHasta", Criterio.FechaHasta);
                    }

                    if (Criterio.HoraDesde == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HoraDesde", Criterio.HoraDesde);
                    }

                    if (Criterio.HoraHasta == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HoraHasta", Criterio.HoraHasta);
                    }

                    if (Criterio.IdClaseMomentoDelDia == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseMomentoDelDia", Criterio.IdClaseMomentoDelDia);
                    }

                    if (Criterio.IdClaseDelito == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseDelito", Criterio.IdClaseDelito);
                    }

                    if (Criterio.IdDepartamento == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdDepartamento", Criterio.IdDepartamento);
                    }

                    if (Criterio.IdPartido == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdPartido", Criterio.IdPartido);
                    }

                    if (Criterio.IdLocalidad == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidad", Criterio.IdLocalidad);
                    }

                    if (Criterio.ParajeBarrioH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ParajeBarrioH", Criterio.ParajeBarrioH);
                    }

                    if (Criterio.IdCalle == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCalle", Criterio.IdCalle);
                    }

                    if (Criterio.IdEntreCalle1 == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle1", Criterio.IdEntreCalle1);
                    }

                    if (Criterio.IdEntreCalle2 == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle2", Criterio.IdEntreCalle2);
                    }

                    if (Criterio.IdOtraCalle == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraCalle", Criterio.IdOtraCalle);
                    }

                    if (Criterio.IdOtraEntreCalle == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraEntreCalle", Criterio.IdOtraEntreCalle);
                    }

                    if (Criterio.IdOtraEntreCalle2 == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraEntreCalle2", Criterio.IdOtraEntreCalle2);
                    }

                    if (Criterio.NroH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NroH", Criterio.NroH);
                    }

                    if (Criterio.PisoH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@PisoH", Criterio.PisoH);
                    }

                    if (Criterio.DeptoH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DeptoH", Criterio.DeptoH);
                    }

                    if (Criterio.IdComisariaH == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdComisariaH", Criterio.IdComisariaH);
                    }

                    if (Criterio.IdClaseLugar == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseLugar", Criterio.IdClaseLugar);
                    }

                    if (Criterio.IdClaseRubro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseRubro", Criterio.IdClaseRubro);
                    }

                    if (Criterio.NomReferenciaLugarRubro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NomReferenciaLugarRubro", Criterio.NomReferenciaLugarRubro);
                    }

                    if (Criterio.IdClaseModusOperandi == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseModusOperandis", Criterio.IdClaseModusOperandi);
                    }

                    if (Criterio.IdCausa == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCausa", Criterio.IdCausa);
                    }

                    if (Criterio.IdClaseModoArriboHuida == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseModoArriboHuida", Criterio.IdClaseModoArriboHuida);
                    }

                    if (Criterio.IdMarcaVehiculoMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdMarcaVehiculoMO", Criterio.IdMarcaVehiculoMO);
                    }

                    if (Criterio.IdModeloVehiculoMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdModeloVehiculoMO", Criterio.IdModeloVehiculoMO);
                    }

                    if (Criterio.DominioMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DominioMO", Criterio.DominioMO);
                    }

                    if (Criterio.IdColorVehiculoMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdColorVehiculoMO", Criterio.IdColorVehiculoMO);
                    }

                    if (Criterio.IdClaseVidrioVehiculoMO == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseVidrioVehiculoMO", Criterio.IdClaseVidrioVehiculoMO);
                    }

                    if (Criterio.IngresaronPor == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IngresaronPor", Criterio.IngresaronPor);
                    }

                    if (Criterio.VictimasEnElLugar == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@VictimasEnElLugar", Criterio.VictimasEnElLugar);
                    }

                    if (Criterio.HuboAgresionFisicaAVictima == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@HuboAgresionFisicaAVictima", Criterio.HuboAgresionFisicaAVictima);
                    }

                    if (Criterio.IdClaseAgresion == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseAgresion", Criterio.IdClaseAgresion);
                    }

                    if (Criterio.IdClaseZonaCuerpoLesionada == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseZonaCuerpoLesionada", Criterio.IdClaseZonaCuerpoLesionada);
                    }

                    if (Criterio.VictimaTrasladadaAOtroLugar == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@VictimaTrasladadaAOtroLugar", Criterio.VictimaTrasladadaAOtroLugar);
                    }

                    if (Criterio.IdLocalidadTraslado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidadTraslado", Criterio.IdLocalidadTraslado);
                    }

                    if (Criterio.IdPartidoL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdPartidoL", Criterio.IdPartidoL);
                    }

                    if (Criterio.idLocalidadL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidadL", Criterio.idLocalidadL);
                    }

                    if (Criterio.ParajeBarrioL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ParajeBarrioL", Criterio.ParajeBarrioL);
                    }

                    if (Criterio.IdCalleL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCalleL", Criterio.IdCalleL);
                    }

                    if (Criterio.IdOtraCalleL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdOtraCalleL", Criterio.IdOtraCalleL);
                    }

                    if (Criterio.IdEntreCalle1L == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle1L", Criterio.IdEntreCalle1L);
                    }

                    if (Criterio.IdEntreCalle2L == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdEntreCalle2L", Criterio.IdEntreCalle2L);
                    }

                    if (Criterio.OtraEntreCalle2L == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@OtraEntreCalle2L", Criterio.OtraEntreCalle2L);
                    }

                    if (Criterio.IdComisariaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdComisariaL", Criterio.IdComisariaL);
                    }

                    if (Criterio.UsoDeArmas == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@UsoDeArmas", Criterio.UsoDeArmas);
                    }

                    if (Criterio.IdClaseArma == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseArma", Criterio.IdClaseArma);
                    }
                    if (Criterio.OtraClaseArma == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@OtraClaseArma", Criterio.OtraClaseArma);
                    }


                    if (Criterio.ExprUtilizadaComienzoDelHecho == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ExprUtilizadaComienzodelHecho", Criterio.ExprUtilizadaComienzoDelHecho);
                    }

                    if (Criterio.ExprReiteradaDuranteHecho == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ExprReiteradaDuranteHecho", Criterio.ExprReiteradaDuranteHecho);
                    }

                    if (Criterio.IdClaseCantidadAutores == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseCantidadAutores", Criterio.IdClaseCantidadAutores);
                    }

                    if (Criterio.MontoTotalEstimadoBienSustraido == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MontoTotalEstimadoBienSustraido", Criterio.MontoTotalEstimadoBienSustraido);
                    }

                    if (Criterio.Nro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Nro", Criterio.Nro);
                    }

                    if (Criterio.IdClaseEdadAproximada == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseEdadAproximada", Criterio.IdClaseEdadAproximada);
                    }

                    if (Criterio.IdClaseSexo == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseSexo", Criterio.IdClaseSexo);
                    }

                    if (Criterio.IdClaseRostro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseRostro", Criterio.IdClaseRostro);
                    }

                    if (Criterio.CubiertoCon == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CubiertoCon", Criterio.CubiertoCon);
                    }

                    if (Criterio.IdClaseSeniaParticularL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseSeniaParticularL", Criterio.IdClaseSeniaParticularL);
                    }

                    //if (Criterio.UbicacionSeniaParticular == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@UbicacionSeniaParticular", Criterio.UbicacionSeniaParticular);
                    //}

                    //if (Criterio.IdClaseLugarDelCuerpo == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@IdClaseLugarDelCuerpo", Criterio.IdClaseLugarDelCuerpo);
                    //}

                    if (Criterio.IdClaseTatuajeL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseTatuajeL", Criterio.IdClaseTatuajeL);
                    }
                    if (Criterio.idDimensionCejaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseCejasDimensionL", Criterio.idDimensionCejaL);
                    }
                    if (Criterio.idTipoCejaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseCejasTipoL", Criterio.idTipoCejaL);
                    }
                    if (Criterio.idClaseColorCabelloL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorCabelloL", Criterio.idClaseColorCabelloL);
                    }
                    if (Criterio.idClaseColorOjosL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorOjosL", Criterio.idClaseColorOjosL);
                    }
                    if (Criterio.idClaseColorPielL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseColorPielL", Criterio.idClaseColorPielL);
                    }
                    if (Criterio.idClaseEstaturaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idClaseEstaturaL", Criterio.idClaseEstaturaL);
                    }
                    if (Criterio.idClaseFormaCaraL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaCaraL", Criterio.idClaseFormaCaraL);
                    }
                    if (Criterio.idFormaBocaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaBocaL", Criterio.idFormaBocaL);
                    }
                    if (Criterio.idFormaMentonL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaMentonL", Criterio.idFormaMentonL);
                    }
                    if (Criterio.idFormaLabioInferiorL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue(" @idSICClaseFormaLabioInfL", Criterio.idFormaLabioInferiorL);
                    }
                    if (Criterio.idFormaLabioSuperiorL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaLabioSupL", Criterio.idFormaLabioSuperiorL);
                    }
                    if (Criterio.idFormaNarizL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaNarizL", Criterio.idFormaNarizL);
                    }
                    if (Criterio.idFormaOrejaL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseFormaOrejaL", Criterio.idFormaOrejaL);
                    }
                    if (Criterio.idClaseRobustezL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseRobustezL", Criterio.idClaseRobustezL);
                    }
                    if (Criterio.idClaseTipoCabelloL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseTipoCabelloL", Criterio.idClaseTipoCabelloL);
                    }
                    if (Criterio.idClaseCalvicieL == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSICClaseTipoCalvicieL", Criterio.idClaseCalvicieL);
                    }
                    //if (Criterio.OtroTatuaje == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@OtroTatuaje", Criterio.OtroTatuaje);
                    //}

                    //if (Criterio.OtraCaracteristica == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@OtraCaracteristica", Criterio.OtraCaracteristica);
                    //}

                    if (Criterio.IdClaseBienSustraido == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseBienSustraido", Criterio.IdClaseBienSustraido);
                    }

                    if (Criterio.IdMarcaVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdMarcaVehiculoBS", Criterio.IdMarcaVehiculoBS);
                    }

                    if (Criterio.IdModeloVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdModeloVehiculoBS", Criterio.IdModeloVehiculoBS);
                    }

                    if (Criterio.AnioBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@AnioBS", Criterio.AnioBS);
                    }

                    if (Criterio.DominioBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DominioBS", Criterio.DominioBS);
                    }

                    if (Criterio.IdColorVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdColorVehiculoBS", Criterio.IdColorVehiculoBS);
                    }

                    if (Criterio.IdClaseVidrioVehiculoBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseVidrioVehiculoBS", Criterio.IdClaseVidrioVehiculoBS);
                    }

                    if (Criterio.NumeroMotorBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NumeroMotorBS", Criterio.NumeroMotorBS);
                    }

                    if (Criterio.NumeroChasisBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NumeroChasisBS", Criterio.NumeroChasisBS);
                    }

                    if (Criterio.GNCBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@GNCBS", Criterio.GNCBS);
                    }

                    if (Criterio.IdentificacionGNCBS == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdentificacionGNCBS", Criterio.IdentificacionGNCBS);
                    }

                    if (Criterio.IdClaseGanado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseGanado", Criterio.IdClaseGanado);
                    }

                    if (Criterio.CantidadGanado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CantidadGanado", Criterio.CantidadGanado);
                    }

                    if (Criterio.MarcaGanado == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MarcaGanado", Criterio.MarcaGanado);
                    }

                    if (Criterio.MarcaBienSustraidoOtro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@MarcaBienSustraidoOtro", Criterio.MarcaBienSustraidoOtro);
                    }

                    if (Criterio.NroSerieBienSustraidoOtro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@NroSerieBienSustraidoOtro", Criterio.NroSerieBienSustraidoOtro);
                    }

                    if (Criterio.CantidadBienSustraidoOtro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@CantidadBienSustraidoOtro", Criterio.CantidadBienSustraidoOtro);
                    }

                    if (Criterio.IdVicTestRecRueda == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdVicTestRecRueda", Criterio.IdVicTestRecRueda);
                    }
                    if (Criterio.IdClaseCondicionVictima == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdClaseCondicionVictima", Criterio.IdClaseCondicionVictima);
                    }

                    //if (Criterio.IdClaseCantidadAutores == null)
                    //{

                    //}
                    //else
                    //{
                    //    myCommand.Parameters.AddWithValue("@IdClaseCantAutorReconocidos", Criterio.IdClaseCantidadAutores);
                    //}

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }


        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetList()
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectList", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tempList;
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseAgresion(int idClaseAgresion)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseAgresion", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseAgresion", idClaseAgresion);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidTipoAutor(int idTipoAutor)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseTipoAutor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idTipoAutor", idTipoAutor);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }


        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseDelito(int idClaseDelito)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseDelito", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseDelito", idClaseDelito);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseArma(int idClaseArma)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseArma", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseArma", idClaseArma);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }


        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseSubTipoArma(short idClaseSubTipoArma)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseSubTipoArma", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseSubtipoArma", idClaseSubTipoArma);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }
        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseCantAutorReconocidos(int idClaseCantAutorReconocidos)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseCantAutorReconocidos", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseCantAutorReconocidos", idClaseCantAutorReconocidos);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseCantidadAutores(int idClaseCantidadAutores)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseCantidadAutores", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseCantidadAutores", idClaseCantidadAutores);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidVicTestRecRueda(int idVicTestRecRueda)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidVicTestRecRueda", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idVicTestRecRueda", idVicTestRecRueda);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseCondicionVictima(int idClaseCondicionVictima)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseCondicionVictima", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseCondicionVictima", idClaseCondicionVictima);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseFecha(int idClaseFecha)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseFecha", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseFecha", idClaseFecha);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseHora(int idClaseHora)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseHora", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseHora", idClaseHora);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseLugar(int idClaseLugar)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseLugar", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseLugar", idClaseLugar);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseModoArriboHuida(int idClaseModoArriboHuida)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseModoArriboHuida", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseModoArriboHuida", idClaseModoArriboHuida);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseModusOperandis(int idClaseModusOperandis)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseModusOperandis", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseModusOperandis", idClaseModusOperandis);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseMomentoDelDia(int idClaseMomentoDelDia)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseMomentoDelDia", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseMomentoDelDia", idClaseMomentoDelDia);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseRubro(int idClaseRubro)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseRubro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseRubro", idClaseRubro);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidClaseZonaCuerpoLesionada(int idClaseZonaCuerpoLesionada)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidClaseZonaCuerpoLesionada", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseZonaCuerpoLesionada", idClaseZonaCuerpoLesionada);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidComisariaH(int idComisariaH)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidComisariaH", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idComisariaH", idComisariaH);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidComisariaL(int idComisariaL)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidComisariaL", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idComisariaL", idComisariaL);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }
        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidLocalidad(int idLocalidad)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidLocalidad", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idLocalidad", idLocalidad);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidLocalidadL(int idLocalidadL)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidLocalidadL", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idLocalidadL", idLocalidadL);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByHuboAgresionFisicaAVictima(int HuboAgresionFisicaAVictima)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByHuboAgresionFisicaAVictima", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@huboAgresionFisicaAVictima", HuboAgresionFisicaAVictima);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByUsoDeArmas(int UsoDeArmas)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByUsoDeArmas", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@usoDeArmas", UsoDeArmas);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByVictimasEnElLugar(int VictimasEnElLugar)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByVictimasEnElLugar", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@victimasEnElLugar", VictimasEnElLugar);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByVictimaTrasladadaAOtroLugar(int VictimaTrasladadaAOtroLugar)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByVictimaTrasladadaAOtroLugar", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@victimaTrasladadaAOtroLugar", VictimaTrasladadaAOtroLugar);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidPartidoL(int idPartidoL)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidPartidoL", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idPartidoL", idPartidoL);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Delitos objects.
        /// </summary>
        /// <returns>A generics List with the Delitos objects.</returns>
        public static DelitosList GetListByidPartido(int idPartido)
        {
            DelitosList tempList = new DelitosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosSelectListByidPartido", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idPartido", idPartido);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }


/// <summary>
/// Saves a Delitos in the database.
/// </summary>
/// <param name="myDelitos">The Delitos instance to save.</param>
/// <returns>The new id if the Delitos is new in the database or the existing id when an item was updated.</returns>
public static int Save(Delitos myDelitos, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("DelitosInsertUpdateSingleItem", myConnection))
    //{
    try
    {
        myCommand.CommandText = "DelitosInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();

        if (myDelitos.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myDelitos.id);
        }
        if (string.IsNullOrEmpty(myDelitos.idCausa))
        {
            myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idCausa", myDelitos.idCausa);
        }

        myCommand.Parameters.AddWithValue("@idClaseFecha", myDelitos.idClaseFecha);

        if (myDelitos.FechaDesde == null)
        {
            myCommand.Parameters.AddWithValue("@fechaDesde", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaDesde", myDelitos.FechaDesde);
        }
        if (myDelitos.FechaHasta == null)
        {
            myCommand.Parameters.AddWithValue("@fechaHasta", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaHasta", myDelitos.FechaHasta);
        }

        myCommand.Parameters.AddWithValue("@idClaseHora", myDelitos.idClaseHora);

        if (myDelitos.HoraDesde == null)
        {
            myCommand.Parameters.AddWithValue("@horaDesde", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@horaDesde", myDelitos.HoraDesde);
        }
        if (myDelitos.HoraHasta == null)
        {
            myCommand.Parameters.AddWithValue("@horaHasta", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@horaHasta", myDelitos.HoraHasta);
        }

        myCommand.Parameters.AddWithValue("@idClaseMomentoDelDia", myDelitos.idClaseMomentoDelDia);


        myCommand.Parameters.AddWithValue("@idPartido", myDelitos.idPartido);


        myCommand.Parameters.AddWithValue("@idLocalidad", myDelitos.idLocalidad);


        myCommand.Parameters.AddWithValue("@idCalle", myDelitos.idCalle);

        if (string.IsNullOrEmpty(myDelitos.idOtraCalle))
        {
            myCommand.Parameters.AddWithValue("@idOtraCalle", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idOtraCalle", myDelitos.idOtraCalle);
        }

        myCommand.Parameters.AddWithValue("@idEntreCalle1", myDelitos.idEntreCalle1);

        if (string.IsNullOrEmpty(myDelitos.idOtraEntreCalle))
        {
            myCommand.Parameters.AddWithValue("@idOtraEntreCalle", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idOtraEntreCalle", myDelitos.idOtraEntreCalle);
        }

        myCommand.Parameters.AddWithValue("@idEntreCalle2", myDelitos.idEntreCalle2);

        if (string.IsNullOrEmpty(myDelitos.idOtraEntreCalle2))
        {
            myCommand.Parameters.AddWithValue("@idOtraEntreCalle2", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idOtraEntreCalle2", myDelitos.idOtraEntreCalle2);
        }
        if (string.IsNullOrEmpty(myDelitos.NroH))
        {
            myCommand.Parameters.AddWithValue("@nroH", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@nroH", myDelitos.NroH);
        }
        if (string.IsNullOrEmpty(myDelitos.PisoH))
        {
            myCommand.Parameters.AddWithValue("@pisoH", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@pisoH", myDelitos.PisoH);
        }
        if (string.IsNullOrEmpty(myDelitos.DeptoH))
        {
            myCommand.Parameters.AddWithValue("@deptoH", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@deptoH", myDelitos.DeptoH);
        }
        if (string.IsNullOrEmpty(myDelitos.ParajeBarrioH))
        {
            myCommand.Parameters.AddWithValue("@parajeBarrioH", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@parajeBarrioH", myDelitos.ParajeBarrioH);
        }

        myCommand.Parameters.AddWithValue("@idComisariaH", myDelitos.idComisariaH);


        myCommand.Parameters.AddWithValue("@idClaseLugar", myDelitos.idClaseLugar);


        myCommand.Parameters.AddWithValue("@idClaseRubro", myDelitos.idClaseRubro);


        myCommand.Parameters.AddWithValue("@idClaseModoArriboHuida", myDelitos.idClaseModoArriboHuida);


        myCommand.Parameters.AddWithValue("@idClaseModusOperandis", myDelitos.idClaseModusOperandis);

        if (string.IsNullOrEmpty(myDelitos.NomRefLugarRubro))
        {
            myCommand.Parameters.AddWithValue("@NomRefLugarRubro", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@NomRefLugarRubro", myDelitos.NomRefLugarRubro);
        }

       
        if (string.IsNullOrEmpty(myDelitos.ExprUtilizadaComienzoDelHecho))
        {
            myCommand.Parameters.AddWithValue("@exprUtilizadaComienzoDelHecho", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@exprUtilizadaComienzoDelHecho", myDelitos.ExprUtilizadaComienzoDelHecho);
        }
        if (string.IsNullOrEmpty(myDelitos.ExprReiteradaDuranteHecho))
        {
            myCommand.Parameters.AddWithValue("@exprReiteradaDuranteHecho", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@exprReiteradaDuranteHecho", myDelitos.ExprReiteradaDuranteHecho);
        }
        if (string.IsNullOrEmpty(myDelitos.IngresaronPor))
        {
            myCommand.Parameters.AddWithValue("@ingresaronPor", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@ingresaronPor", myDelitos.IngresaronPor);
        }

        myCommand.Parameters.AddWithValue("@victimasEnElLugar", myDelitos.VictimasEnElLugar);

        myCommand.Parameters.AddWithValue("@usoDeArmas", myDelitos.UsoDeArmas);

        myCommand.Parameters.AddWithValue("@idClaseArma", myDelitos.idClaseArma);

        myCommand.Parameters.AddWithValue("@idClaseSubtipoArma", myDelitos.idClaseSubtipoArma);

        myCommand.Parameters.AddWithValue("@huboAgresionFisicaAVictima", myDelitos.HuboAgresionFisicaAVictima);

        myCommand.Parameters.AddWithValue("@idClaseAgresion", myDelitos.idClaseAgresion);

        myCommand.Parameters.AddWithValue("@idClaseZonaCuerpoLesionada", myDelitos.idClaseZonaCuerpoLesionada);

        myCommand.Parameters.AddWithValue("@victimaTrasladadaAOtroLugar", myDelitos.VictimaTrasladadaAOtroLugar);

        myCommand.Parameters.AddWithValue("@idPartidoL", myDelitos.idPartidoL);

        myCommand.Parameters.AddWithValue("@idLocalidadL", myDelitos.idLocalidadL);

        myCommand.Parameters.AddWithValue("@idCalleL", myDelitos.idCalleL);

        if (string.IsNullOrEmpty(myDelitos.idOtraCalleL))
        {
            myCommand.Parameters.AddWithValue("@idOtraCalleL", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idOtraCalleL", myDelitos.idOtraCalleL);
        }

        myCommand.Parameters.AddWithValue("@idEntreCalle1L", myDelitos.idEntreCalle1L);

        if (string.IsNullOrEmpty(myDelitos.OtraEntreCalle1L))
        {
            myCommand.Parameters.AddWithValue("@otraEntreCalle1L", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@otraEntreCalle1L", myDelitos.OtraEntreCalle1L);
        }
        myCommand.Parameters.AddWithValue("@idEntreCalle2L", myDelitos.idEntreCalle2L);

        if (string.IsNullOrEmpty(myDelitos.OtraEntreCalle2L))
        {
            myCommand.Parameters.AddWithValue("@otraEntreCalle2L", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@otraEntreCalle2L", myDelitos.OtraEntreCalle2L);
        }
        if (string.IsNullOrEmpty(myDelitos.ParajeBarrioL))
        {
            myCommand.Parameters.AddWithValue("@parajeBarrioL", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@parajeBarrioL", myDelitos.ParajeBarrioL);
        }
        myCommand.Parameters.AddWithValue("@idComisariaL", myDelitos.idComisariaL);

        myCommand.Parameters.AddWithValue("@idClaseCantidadAutores", myDelitos.idClaseCantidadAutores);

        myCommand.Parameters.AddWithValue("@montoTotalEstimadoBienSustraido", myDelitos.MontoTotalEstimadoBienSustraido);

        myCommand.Parameters.AddWithValue("@idVicTestRecRueda", myDelitos.idVicTestRecRueda);

        myCommand.Parameters.AddWithValue("@idClaseCondicionVictima", myDelitos.idClaseCondicionVictima);

        myCommand.Parameters.AddWithValue("@idClaseCantAutorReconocidos", myDelitos.idClaseCantAutorReconocidos);

        myCommand.Parameters.AddWithValue("@baja", myDelitos.Baja);

        myCommand.Parameters.AddWithValue("@idUsuarioAlta", myDelitos.idUsuarioAlta);

        myCommand.Parameters.AddWithValue("@FechaAlta", myDelitos.FechaAlta);

        if (string.IsNullOrEmpty(myDelitos.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myDelitos.idUsuarioUltimaModificacion);
        }
        if (myDelitos.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myDelitos.FechaUltimaModificacion);
        }
        myCommand.Parameters.AddWithValue("@idClaseDelito", myDelitos.idClaseDelito);
        myCommand.Parameters.AddWithValue("@idTipoAutor", myDelitos.idTipoAutor);
        if (string.IsNullOrEmpty(myDelitos.motivoBaja))
        {
            myCommand.Parameters.AddWithValue("@motivoBaja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@motivoBaja", myDelitos.motivoBaja);
        }
        if (myDelitos.FechaBaja == null)
        {
            myCommand.Parameters.AddWithValue("@fechaBaja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaBaja", myDelitos.FechaBaja);
        }
        DbParameter returnValue;
        returnValue = myCommand.CreateParameter();
        returnValue.Direction = ParameterDirection.ReturnValue;
        myCommand.Parameters.Add(returnValue);

        //myConnection.Open();
        myCommand.ExecuteNonQuery();
        result = Convert.ToInt32(returnValue.Value);
        //myConnection.Close();
        //    }
        //}
    } // try
    catch (Exception e)
    {
        //tr.Rollback();
        throw e;
    }

    return result;
}

public static int Save(Delitos myDelitos)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("DelitosInsertUpdateSingleItem", myConnection))
    {
        myCommand.CommandType = CommandType.StoredProcedure;
    
        if (myDelitos.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myDelitos.id);
        }
        if (string.IsNullOrEmpty(myDelitos.idCausa))
        {
            myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idCausa", myDelitos.idCausa);
        }

        myCommand.Parameters.AddWithValue("@idClaseFecha", myDelitos.idClaseFecha);

        if (myDelitos.FechaDesde == null)
        {
            myCommand.Parameters.AddWithValue("@fechaDesde", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaDesde", myDelitos.FechaDesde);
        }
        if (myDelitos.FechaHasta == null)
        {
            myCommand.Parameters.AddWithValue("@fechaHasta", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaHasta", myDelitos.FechaHasta);
        }

        myCommand.Parameters.AddWithValue("@idClaseHora", myDelitos.idClaseHora);

        if (myDelitos.HoraDesde == null)
        {
            myCommand.Parameters.AddWithValue("@horaDesde", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@horaDesde", myDelitos.HoraDesde);
        }
        if (myDelitos.HoraHasta == null)
        {
            myCommand.Parameters.AddWithValue("@horaHasta", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@horaHasta", myDelitos.HoraHasta);
        }

        myCommand.Parameters.AddWithValue("@idClaseMomentoDelDia", myDelitos.idClaseMomentoDelDia);


        myCommand.Parameters.AddWithValue("@idPartido", myDelitos.idPartido);


        myCommand.Parameters.AddWithValue("@idLocalidad", myDelitos.idLocalidad);


        myCommand.Parameters.AddWithValue("@idCalle", myDelitos.idCalle);

        if (string.IsNullOrEmpty(myDelitos.idOtraCalle))
        {
            myCommand.Parameters.AddWithValue("@idOtraCalle", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idOtraCalle", myDelitos.idOtraCalle);
        }

        myCommand.Parameters.AddWithValue("@idEntreCalle1", myDelitos.idEntreCalle1);

        if (string.IsNullOrEmpty(myDelitos.idOtraEntreCalle))
        {
            myCommand.Parameters.AddWithValue("@idOtraEntreCalle", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idOtraEntreCalle", myDelitos.idOtraEntreCalle);
        }

        myCommand.Parameters.AddWithValue("@idEntreCalle2", myDelitos.idEntreCalle2);

        if (string.IsNullOrEmpty(myDelitos.idOtraEntreCalle2))
        {
            myCommand.Parameters.AddWithValue("@idOtraEntreCalle2", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idOtraEntreCalle2", myDelitos.idOtraEntreCalle2);
        }
        if (string.IsNullOrEmpty(myDelitos.NroH))
        {
            myCommand.Parameters.AddWithValue("@nroH", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@nroH", myDelitos.NroH);
        }
        if (string.IsNullOrEmpty(myDelitos.PisoH))
        {
            myCommand.Parameters.AddWithValue("@pisoH", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@pisoH", myDelitos.PisoH);
        }
        if (string.IsNullOrEmpty(myDelitos.DeptoH))
        {
            myCommand.Parameters.AddWithValue("@deptoH", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@deptoH", myDelitos.DeptoH);
        }
        if (string.IsNullOrEmpty(myDelitos.ParajeBarrioH))
        {
            myCommand.Parameters.AddWithValue("@parajeBarrioH", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@parajeBarrioH", myDelitos.ParajeBarrioH);
        }

        myCommand.Parameters.AddWithValue("@idComisariaH", myDelitos.idComisariaH);


        myCommand.Parameters.AddWithValue("@idClaseLugar", myDelitos.idClaseLugar);


        myCommand.Parameters.AddWithValue("@idClaseRubro", myDelitos.idClaseRubro);


        myCommand.Parameters.AddWithValue("@idClaseModoArriboHuida", myDelitos.idClaseModoArriboHuida);


        myCommand.Parameters.AddWithValue("@idClaseModusOperandis", myDelitos.idClaseModusOperandis);

        if (string.IsNullOrEmpty(myDelitos.NomRefLugarRubro))
        {
            myCommand.Parameters.AddWithValue("@NomRefLugarRubro", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@NomRefLugarRubro", myDelitos.NomRefLugarRubro);
        }
        if (string.IsNullOrEmpty(myDelitos.ExprUtilizadaComienzoDelHecho))
        {
            myCommand.Parameters.AddWithValue("@exprUtilizadaComienzoDelHecho", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@exprUtilizadaComienzoDelHecho", myDelitos.ExprUtilizadaComienzoDelHecho);
        }
        if (string.IsNullOrEmpty(myDelitos.ExprReiteradaDuranteHecho))
        {
            myCommand.Parameters.AddWithValue("@exprReiteradaDuranteHecho", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@exprReiteradaDuranteHecho", myDelitos.ExprReiteradaDuranteHecho);
        }
        if (string.IsNullOrEmpty(myDelitos.IngresaronPor))
        {
            myCommand.Parameters.AddWithValue("@ingresaronPor", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@ingresaronPor", myDelitos.IngresaronPor);
        }



        myCommand.Parameters.AddWithValue("@victimasEnElLugar", myDelitos.VictimasEnElLugar);

        myCommand.Parameters.AddWithValue("@usoDeArmas", myDelitos.UsoDeArmas);

        myCommand.Parameters.AddWithValue("@idClaseArma", myDelitos.idClaseArma);

        myCommand.Parameters.AddWithValue("@idClaseSubtipoArma", myDelitos.idClaseSubtipoArma);

        myCommand.Parameters.AddWithValue("@huboAgresionFisicaAVictima", myDelitos.HuboAgresionFisicaAVictima);

        myCommand.Parameters.AddWithValue("@idClaseAgresion", myDelitos.idClaseAgresion);

        myCommand.Parameters.AddWithValue("@idClaseZonaCuerpoLesionada", myDelitos.idClaseZonaCuerpoLesionada);

        myCommand.Parameters.AddWithValue("@victimaTrasladadaAOtroLugar", myDelitos.VictimaTrasladadaAOtroLugar);

        myCommand.Parameters.AddWithValue("@idPartidoL", myDelitos.idPartidoL);

        myCommand.Parameters.AddWithValue("@idLocalidadL", myDelitos.idLocalidadL);

        myCommand.Parameters.AddWithValue("@idCalleL", myDelitos.idCalleL);

        if (string.IsNullOrEmpty(myDelitos.idOtraCalleL))
        {
            myCommand.Parameters.AddWithValue("@idOtraCalleL", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idOtraCalleL", myDelitos.idOtraCalleL);
        }

        myCommand.Parameters.AddWithValue("@idEntreCalle1L", myDelitos.idEntreCalle1L);

        if (string.IsNullOrEmpty(myDelitos.OtraEntreCalle1L))
        {
            myCommand.Parameters.AddWithValue("@otraEntreCalle1L", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@otraEntreCalle1L", myDelitos.OtraEntreCalle1L);
        }
        myCommand.Parameters.AddWithValue("@idEntreCalle2L", myDelitos.idEntreCalle2L);

        if (string.IsNullOrEmpty(myDelitos.OtraEntreCalle2L))
        {
            myCommand.Parameters.AddWithValue("@otraEntreCalle2L", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@otraEntreCalle2L", myDelitos.OtraEntreCalle2L);
        }
        if (string.IsNullOrEmpty(myDelitos.ParajeBarrioL))
        {
            myCommand.Parameters.AddWithValue("@parajeBarrioL", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@parajeBarrioL", myDelitos.ParajeBarrioL);
        }
        myCommand.Parameters.AddWithValue("@idComisariaL", myDelitos.idComisariaL);

        myCommand.Parameters.AddWithValue("@idClaseCantidadAutores", myDelitos.idClaseCantidadAutores);

        myCommand.Parameters.AddWithValue("@montoTotalEstimadoBienSustraido", myDelitos.MontoTotalEstimadoBienSustraido);

        myCommand.Parameters.AddWithValue("@idVicTestRecRueda", myDelitos.idVicTestRecRueda);

        myCommand.Parameters.AddWithValue("@idClaseCondicionVictima", myDelitos.idClaseCondicionVictima);

        myCommand.Parameters.AddWithValue("@idClaseCantAutorReconocidos", myDelitos.idClaseCantAutorReconocidos);

        myCommand.Parameters.AddWithValue("@baja", myDelitos.Baja);

        myCommand.Parameters.AddWithValue("@idUsuarioAlta", myDelitos.idUsuarioAlta);

        myCommand.Parameters.AddWithValue("@FechaAlta", myDelitos.FechaAlta);

        if (string.IsNullOrEmpty(myDelitos.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myDelitos.idUsuarioUltimaModificacion);
        }
        if (myDelitos.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myDelitos.FechaUltimaModificacion);
        }
        if (string.IsNullOrEmpty(myDelitos.motivoBaja))
        {
            myCommand.Parameters.AddWithValue("@motivoBaja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@motivoBaja", myDelitos.motivoBaja);
        }
        if (myDelitos.FechaBaja == null)
        {
            myCommand.Parameters.AddWithValue("@fechaBaja", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaBaja", myDelitos.FechaBaja);
        }
        myCommand.Parameters.AddWithValue("@idClaseDelito", myDelitos.idClaseDelito);
        myCommand.Parameters.AddWithValue("@idTipoAutor", myDelitos.idTipoAutor);
        DbParameter returnValue;
        returnValue = myCommand.CreateParameter();
        returnValue.Direction = ParameterDirection.ReturnValue;
        myCommand.Parameters.Add(returnValue);

        myConnection.Open();
        myCommand.ExecuteNonQuery();
        result = Convert.ToInt32(returnValue.Value);
        myConnection.Close();
           
        }
    } 
    return result;
}


        /// <summary>
        /// Deletes a Delitos from the database.
        /// </summary>
        /// <param name="id">The id of the Delitos to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("DelitosDeleteSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@id", id);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
            return result > 0;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the Delitos class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static Delitos FillDataRecord(IDataRecord myDataRecord)
        {
            Delitos myDelitos = new Delitos();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myDelitos.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCausa")))
            {
                myDelitos.idCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("idCausa"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseFecha")))
            {
                myDelitos.idClaseFecha = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseFecha"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaDesde")))
            {
                myDelitos.FechaDesde = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaDesde"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaHasta")))
            {
                myDelitos.FechaHasta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaHasta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseHora")))
            {
                myDelitos.idClaseHora = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseHora"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HoraDesde")))
            {
                myDelitos.HoraDesde = myDataRecord.GetString(myDataRecord.GetOrdinal("HoraDesde"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HoraHasta")))
            {
                myDelitos.HoraHasta = myDataRecord.GetString(myDataRecord.GetOrdinal("HoraHasta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseMomentoDelDia")))
            {
                myDelitos.idClaseMomentoDelDia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseMomentoDelDia"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPartido")))
            {
                myDelitos.idPartido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPartido"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLocalidad")))
            {
                myDelitos.idLocalidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLocalidad"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCalle")))
            {
                myDelitos.idCalle = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idCalle"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idOtraCalle")))
            {
                myDelitos.idOtraCalle = myDataRecord.GetString(myDataRecord.GetOrdinal("idOtraCalle"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idEntreCalle1")))
            {
                myDelitos.idEntreCalle1 = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idEntreCalle1"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idOtraEntreCalle")))
            {
                myDelitos.idOtraEntreCalle = myDataRecord.GetString(myDataRecord.GetOrdinal("idOtraEntreCalle"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idEntreCalle2")))
            {
                myDelitos.idEntreCalle2 = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idEntreCalle2"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idOtraEntreCalle2")))
            {
                myDelitos.idOtraEntreCalle2 = myDataRecord.GetString(myDataRecord.GetOrdinal("idOtraEntreCalle2"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NroH")))
            {
                myDelitos.NroH = myDataRecord.GetString(myDataRecord.GetOrdinal("NroH"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PisoH")))
            {
                myDelitos.PisoH = myDataRecord.GetString(myDataRecord.GetOrdinal("PisoH"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DeptoH")))
            {
                myDelitos.DeptoH = myDataRecord.GetString(myDataRecord.GetOrdinal("DeptoH"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ParajeBarrioH")))
            {
                myDelitos.ParajeBarrioH = myDataRecord.GetString(myDataRecord.GetOrdinal("ParajeBarrioH"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idComisariaH")))
            {
                myDelitos.idComisariaH = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idComisariaH"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseLugar")))
            {
                myDelitos.idClaseLugar = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseLugar"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseRubro")))
            {
                myDelitos.idClaseRubro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseRubro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseModoArriboHuida")))
            {
                myDelitos.idClaseModoArriboHuida = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseModoArriboHuida"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseModusOperandis")))
            {
                myDelitos.idClaseModusOperandis = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseModusOperandis"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ExprUtilizadaComienzoDelHecho")))
            {
                myDelitos.ExprUtilizadaComienzoDelHecho = myDataRecord.GetString(myDataRecord.GetOrdinal("ExprUtilizadaComienzoDelHecho"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ExprReiteradaDuranteHecho")))
            {
                myDelitos.ExprReiteradaDuranteHecho = myDataRecord.GetString(myDataRecord.GetOrdinal("ExprReiteradaDuranteHecho"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IngresaronPor")))
            {
                myDelitos.IngresaronPor = myDataRecord.GetString(myDataRecord.GetOrdinal("IngresaronPor"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("VictimasEnElLugar")))
            {
                myDelitos.VictimasEnElLugar = myDataRecord.GetInt32(myDataRecord.GetOrdinal("VictimasEnElLugar"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsoDeArmas")))
            {
                myDelitos.UsoDeArmas = myDataRecord.GetInt32(myDataRecord.GetOrdinal("UsoDeArmas"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseArma")))
            {
                myDelitos.idClaseArma = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseArma"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseSubtipoArma")))
            {
                myDelitos.idClaseSubtipoArma = myDataRecord.GetInt16(myDataRecord.GetOrdinal("idClaseSubtipoArma"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HuboAgresionFisicaAVictima")))
            {
                myDelitos.HuboAgresionFisicaAVictima = myDataRecord.GetInt32(myDataRecord.GetOrdinal("HuboAgresionFisicaAVictima"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseAgresion")))
            {
                myDelitos.idClaseAgresion = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseAgresion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseZonaCuerpoLesionada")))
            {
                myDelitos.idClaseZonaCuerpoLesionada = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseZonaCuerpoLesionada"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("VictimaTrasladadaAOtroLugar")))
            {
                myDelitos.VictimaTrasladadaAOtroLugar = myDataRecord.GetInt32(myDataRecord.GetOrdinal("VictimaTrasladadaAOtroLugar"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtraClaseArma")))
            {
                myDelitos.OtraClaseArma = myDataRecord.GetString(myDataRecord.GetOrdinal("OtraClaseArma"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPartidoL")))
            {
                myDelitos.idPartidoL = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPartidoL"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLocalidadL")))
            {
                myDelitos.idLocalidadL = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLocalidadL"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCalleL")))
            {
                myDelitos.idCalleL = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idCalleL"));

            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idOtraCalleL")))
            {
                myDelitos.idOtraCalleL = myDataRecord.GetString(myDataRecord.GetOrdinal("idOtraCalleL"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idEntreCalle1L")))
            {
                myDelitos.idEntreCalle1L = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idEntreCalle1L"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtraEntreCalle1L")))
            {
                myDelitos.OtraEntreCalle1L = myDataRecord.GetString(myDataRecord.GetOrdinal("OtraEntreCalle1L"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idEntreCalle2L")))
            {
                myDelitos.idEntreCalle2L = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idEntreCalle2L"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtraEntreCalle2L")))
            {
                myDelitos.OtraEntreCalle2L = myDataRecord.GetString(myDataRecord.GetOrdinal("OtraEntreCalle2L"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ParajeBarrioL")))
            {
                myDelitos.ParajeBarrioL = myDataRecord.GetString(myDataRecord.GetOrdinal("ParajeBarrioL"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idComisariaL")))
            {
                myDelitos.idComisariaL = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idComisariaL"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseCantidadAutores")))
            {
                myDelitos.idClaseCantidadAutores = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseCantidadAutores"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MontoTotalEstimadoBienSustraido")))
            {
                myDelitos.MontoTotalEstimadoBienSustraido = myDataRecord.GetFloat(myDataRecord.GetOrdinal("MontoTotalEstimadoBienSustraido"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idVicTestRecRueda")))
            {
                myDelitos.idVicTestRecRueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idVicTestRecRueda"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseCondicionVictima")))
            {
                myDelitos.idClaseCondicionVictima = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseCondicionVictima"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseCantAutorReconocidos")))
            {
                myDelitos.idClaseCantAutorReconocidos = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseCantAutorReconocidos"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
            {
                myDelitos.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
            {
                myDelitos.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
            {
                myDelitos.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioAlta")))
            {
                myDelitos.idUsuarioAlta = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioAlta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaAlta")))
            {
                myDelitos.FechaAlta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaAlta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseDelito")))
            {
                myDelitos.idClaseDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseDelito"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoAutor")))
            {
                myDelitos.idTipoAutor = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoAutor"));
            }
          
            return myDelitos;
        }
    }

} 
