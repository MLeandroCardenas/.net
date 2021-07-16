using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilitarios;
using Logica;

namespace WebServiceAsuSalud
{
    /// <summary>
    /// Descripción breve de ServiciosAsuSalud
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiciosAsuSalud : System.Web.Services.WebService
    {
        public Logica.clSeguridad SoapHeader;

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string consultarUsuarios(int id)
        {
            
            try
            {
                if (SoapHeader == null) throw new Exception("Requiere Validacion");

                if (SoapHeader.blCredencialesValidas(SoapHeader))
                {
                    //List<UP_usuarios> dsConsultar = new List<UP_usuarios>();

                    Logica.LP_Servicios clobClientes = new Logica.LP_Servicios();
                    return clobClientes.traer_roles_nombres(id);   
                }
                return "Error no hay datos";
            }
            catch (Exception ex) { throw ex; }
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string consultarHistoriaClinica(int id)
        {
            try
            {
                List<UP_Historia_Clinica> dsConsultarHistoria = new List<UP_Historia_Clinica>();
                if (SoapHeader == null) throw new Exception("Requiere Validacion");

               if (SoapHeader.blCredencialesValidas(SoapHeader))
                //if (validacionToken(token) == "1")
                {
                    

                    Logica.LP_Servicios clobClientes = new Logica.LP_Servicios();
                    return clobClientes.traer_historia_clinica_servicio(id);

                    
                }
                return "Error no hay datos";
            }
            catch (Exception ex) { throw ex; }
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string consultaCitasPendiemtes(int id)
        {
            List<U_CitasMedicas> dsConsultarCitaPendiemte = new List<U_CitasMedicas>();
            try
            {
                if (SoapHeader == null) throw new Exception("Requiere Validacion");

                if (SoapHeader.blCredencialesValidas(SoapHeader))
                //if (validacionToken(token) == "1")
                {
                    //List<U_CitasMedicas> dsConsultarCitaPendiemte = new List<U_CitasMedicas>();

                    Logica.LP_Servicios clobClientes = new Logica.LP_Servicios();
                    return clobClientes.traer_citas_pendientes(id);

                    
                }
                return "Error no hay datos";
            }
            catch (Exception ex) { throw ex; }
        }
        /*
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public int dsConsultaCantidadCitasAtentidas(DateTime fecha)
        {
            try
            {
                if (SoapHeader == null) throw new Exception("Requiere Validacion");

                if (!SoapHeader.blCredencialesValidas(SoapHeader)) throw new Exception("Requiere Validacion");

                int dsConsultarCantidadCitas;

                Logica.Clases.clsClientes clobClientes = new Logica.Clases.clsClientes();
                dsConsultarCantidadCitas = clobClientes.dsConsultarCantidadCitas(fecha);

                return dsConsultarCantidadCitas;
            }
            catch (Exception ex) { throw ex; }
        }
        */

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string validacionUsuario()
        {
            
            try
            {
                string mensaje="";
                LP_verificacion lp = new LP_verificacion();
                if (SoapHeader == null) return "-1";
                if (SoapHeader.blCredencialesValidas(SoapHeader.stToken) == "-1")
                {
                    mensaje= "Usuario invalido";
                }
                if (SoapHeader.blCredencialesValidas(SoapHeader.stToken) == "2") 
                {
                    string token_seguridad = Guid.NewGuid().ToString();
                    LP_verificacion logica = new LP_verificacion();
                    logica.insertar_token(token_seguridad,SoapHeader.stToken);
                    
                    mensaje=token_seguridad;                   
                }            
                return mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string validacionToken()
        {
           
            try
            {
                if (SoapHeader == null) return "-1";
                if (SoapHeader.blCredencialesValidas(SoapHeader.stToken)=="-1") return "-1";
                if (SoapHeader.blCredencialesValidas(SoapHeader.stToken) == "2") return "2";
                string stToken = Guid.NewGuid().ToString();

                HttpRuntime.Cache.Add(stToken, SoapHeader.stToken, null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                    TimeSpan.FromMinutes(30), System.Web.Caching.CacheItemPriority.NotRemovable,
                    null);

                return stToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string traer_Token()
        {
           
            try
            {
                
                if (SoapHeader == null) throw new Exception("Requiere validacion");
                //if (SoapHeader.blCredencialesValidas(SoapHeader.user, SoapHeader.clave, SoapHeader.stToken) == "-1") return "-1";
                //if (SoapHeader.blCredencialesValidas(SoapHeader.user, SoapHeader.clave, SoapHeader.stToken) == "2") return "2";
                // SoapHeader.traer_token(SoapHeader.user,SoapHeader.clave);
                string stToken = SoapHeader.traer_token(SoapHeader.user, SoapHeader.clave);



                return stToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string dsConsultaCitas()
        {
            try
            {

                if (SoapHeader == null) throw new Exception("Requiere validacion");
                if (SoapHeader.blCredencialesValidas(SoapHeader))
                {
                    LP_consultas lp = new LP_consultas();
                    return lp.traer_datos_citas();
                }
                else
                {
                    throw new Exception("Requiere validcaion");
                }
                
            
                   // return "El token es invalido";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
        
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string agendar_cita(long identificacion, int id_cita)
        {
            string mensaje;
            try
            {

                if (SoapHeader == null) throw new Exception("Requiere validacion");

                if (SoapHeader.blCredencialesValidas(SoapHeader))
                {
                    LP_SolicitarCita lp = new LP_SolicitarCita();
                    //string token_autenticacion = Guid.NewGuid().ToString();
                    LP_SolicitarCita logica = new LP_SolicitarCita();
                    logica.agendar_cita(identificacion, id_cita);
                    mensaje = "Cita Agendada Exitosamente";
                    return mensaje;
                }
                return "Error en el proceso";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        
        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string RegistroPaciente(string nombres, string apellidos, long identificacion, string email, string clave, string session)
        {
          // wsAutenticacion.wsAutenticacionSoapClient obj = new wsAutenticacion.wsAutenticacionSoapClient();
           //sAutenticacion.LP_autenticacion obj2 = new wsAutenticacion.LP_autenticacion();

            try
            {

               if (SoapHeader == null) throw new Exception("Requiere validacion");
               if (SoapHeader.blCredencialesValidas(SoapHeader))
               {
                    
                    LP_Registro lp = new LP_Registro();
                    return lp.Registro_Paciente(nombres, apellidos, identificacion, email, clave, session,null,null);
                }
                return "Error en el registro";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string dsConsultaEspecialidades()
        {
            try
            {
                if (SoapHeader == null) throw new Exception("Requiere Validacion");

                if (SoapHeader.blCredencialesValidas(SoapHeader))
                {
                    Logica.LP_Servicios clobEspecialidades = new Logica.LP_Servicios();
                    return clobEspecialidades.traer_especialidades_servicio();
                }
                return "Error en la consulta";

                

               
            }
            catch (Exception ex) { throw ex; }
        }


        [WebMethod]
        [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
        public string Traer_Usuarios()
        {
            try
            {
                if (SoapHeader == null) throw new Exception("Requiere Validacion");

                if (SoapHeader.blCredencialesValidas(SoapHeader))
                {
                    Logica.LP_consultas datos = new Logica.LP_consultas();
                    return datos.traer_usuarios();
                }
                return "Error en la consulta";




            }
            catch (Exception ex) { throw ex; }
        }


    }
}
