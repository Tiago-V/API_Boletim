using API_Boletim.Context;
using API_Boletim.Domains;
using API_Boletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        // Chamamos contexto de conexão
        BoletimContext conexao = new BoletimContext();

        // Chamamos a classe que permite colocar consultas de banco
        SqlCommand cmd = new SqlCommand();

        public Aluno Alterar(Aluno a)
        {
            throw new NotImplementedException();
        }

        public Aluno BuscarPorId(int id)
        {
            // Abrimos a conexão
            cmd.Connection = conexao.Conectar();

            // Atribuimos nossa conexão
            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";

            // Dizemos quem é @id
            cmd.Parameters.AddWithValue("@id", id);

            // Lemos os dados
            SqlDataReader dados = cmd.ExecuteReader();

            // Instaciar Aluno
            Aluno a = new Aluno();

            // Laço para ler linhas 
            while (dados.Read())
            {
                a.IdAluno = Convert.ToInt32(dados.GetValue(0));
                a.Nome    = dados.GetValue(1).ToString();
                a.RA      = dados.GetValue(2).ToString();
                a.Idade = Convert.ToInt32(dados.GetValue(3));
            }

            // Fechamos a conexão
            conexao.Desconectar();

            return a;
        }

        internal string BuscarPorId()
        {
            throw new NotImplementedException();
        }

        public Aluno Cadastrar(Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Aluno " +
                "Nome, Ra, Idade" +
                "VALUES" +
                "{@nome, @ra, @idade}";

            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public List<Aluno> ListarTodos()
        {
            // Abrimos a conexão
            cmd.Connection = conexao.Conectar();

            // Atribuimos nossa conexão
            cmd.CommandText = "SELECT * FROM Aluno";

            // Lemos os dados
            SqlDataReader dados = cmd.ExecuteReader();

            // Criamnos uma lista para ser populada
            List<Aluno> alunos = new List<Aluno>();

            // Criamos um laço para ler todas as linhas
            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome    = dados.GetValue(1).ToString(),
                        RA      = dados.GetValue(2).ToString(),
                        Idade   = Convert.ToInt32(dados.GetValue(3))
                    }
                ); 
            }

            // Fechamos a conexão
            conexao.Desconectar();

            return alunos;
        }

        public Aluno Remover(Aluno a)
        {
            throw new NotImplementedException();
        }
    }
}
