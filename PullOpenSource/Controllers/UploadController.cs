using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PullOpenSource.Controllers
{
    public class UploadController : Controller
    {

        private static string INSERT_NOMINA = @"INSERT INTO DatosEmpresa VALUES(@TipoRegistro,@TipoArchivo,@Identificacion,@Periodo, @CodigoMoneda);";
        private static string INSERT_DETALLE_NOMINA = @"INSERT INTO DatosEmpleado(EmpleadoId,Sueldo,NoCuenta) VALUES(@EmpleadoId,@Sueldo,@NoCuenta);";
        // GET: Upload
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult UploadFile(HttpPostedFileBase file)
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", _FileName);
                    using (var stream = new FileStream(_path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    ReadFile(_path);
                }
                ViewBag.Message = "El archivo ha sido enviado";

                return View();
            }
            catch
            {
                ViewBag.Message = "No se pudo enviar el archivo";
                return View();
            }
        }

        public void ReadFile(string path)
        {
            SqlConnection conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=aspnet-PullOpenSource-76C46C02-D792-449E-8CEC-92D47D683EF2;Trusted_Connection=True;MultipleActiveResultSets=true");

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    conn.Open();
                    string[] partes = sr.ReadToEnd().Split('|');

                    try
                    {

                        SqlCommand command = new SqlCommand(INSERT_NOMINA, conn);

                        command.Parameters.AddWithValue("@TipoRegistro", partes[0].ToString());
                        command.Parameters.AddWithValue("@TipoArchivo", partes[1].ToString());
                        command.Parameters.AddWithValue("@Identificacion", partes[2].ToString());
                        command.Parameters.AddWithValue("@Periodo", partes[3].ToString());
                        command.Parameters.AddWithValue("@CodigoMoneda", partes[4].ToString());

                        //Console.WriteLine($"{partes[0]},{partes[1]},{partes[2]}");

                        int result = command.ExecuteNonQuery();
                        //conn.Close();
                        //Check Error
                        if (result < 0)
                            ViewBag.Message = "Error insertando el encabezado en la BD!";
                    }
                    catch (Exception e)
                    {

                        ViewBag.Message = "Error en Encabezado >>> \n" + e.StackTrace + "\n";
                    }


                    for (int i = 5; i <= partes.Length; i += 3)
                    {

                        
                        try
                        {

                            SqlCommand command1 = new SqlCommand(INSERT_DETALLE_NOMINA, conn);
                            command1.Parameters.AddWithValue("@EmpleadoId", partes[i].ToString());
                            command1.Parameters.AddWithValue("@Sueldo", partes[i + 1].ToString());
                            command1.Parameters.AddWithValue("@NoCuenta", partes[i + 2].ToString());
                        

                            int result1 = command1.ExecuteNonQuery();

                            
                            // Check Error
                            if (result1 < 0)
                                Console.WriteLine("Error insertando los detalles en la BD!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nError en Detalle >>> \n" + e.StackTrace + "\n");
                        }


                    }
                    sr.Close();
                    conn.Close();
                    //Console.WriteLine(partes[0].ToString());

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("");
            }

        }

    }
}