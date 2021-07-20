using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarefas_Revisao.Entidades;

namespace Tarefas_Revisao.Repositorio
{
    interface IRepositorio
    {
        IList<Tarefa> ObterTarefas();


    }
}
