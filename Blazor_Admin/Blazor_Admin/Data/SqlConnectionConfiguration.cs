using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Admin.Data
{
    public class SqlConnectionConfiguration
    {
        public string  ConnectionString { get; set; }

        public SqlConnectionConfiguration(string stringConexao)
            => this.ConnectionString = stringConexao;
    }
}
