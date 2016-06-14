// ===================================================
// Desarrollado Por		    : DIEGO ANDRÉS ANGARITA
// Fecha de Creación		: 21/08/2014
// Lenguaje Programación	: [C#]
// Producto o sistema	    : Smart Parking
// Empresa			        : e Global Tecnology
// Cliente			        : e Global Tecnology
// ===================================================
// Versión	Descripción
// [1.0.0.0]
// Clase encargada de convertir los recursos multilenguaje de la aplciacion por el idioma de la maquina
// ===================================================
// MODIFICACIONES:
// ===================================================
// Ver.	 Fecha		Autor – Empresa 	Descripción
// ---	 -------------	----------------------	----------------------------------------
// XX	dd/mm/aaaa	[Nombre Completo]	 [Razón del cambio realizado] 
// ===================================================
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

namespace IDGI.CultureResource
{
    [Serializable]
    public class Multilanguage
    {
        public static string sRutaLog
        {
            get { return ConfigurationManager.AppSettings["LogFilePath"]; }

        }
        private static object syncLock = new object();
        public static bool bEnabledTracking
        {
            get
            {
                string sEnabledTracking = ConfigurationManager.AppSettings["EnabledTracking"];
                if (!string.IsNullOrEmpty(sEnabledTracking))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private static CultureInfo _CultureInfoBase;

        public static CultureInfo CultureInfoBase
        {
            get { return _CultureInfoBase; }
            set { _CultureInfoBase = value; }
        }

        /// <summary>
        /// Obtiene el valor de la cadena del recurso seleccionado
        /// </summary>
        /// <param name="sResource">Nombre del archivo de recurso</param>
        /// <param name="sResourceName">Nombre del recurso que obtiene el valor</param>
        /// <returns></returns>
        public static string GetResourceManagerMultilingual(string sResource, string sResourceName)
        {
            string sValorRecurso = string.Empty;
            try
            {
                string sCulture = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                if (sCulture.Trim().ToUpper() != "ES" && sCulture.Trim().ToUpper() != "EN")
                {
                    sCulture = "en";
                }
                CultureInfo _CultureInfo = new CultureInfo(sCulture);
                _CultureInfoBase = _CultureInfo;
                ResourceManager resources =
                    new ResourceManager("IDGI.CultureResource." + sResource, Assembly.GetExecutingAssembly());
                sValorRecurso = resources.GetString(sResourceName, _CultureInfo);
            }
            catch (Exception ex)
            {
                WriteLogFile(ex.Message, TipoLog.ERROR, sResource + "," + sResourceName);
                throw;
            }
           

            return sValorRecurso;
        }

        public static string GetResourceManagerMultilingual(string sCultureInfo, string sResource, string sResourceName)
        {
            string sValorRecurso = string.Empty;
            try
            {
                CultureInfo _CultureInfo = new CultureInfo(sCultureInfo);
                ResourceManager resources =
                    new ResourceManager("IDGI.CultureResource." + sResource, Assembly.GetExecutingAssembly());
                sValorRecurso = resources.GetString(sResourceName, _CultureInfo);
            }
            catch (Exception ex)
            {
                WriteLogFile(ex.Message, TipoLog.ERROR, sResource + "," + sResourceName);
                throw;
            }
            

            return sValorRecurso;
        }

        private static void WriteLogFile(string message, TipoLog oTipoLog, string sCadenaResource)
        {
            string sFileName = sRutaLog + "App_";
            if (oTipoLog == TipoLog.ERROR)
            {
                message = "****** ERROR ******" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss").ToString() + " **********" + "\r\n"
                          + message + "\r\n"
                          + "Resource : " + sCadenaResource + "\r\n"
                          + "*************************************************";
            }
            else if (oTipoLog != TipoLog.PLANO)
            {
                message = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss").ToString() + " - " + message;
            }

            string directoryFullPath = Path.GetDirectoryName(sFileName);

            if (!Directory.Exists(directoryFullPath))
            {
                Directory.CreateDirectory(directoryFullPath);
            }
            if (oTipoLog == TipoLog.PLANO)
            {
                if (File.Exists(sFileName) == true)
                {
                    if (VerificaArchivoEnUso(directoryFullPath, Path.GetFileName(sFileName)) == true)
                    {
                        throw new Exception("Archivo en uso");
                    }
                }
            }
            lock (syncLock)
            {
                if (oTipoLog != TipoLog.PLANO)
                {
                    if (bEnabledTracking == true)
                    {
                        string sNameFile = sFileName;
                        if (oTipoLog != TipoLog.TRAZA)
                        {
                            sNameFile = sNameFile + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".log";
                        }
                        else
                        {
                            sNameFile = sNameFile + ".log";
                        }
                        // create a writer and open the file
                        System.IO.TextWriter tw = new System.IO.StreamWriter(sNameFile, true);

                        // write a line of text to the file
                        tw.WriteLine(message);

                        // close the stream
                        tw.Close();
                    }
                }
                else
                {
                    string sNameFile = sFileName;

                    // create a writer and open the file
                    System.IO.TextWriter tw = new System.IO.StreamWriter(sNameFile, true);

                    // write a line of text to the file
                    tw.WriteLine(message);

                    // close the stream
                    tw.Close();
                }
            }


        }
        public static bool VerificaArchivoEnUso(string sRuta, string sNombreArchivo)
        {
            try
            {
                using (var stream = new FileStream(sRuta + "\\" + sNombreArchivo, FileMode.Open, FileAccess.Read)) { }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

    }
    internal enum TipoLog
    {
        ERROR,
        TRAZA,
        PLANO
    }
}
