using BlogPostApi.Code;
using BlogPostApi.Model;
using Dapper;

using System;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace BlogPostApi.Repository
{
    public class MySqlRepository : IRepositoryBase
    {
        private readonly IDbConnection _db;
        // public IConfiguration Configuration { get; }

        public MySqlRepository()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            _db = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }

        public void Dispose()
        {
            _db.Close();
        }

        public List<Cidade> SearchCidades(string nome)
        {
            // nome = "Juiz de Fora";

            if (string.IsNullOrEmpty(nome))
                return _db.Query<Cidade>("SELECT * FROM GLB_Cidade ORDER BY Nome ASC LIMIT 10").ToList();

            nome = nome.Trim();

            return _db.Query<Cidade>("SELECT * FROM GLB_Cidade WHERE Nome LIKE @Nome ORDER BY Nome ASC LIMIT 10", new { Nome = string.Format("%{0}%", nome) }).ToList();
        }

        public List<Uf> SearchUfs(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return _db.Query<Uf>("SELECT * FROM GLB_UF ORDER BY Nome ASC LIMIT 10").ToList();

            nome = nome.Trim();

            return _db.Query<Uf>("SELECT * FROM GLB_UF WHERE Nome LIKE @Nome ORDER BY Nome ASC LIMIT 10", new { Nome = string.Format("%{0}%", nome) }).ToList();
        }

        public List<Pais> SearchPaises(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return _db.Query<Pais>("SELECT * FROM GLB_Pais ORDER BY Nome ASC LIMIT 10").ToList();

            nome = nome.Trim();

            return _db.Query<Pais>("SELECT * FROM GLB_Pais WHERE Nome LIKE @Nome ORDER BY Nome ASC LIMIT 10", new { Nome = string.Format("%{0}%", nome) }).ToList();
        }
    }
}