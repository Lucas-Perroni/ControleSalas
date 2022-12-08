using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControleSalas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Salas : ControllerBase
    {
        [HttpGet]
        public string ListaSalas(string p_nome_sala)

        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=ControleSalas;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoCEP2 = new DataSet();


            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = $"select * from Sala where Nome like '%{p_nome_sala}%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoCEP2);

            string json = JsonConvert.SerializeObject(resultadoCEP2, Formatting.Indented);

            return json;
        }
    }
}
