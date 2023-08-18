using CRUDlabSODRE.Data;
using CRUDlabSODRE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace CRUDlabSODRE.Controllers
{
    public class CargosController : Controller
    {
       
        public IActionResult Cargo()
        {
            string connectionString = "server=DOUGLAS\\SQLEXPRESS; Database=Emprestimos; trusted_connection=true;TrustServerCertificate=Yes";
            string query = @"
            
            

                SELECT IdCargo, COUNT(*) AS Quantidade, SUM(Salario) AS SomaSalario
                FROM dbo.Sodre
                GROUP BY IdCargo;
           
            ";
            var quantidade = query;
            List<SodreModel> quantidadeCargos = new List<SodreModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            float somaSalario = Convert.ToSingle(reader["SomaSalario"]);
                            quantidadeCargos.Add(new SodreModel
                            {
                                IdCargo = (int)reader["IdCargo"],
                                Quantidade = (int)reader["Quantidade"],
                                Salario = somaSalario
                                
                                

                            });
                        }
                    }
                }
            }

            return View(quantidadeCargos);
        }
        
        
    }
}
