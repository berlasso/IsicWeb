using ISIC.Entities;
using ISIC.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MPBA.DataAccess;
using ISIC.Services;
using MPBA.Jira;
using MPBA.Jira.Model;


namespace ISIC.Persistence.Context
{
    public class ContextInitializer : IDatabaseInitializer<ISICContext>
    {
        IRepository repository;
        private IJiraService jiraService;
        private IImputadoService imputadoService;
        
        
        public void InitializeDatabase(ISICContext context )
        {

            if (!context.Database.Exists())
            {
                context.Database.Create();
            }
            //jiraService = new JiraService();
            //Issue<IssueFields> issue = jiraService.CreateIssue("010200000043K");
            //Issue<IssueFields> issue = jiraService.CreateIssue("150100000015S");
            //Issue<IssueFields> issue = jiraService.GetIssue("010200000006V");
            //MPBA.Jira.Model.JiraUser usuario = new JiraUser();
            //issue.fields.assignee = new JiraUser();
            //usuario.name = "meveleens";
            //usuario.displayName = "Mariana Eveleens";
            //usuario.emailAddress = "meveleens@mpba.gov.ar";
            //usuario.active = true;
            //issue.fields.assignee = usuario;
            //Issue<IssueFields> issuemodificada = jiraService.UpdateIssue(issue);
            //CrearDatosJira(context);
#if DEBUG

            if (!context.Database.CompatibleWithModel(false))
            {
                context.Database.Delete();
                context.Database.Create();
            }

            //CrearDatosDePrueba(context);


            

#endif

        }

        public void CrearDatosJira(ISICContext context)
        {

            jiraService = new JiraService();
            //var imputados = imputadoService.GetAll();
            var imputados = context.Set<Imputado>().ToList();

            foreach (Imputado impu in imputados) 
            {
                if (impu.CodigoDeBarras != "010200000006V" || impu.CodigoDeBarras != "010200000008M" || impu.CodigoDeBarras != "010200000009W" || impu.CodigoDeBarras != "010200000012P" || impu.CodigoDeBarras != "010200000019A")
                {

                    Issue<IssueFields> issue = jiraService.CreateIssue(impu.CodigoDeBarras);
                    if (impu.CodigoDeBarras.Substring(0, 4) == "0117")
                    {
                        Transition transition = jiraService.GetTransitions(issue).First();
                        jiraService.TransitionIssue(issue, transition);
                    }
                }
                else
                {
                    Issue<IssueFields> issue = jiraService.GetIssue("010200000006V");
                    MPBA.Jira.Model.JiraUser usuario = new JiraUser();
                    usuario.name = "ftapo";
                    issue.fields.assignee = usuario;
                    jiraService.UpdateIssue(issue);
                }
            }
            
            
       

        }
        
        public void CrearDatosDePrueba(ISICContext context)
        {
            ClaseSexo m = new ClaseSexo {Id = 0, descripcion = "Indeterminado"};
            ClaseSexo f = new ClaseSexo {Id = 2, descripcion = "Femenino"};
            if (!context.ClaseNombre.Any())
            {
                new List<ClaseNombre>
                {
                    new ClaseNombre()
                    {
                        Id = 1,
                        descripcion = "German",
                        sexo = m
                    },
                    new ClaseNombre()
                    {
                        Id = 2,
                        descripcion = "Carolina",
                        sexo = f
                    },
                    new ClaseNombre()
                    {
                        Id = 3,
                        descripcion = "Gloria",
                        sexo = f
                    }
                }.ForEach(i => context.ClaseNombre.Add(i));
            }
            if (!context.ClaseUbicacionSeniaPart.Any())
            {
                new List<ClaseUbicacionSeniaPart>
                {
                    new ClaseUbicacionSeniaPart()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new ClaseUbicacionSeniaPart()
                    {
                        Id = 1,
                        Descripcion = "Cabeza"
                    },
                    new ClaseUbicacionSeniaPart()
                    {
                        Id = 2,
                        Descripcion = "Mano Derecha"
                    },
                    new ClaseUbicacionSeniaPart()
                    {
                        Id = 3,
                        Descripcion = "Pierna Izquierda"
                    }
                }.ForEach(i => context.ClaseUbicacionSeniaPart.Add(i));
            }
            if (!context.ClaseTipoArchivo.Any())
            {
                new List<ClaseTipoArchivo>
                {
                    new ClaseTipoArchivo()
                    {
                        Id = 1,
                        Descripcion = "Rostro"
                    },
                    new ClaseTipoArchivo()
                    {
                        Id = 2,
                        Descripcion = "Senas Particulares"
                    },
                    new ClaseTipoArchivo()
                    {
                        Id = 3,
                        Descripcion = "Huellas"
                    }
                }.ForEach(i => context.ClaseTipoArchivo.Add(i));
            }

            if (!context.Pais.Any())
            {
                new List<Pais>
                {
                    new Pais()
                    {
                        Id = 0,
                        //Descripcion = "Indeterminado",
                        Nacionalidad = "Indeterminado"
                    },
                    new Pais()
                    {
                        Id = 1,
                        //Descripcion = "Argentina",
                        Nacionalidad = "Argentina"
                    },
                    new Pais()
                    {
                        Id = 2,
                        //Descripcion = "Paraguay",
                        Nacionalidad = "Paraguay"
                    }
                }.ForEach(i => context.Pais.Add(i));
            }


            List<Provincia> provincias = null;
            if (!context.Provincia.Any())
            {
                provincias = new List<Provincia>
                {
                    new Provincia()
                    {
                        Id = 0,
                        ProvinciaNombre = "Indeterminada"
                    },
                    new Provincia()
                    {
                        Id = 1,
                        ProvinciaNombre = "Buenos Aires"
                    },
                    new Provincia()
                    {
                        Id = 2,
                        ProvinciaNombre = "Entre Rios"
                    }
                };
            }
            else
            {

                provincias = context.Provincia.ToList();
            }
        

        

            if (!context.Localidad.Any())
            {
                new List<Localidad>
                {
                     new Localidad()
                    {
                        Id = 0,
                        LocalidadNombre = "Indeterminada",
                        Provincia = provincias.Find(x=>x.Id==0),
                        Partido =
                            new Partido
                            {
                                Id = 0,
                                Provincia = provincias.Find(x=>x.Id==0),
                                PartidoNombre = "Indeterminado",
                                Departamento = new Departamento {Id = 0, DepartamentoNombre = "Indeterminado"}
                            },
                        CodigoPostal = "0000"

                    },
                    new Localidad()
                    {
                        Id = 1,
                        LocalidadNombre = "La Plata",
                        Provincia = provincias.Find(x=>x.Id==1),
                        Partido =
                            new Partido
                            {
                                Id = 1,
                                Provincia = provincias.Find(x=>x.Id==1),
                                PartidoNombre = "La Plata",
                                Departamento = new Departamento {Id = 1, DepartamentoNombre = "La Plata"}
                            },
                        CodigoPostal = "1900"

                    },
                    new Localidad()
                    {
                        Id = 2,
                        LocalidadNombre = "Villa Elisa",
                        Provincia = provincias.Find(x=>x.Id==2),
                        Partido =
                            new Partido
                            {
                                Id = 2,
                                Provincia = provincias.Find(x=>x.Id==2),
                                PartidoNombre = "Ensenada",
                                Departamento = new Departamento {Id = 2, DepartamentoNombre = "Gonnet"}
                            },
                        CodigoPostal = "5000"

                    },
                    new Localidad()
                    {
                        Id = 3,
                        LocalidadNombre = "Quilmes",
                        Provincia = provincias.Find(x=>x.Id==2),
                        Partido =
                            new Partido
                            {
                                Id = 3,
                                Provincia = provincias.Find(x=>x.Id==2),
                                PartidoNombre = "Quilmes",
                                Departamento = new Departamento {Id = 3, DepartamentoNombre = "Quilmes"}
                            },
                        CodigoPostal = "6000"

                    }
                }.ForEach(i => context.Localidad.Add(i));
            }

          

           
          

            if (!context.SICClaseCejasDimension.Any())
            {
                new List<SICClaseCejasDimension>
                {
                    new SICClaseCejasDimension()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseCejasDimension()
                    {
                        Id = 1,
                        Descripcion = "Grandes"
                    }
                }.ForEach(i => context.SICClaseCejasDimension.Add(i));
            }
            if (!context.SICClaseCejasTipo.Any())
            {
                new List<SICClaseCejasTipo>
                {
                    new SICClaseCejasTipo()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseCejasTipo()
                    {
                        Id = 1,
                        Descripcion = "Chatas"
                    }
                }.ForEach(i => context.SICClaseCejasTipo.Add(i));
            }
            if (!context.SICClaseColorCabello.Any())
            {
                new List<SICClaseColorCabello>
                {
                    new SICClaseColorCabello()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseColorCabello()
                    {
                        Id = 1,
                        Descripcion = "Marron"
                    }
                }.ForEach(i => context.SICClaseColorCabello.Add(i));
            }
            if (!context.SICClaseColorOjos.Any())
            {
                new List<SICClaseColorOjos>
                {
                     new SICClaseColorOjos()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseColorOjos()
                    {
                        Id = 1,
                        Descripcion = "Verdes"
                    }
                }.ForEach(i => context.SICClaseColorOjos.Add(i));
            }
            if (!context.SICClaseColorPiel.Any())
            {
                new List<SICClaseColorPiel>
                {
                    new SICClaseColorPiel()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseColorPiel()
                    {
                        Id = 1,
                        Descripcion = "Amarilla"
                    }
                }.ForEach(i => context.SICClaseColorPiel.Add(i));
            }
            if (!context.SICClaseFormaBoca.Any())
            {
                new List<SICClaseFormaBoca>
                {
                    new SICClaseFormaBoca()
                    {
                        Id = 0,
                        Descripcion = "Indeterminada"
                    },
                    new SICClaseFormaBoca()
                    {
                        Id = 1,
                        Descripcion = "Grande"
                    }
                }.ForEach(i => context.SICClaseFormaBoca.Add(i));
            }
            if (!context.SICClaseFormaCara.Any())
            {
                new List<SICClaseFormaCara>
                {
                    new SICClaseFormaCara()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseFormaCara()
                    {
                        Id = 1,
                        Descripcion = "Alargada"
                    }
                }.ForEach(i => context.SICClaseFormaCara.Add(i));
            }
            if (!context.SICClaseFormaLabioInferior.Any())
            {
                new List<SICClaseFormaLabioInferior>
                {
                     new SICClaseFormaLabioInferior()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseFormaLabioInferior()
                    {
                        Id = 1,
                        Descripcion = "Amplio"
                    }
                }.ForEach(i => context.SICClaseFormaLabioInferior.Add(i));
            }
            if (!context.SICClaseFormaLabioSuperior.Any())
            {
                new List<SICClaseFormaLabioSuperior>
                {
                     new SICClaseFormaLabioSuperior()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseFormaLabioSuperior()
                    {
                        Id = 1,
                        Descripcion = "Amplio"
                    }
                }.ForEach(i => context.SICClaseFormaLabioSuperior.Add(i));
            }
            if (!context.SICClaseFormaMenton.Any())
            {
                new List<SICClaseFormaMenton>
                {
                    new SICClaseFormaMenton()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseFormaMenton()
                    {
                        Id = 1,
                        Descripcion = "Raro"
                    }
                }.ForEach(i => context.SICClaseFormaMenton.Add(i));
            }
            if (!context.SICClaseFormaNariz.Any())
            {
                new List<SICClaseFormaNariz>
                {
                     new SICClaseFormaNariz()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseFormaNariz()
                    {
                        Id = 1,
                        Descripcion = "En Punta"
                    }
                }.ForEach(i => context.SICClaseFormaNariz.Add(i));
            }
            if (!context.SICClaseFormaOreja.Any())
            {
                new List<SICClaseFormaOreja>
                {
                    new SICClaseFormaOreja()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseFormaOreja()
                    {
                        Id = 1,
                        Descripcion = "Redonda"
                    }
                }.ForEach(i => context.SICClaseFormaOreja.Add(i));
            }
            if (!context.SICClaseRobustez.Any())
            {
                new List<SICClaseRobustez>
                {
                    new SICClaseRobustez()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseRobustez()
                    {
                        Id = 1,
                        Descripcion = "Robusto"
                    }
                }.ForEach(i => context.SICClaseRobustez.Add(i));
            }
            if (!context.SICClaseTipoCabello.Any())
            {
                new List<SICClaseTipoCabello>
                {
                    new SICClaseTipoCabello()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseTipoCabello()
                    {
                        Id = 1,
                        Descripcion = "Enrulado"
                    }
                }.ForEach(i => context.SICClaseTipoCabello.Add(i));
            }
            if (!context.SICClaseTipoCalvicie.Any())
            {
                new List<SICClaseTipoCalvicie>
                {
                    new SICClaseTipoCalvicie()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new SICClaseTipoCalvicie()
                    {
                        Id = 1,
                        Descripcion = "Avanzada"
                    }
                }.ForEach(i => context.SICClaseTipoCalvicie.Add(i));
            }
            if (!context.ClaseSexo.Any())
            {
                new List<ClaseSexo>
                {
                    //new ClaseSexo()
                    //{
                    //    Id = 0,
                    //    descripcion = "Indeterminado"
                    //}
                    new ClaseSexo()
                    {
                        Id = 1,
                        descripcion = "Masculino"
                    }
                }.ForEach(i => context.ClaseSexo.Add(i));
            }
            if (!context.ClaseEstadoCivil.Any())
            {
                new List<ClaseEstadoCivil>
                {
                     new ClaseEstadoCivil()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new ClaseEstadoCivil()
                    {
                        Id = 1,
                        Descripcion = "Soltero"
                    }
                }.ForEach(i => context.ClaseEstadoCivil.Add(i));
            }
            if (!context.ClaseEstudiosCursados.Any())
            {
                new List<ClaseEstudiosCursados>
                {
                    new ClaseEstudiosCursados()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new ClaseEstudiosCursados()
                    {
                        Id = 1,
                        Descripcion = "Primarios"
                    }
                }.ForEach(i => context.ClaseEstudiosCursados.Add(i));
            }
            if (!context.ClaseTipoDNI.Any())
            {
                new List<ClaseTipoDNI>
                {
                     new ClaseTipoDNI()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new ClaseTipoDNI()
                    {
                        Id = 1,
                        Descripcion = "DNI"
                    }
                }.ForEach(i => context.ClaseTipoDNI.Add(i));
            }

            if (!context.NNClaseModusOperandi.Any())
            {
                new List<NNClaseModusOperandi>
                {
                     new NNClaseModusOperandi()
                    {
                        Id = 0,
                        Descripcion = "Indeterminado"
                    },
                    new NNClaseModusOperandi()
                    {
                        Id = 1,
                        Descripcion = "Hurto simple"
                    }
                }.ForEach(i => context.NNClaseModusOperandi.Add(i));
            }
            context.SaveChanges();
            if (!context.Imputado.Any())
            {
             
                IPP ipp = new IPP
                {

                    FechaCreacion = DateTime.Now,
                    FechaUltimaModificacion = DateTime.Now,
                    UFI = "UFI 1",
                    caratula = "Robo a mano armada",
                    numero = "5544",
                };
                Delito delito = new Delito
                {
                    Ipp = ipp,
                    FechaAlta = DateTime.Now,
                    FechaUltimaModificacion = DateTime.Now,
                   ModusOperandi = context.NNClaseModusOperandi.Find(0),
                    DescripcionTemporal = new DescripcionTemporal
                    {
                        FechaDesde = DateTime.ParseExact("18/02/2015","dd/MM/yyyy",CultureInfo.InvariantCulture),
                        FechaHasta = DateTime.ParseExact("18/02/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        HoraDesde = DateTime.Now.ToString("HH:mm:ss tt"),
                        HoraHasta = DateTime.Now.ToString("HH:mm:ss tt"),
                        
                    },
                    //Comisaria = new Comisaria
                    //{
                    //    ComisariaNombre = "Seccional Primera",
                    //    Localidad = context.Localidades.Find(0)
                    //},

                    Domicilio = new Domicilio
                    {
                      
                            Calle = "63",
                            EntreCalle = "22",
                            EntreCalle2 = "23",
                            NroH = "1378",
                            
                        
                    }
                    
                };
             
                new List<Imputado>
                {
                    new Imputado()
                    {
                        Prontuario = new Prontuario{ProntuarioNro = "010200012345W"}, 
                        CodigoDeBarras = "010200012345W", 
                        FechaCreacionI = DateTime.Now,
                        CodigoDeBarrasOriginal = "010200012345W",
                        Robustez = context.SICClaseRobustez.Find(0),
                        FormaBoca = context.SICClaseFormaBoca.Find(0),
                        FormaCara = context.SICClaseFormaCara.Find(0),
                        FormaLabioInferior = context.SICClaseFormaLabioInferior.Find(0),
                        FormaLabioSuperior = context.SICClaseFormaLabioSuperior.Find(0),
                        FormaMenton = context.SICClaseFormaMenton.Find(0),  
                        FormaNariz = context.SICClaseFormaNariz.Find(0),
                        FormaOreja = context.SICClaseFormaOreja.Find(0),
                        CejasDimension = context.SICClaseCejasDimension.Find(0),
                        CejasTipo = context.SICClaseCejasTipo.Find(0),
                        TipoCabello = context.SICClaseTipoCabello.Find(0),
                        ColorCabello = context.SICClaseColorCabello.Find(0),
                        TipoCalvicie = context.SICClaseTipoCalvicie.Find(0),
                        ColorOjos = context.SICClaseColorOjos.Find(0),
                        ColorPiel = context.SICClaseColorPiel.Find(0),
                        Estado = context.SICEstadosTramite.Find(2),
                        UsuarioCreacionI ="prueba@mpba.gov.ar",
                        Delito = delito,
                        
                        Persona = new Persona()
                        {
                            FechaNacimiento = DateTime.ParseExact("18/01/2015","dd/MM/yyyy",CultureInfo.InvariantCulture),
                            Nombre = "Juan",
                            Apellido = "Perez",
                            ProvinciaNacimiento = context.Provincia.Find(1),
                            LocalidadNacimiento = context.Localidad.Find(0),
                            EstudiosCursados = context.ClaseEstudiosCursados.Find(0),
                            Nacionalidad = context.Pais.Find(0),
                            TipoDNI = context.ClaseTipoDNI.Find(0),
                            EstadoCivil = context.ClaseEstadoCivil.Find(0),
                            Sexo = context.ClaseSexo.Find(1),
                            DocumentoNumero = "52478924",
                            Domicilio = new Domicilio
                            {
                              Calle  = "44",
                              EntreCalle = "11",
                              EntreCalle2 = "12",
                              NroH = "1532"
                            }
                            
                        },
                        Alias = new AutoresAlias
                        {
                            Alias = "Rata"
                        }
                    }
                }.ForEach(i => context.Imputado.Add(i));

                //Issue<IssueFields> issue = jiraService.CreateIssue("010200012345W");
                //Transition transition = jiraService.GetTransitions(issue).First();
                //jiraService.TransitionIssue(issue, transition);



            }
            
            
           
            //var stream = Assembly.GetAssembly(context.GetType()).
            //GetManifestResourceStream("ISIC.Persistence.Context.huella.png");
            //byte[] imageAsBytes = ReadFully(stream);

            if (context.VucClasificacion.Count() == 0)
            {
                VucClasificacion Sin_Clasificar = new VucClasificacion() { Descripcion = GlobalStrings.Sin_Clasificar, Sigla_Pulgar = " ", Sigla_Dactilar = " " };
                VucClasificacion Arco = new VucClasificacion() { Descripcion = GlobalStrings.Arco, Sigla_Pulgar = "A", Sigla_Dactilar = "1" };
                VucClasificacion Presilla_Interna = new VucClasificacion() { Descripcion = GlobalStrings.Presilla_Interna, Sigla_Pulgar = "I", Sigla_Dactilar = "2" };
                VucClasificacion Presilla_Externa = new VucClasificacion() { Descripcion = GlobalStrings.Presilla_Externa, Sigla_Pulgar = "E", Sigla_Dactilar = "3" };
                VucClasificacion Verticilo = new VucClasificacion() { Descripcion = GlobalStrings.Verticilo, Sigla_Pulgar = "V", Sigla_Dactilar = "4" };
                VucClasificacion Lastimado = new VucClasificacion() { Descripcion = GlobalStrings.Lastimado, Sigla_Pulgar = "X", Sigla_Dactilar = "X" };
                VucClasificacion Amputado = new VucClasificacion() { Descripcion = GlobalStrings.Amputado, Sigla_Pulgar = "0", Sigla_Dactilar = "0" };

                new List<VucClasificacion> {
                    Arco, Presilla_Interna, Presilla_Externa, Verticilo, Lastimado, Amputado
                }.ForEach(i => context.VucClasificacion.Add(i));


                //Subclasificaciones
                new List<VucSubClasificacion>
                {
                new VucSubClasificacion() { Descripcion = GlobalStrings.Sin_Subclasificacion, Sigla = "0", Clasificacion = Sin_Clasificar },
                new VucSubClasificacion() { Descripcion = GlobalStrings.Llano_o_Puro, Sigla = "6", Clasificacion = Arco },
                new VucSubClasificacion() { Descripcion = GlobalStrings.Inclinacion_Izquierda, Sigla = "7", Clasificacion = Arco },
                new VucSubClasificacion() { Descripcion = GlobalStrings.Inclinacion_Derecha, Sigla = "8", Clasificacion = Arco },
                new VucSubClasificacion() { Descripcion = GlobalStrings.Piramidal, Sigla = "9", Clasificacion = Arco },

                new VucSubClasificacion() { Descripcion = GlobalStrings.p1_5, Sigla = "A", Clasificacion = Presilla_Interna },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p6_9, Sigla = "B", Clasificacion = Presilla_Interna },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p10_13, Sigla = "C", Clasificacion = Presilla_Interna },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p14_16, Sigla = "D", Clasificacion = Presilla_Interna },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p17_19, Sigla = "E", Clasificacion = Presilla_Interna },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p20_22, Sigla = "F", Clasificacion = Presilla_Interna },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p23_25, Sigla = "G", Clasificacion = Presilla_Interna },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p26_28, Sigla = "H", Clasificacion = Presilla_Interna },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p29_en_adelante, Sigla = "I", Clasificacion = Presilla_Interna },

                new VucSubClasificacion() { Descripcion = GlobalStrings.p1_5, Sigla = "A", Clasificacion = Presilla_Externa },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p6_9, Sigla = "B", Clasificacion = Presilla_Externa },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p10_13, Sigla = "C", Clasificacion = Presilla_Externa },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p14_16, Sigla = "D", Clasificacion = Presilla_Externa },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p17_19, Sigla = "E", Clasificacion = Presilla_Externa },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p20_22, Sigla = "F", Clasificacion = Presilla_Externa },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p23_25, Sigla = "G", Clasificacion = Presilla_Externa },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p26_28, Sigla = "H", Clasificacion = Presilla_Externa },
                new VucSubClasificacion() { Descripcion = GlobalStrings.p29_en_adelante, Sigla = "I", Clasificacion = Presilla_Externa },

                new VucSubClasificacion() { Descripcion = GlobalStrings.Cerrados, Sigla = "C", Clasificacion = Verticilo },
                new VucSubClasificacion() { Descripcion = GlobalStrings.Internos, Sigla = "I", Clasificacion = Verticilo },
                new VucSubClasificacion() { Descripcion = GlobalStrings.Externos, Sigla = "E", Clasificacion = Verticilo },

                new VucSubClasificacion() { Descripcion = GlobalStrings.Sin_Subclasificacion, Sigla = "0", Clasificacion = Lastimado },
                new VucSubClasificacion() { Descripcion = GlobalStrings.Sin_Subclasificacion, Sigla = "0", Clasificacion = Amputado }
            }.ForEach(i => context.VucSubClasificacion.Add(i));


                new List<Imputado>
                {
                    new Imputado() { 
                        //Id = 1,
                        Prontuario = new Prontuario{ProntuarioNro = "010600012457R"}, 
                        CodigoDeBarras = "010600012457R", 
                        FechaCreacionI = DateTime.Now,
                        CodigoDeBarrasOriginal= "010600012457R", 
                        Persona= new Persona()
                        {
                            FechaNacimiento = DateTime.ParseExact("01/01/1966","dd/MM/yyyy",CultureInfo.InvariantCulture),
                            Nombre = "Enrique",
                            Apellido = "Gamarra",
                            ProvinciaNacimiento = context.Provincia.Find(1),
                            LocalidadNacimiento = context.Localidad.Find(0),
                            EstudiosCursados = context.ClaseEstudiosCursados.Find(0),
                            Nacionalidad = context.Pais.Find(0),
                            TipoDNI = context.ClaseTipoDNI.Find(0),
                            EstadoCivil = context.ClaseEstadoCivil.Find(0),
                            Sexo = context.ClaseSexo.Find(1),
                            DocumentoNumero = "15965452",
                            Domicilio = new Domicilio
                            {
                              Calle  = "11",
                              EntreCalle = "56",
                              EntreCalle2 = "57",
                              NroH = "122"
                            }
                            
                        },
                        BioManoDerecha= new List<BioDactilar> {
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                FechaClasificacion = DateTime.Now,
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Derecha,
                                Dedo= ISIC.Enums.ClaseDedo.Pulgar,
                                DactilarVuc = new VucClasificaPulgar { Clasificacion = Arco}
                            },
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Derecha,
                                Dedo= ISIC.Enums.ClaseDedo.Indice,
                                DactilarVuc = new VucClasificaDactilar {Clasificacion = Presilla_Interna}
                            },
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Derecha,
                                Dedo= ISIC.Enums.ClaseDedo.Medio,
                                DactilarVuc = new VucClasificaDactilar {Clasificacion = Presilla_Externa}
                            },
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Derecha,
                                Dedo= ISIC.Enums.ClaseDedo.Anular,
                                EstadoDedo = ISIC.Enums.ClaseEstadoDedo.Lastimado,
                                DactilarVuc = new VucClasificaDactilar {Clasificacion = Lastimado}
                            },
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Derecha,
                                Dedo= ISIC.Enums.ClaseDedo.Meñique,
                                EstadoDedo =  ISIC.Enums.ClaseEstadoDedo.Faltante,
                                DactilarVuc = new VucClasificaDactilar {Clasificacion = Amputado}
                            }
                        },
                        BioManoIzquierda= new List<BioDactilar> {
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Izquierda,
                                Dedo= ISIC.Enums.ClaseDedo.Pulgar
                            },
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Izquierda,
                                Dedo= ISIC.Enums.ClaseDedo.Indice
                            },
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Izquierda,
                                Dedo= ISIC.Enums.ClaseDedo.Medio
                            },
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Izquierda,
                                Dedo= ISIC.Enums.ClaseDedo.Anular
                            },
                            new BioDactilar() { 
                                CodigoDeBarra = "010600012457R", 
                                //imagen = imageAsBytes,
                                Mano= ISIC.Enums.ClaseMano.Izquierda,
                                Dedo= ISIC.Enums.ClaseDedo.Meñique
                            }
                        }
                    },
                    new Imputado() { Prontuario = new Prontuario{ProntuarioNro = "Imputado2"}, FechaCreacionI = DateTime.Now, CodigoDeBarras = "010200000004E", CodigoDeBarrasOriginal= "010200000004E",
                        Persona=  new Persona()
                        {
                            FechaNacimiento = DateTime.ParseExact("01/01/1966","dd/MM/yyyy",CultureInfo.InvariantCulture),
                            Nombre = "Marcela",
                            Apellido = "Fernandez",
                            ProvinciaNacimiento = context.Provincia.Find(1),
                            LocalidadNacimiento = context.Localidad.Find(0),
                            EstudiosCursados = context.ClaseEstudiosCursados.Find(0),
                            Nacionalidad = context.Pais.Find(0),
                            TipoDNI = context.ClaseTipoDNI.Find(0),
                            EstadoCivil = context.ClaseEstadoCivil.Find(0),
                            Sexo = context.ClaseSexo.Find(2),
                            DocumentoNumero = "15965452",
                            Domicilio = new Domicilio
                            {
                              Calle  = "1",
                              EntreCalle = "67",
                              EntreCalle2 = "68",
                              NroH = "1552"
                            }
                            
                        } }
                }.ForEach(i => context.Imputado.Add(i));
                //jiraService.CreateIssue("IG", "Task", "new IssueFields { summary = 010600012457R, status = En Otip }");
                //jiraService.CreateIssue("IG", "Task", "new IssueFields { summary = 010200000004E, status = En Otip }");


            }
            if (!context.ClaseDepartamentoJudicial.Any())
            {
                new List<ClaseDepartamentoJudicial>
                {
                    new ClaseDepartamentoJudicial
                    {
                        Id = 0,
                        sigDto = "ND",
                        idSIMP = 0,
                        descripcion = "Indeterminado"
                    },
                    new ClaseDepartamentoJudicial
                    {
                        Id = 2,
                        sigDto = "LP",
                        idSIMP = 6,
                        descripcion = "La Plata"
                    },
                    new ClaseDepartamentoJudicial
                    {
                        Id = 3,
                        sigDto = "MER",
                        idSIMP = 9,
                        descripcion = "Mercedes"
                    }
                }.ForEach(d => context.ClaseDepartamentoJudicial.Add(d));
            }

            
            context.SaveChanges();

       
        }
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
           
       
    }
}
