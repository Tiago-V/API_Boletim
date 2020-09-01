using API_Boletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Interfaces
{
    interface IAluno
    {
        // CRUD -

        List<Aluno> ListarTodos();
        Aluno BuscarPorId(int id);
        Aluno Cadastrar(Aluno a);
        Aluno Alterar(Aluno a);
        Aluno Remover(Aluno a);
    }
}
