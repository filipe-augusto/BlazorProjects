﻿namespace Blazor_Admin.Data
{
    public class SqlConnectionConfiguration
    {
        public string ConnectionString { get; }
        public SqlConnectionConfiguration(string stringConexao) 
            => this.ConnectionString = stringConexao;
    }
}
