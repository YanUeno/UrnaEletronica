using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica
{
    internal class Candidatos
    {
        private String nome;
        private String dataNascimento { get; }
        private Int32 codigo { get; }
        private String Partido { get; }
        private String caminhoImagem { get; }


        public Candidatos()
        {

        }
        public Candidatos(string nome, string dataNascimento,String Partido, Int32 codigo, string caminhoImagem)
        {
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.codigo = codigo;
            this.Partido = Partido;
            this.caminhoImagem = caminhoImagem;
        }
        public String getNome()
        {
            return this.nome;
        }
        public String getdataNascimento()
        {
            return this.dataNascimento;
        }
        public Int32 getCodigo()
        {
            return this.codigo;
        }
        public String getCaminhoImagem()
        {
            return this.caminhoImagem;
        }
        public String getPartido()
        {
            return this.Partido;
        }
    }
}
