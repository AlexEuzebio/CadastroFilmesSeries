using System;

namespace CadastroFilmesSeries
{
    public class Conteudo : EntidadeBase
    {
        // Atributos
        private Genero genero { get; set; }
        private Tipo tipo { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }
        private int ano { get; set; }
        private bool excluido { get; set; }
        
        // Métodos
        public Conteudo(int id, Genero genero, Tipo tipo, string titulo, string descricao, int ano){
            this.Id = id;
            this.genero = genero;
            this.tipo = tipo;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Título    : " + this.titulo + Environment.NewLine;
            retorno += "Tipo      : " + this.tipo + Environment.NewLine;
            retorno += "Gênero    : " + this.genero + Environment.NewLine;
            retorno += "Descrição : " + this.descricao + Environment.NewLine;
            retorno += "Ano Início: " + this.ano + Environment.NewLine;
            retorno += "Excluído  : " + this.excluido;
            return retorno;

        }

        public string retornaTitulo(){
            return this.titulo;
        }
        public int retornaId(){
            return this.Id;
        }

        public void excluir(){
            this.excluido = true;
        }

        public Tipo retornaTipo()
        {
            return this.tipo;
        }
    }
    
}