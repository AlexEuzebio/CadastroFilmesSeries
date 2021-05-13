using System;

namespace CadastroFilmesSeries
{
    class Program
    {
        static ConteudoRepositorio repositorio = new ConteudoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();
            Console.WriteLine("opcao:" + opcaoUsuario);
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listarConteudo("Séries",Tipo.Serie);
                        break;
                    case "2":
                        listarConteudo("Filmes",Tipo.Filme);
                        break;
                    case "3":
                        listarConteudo("Tudo",Tipo.Generico);
                        break;
                    case "4":
                        inserirConteudo();
                        break;
                    case "5":
                        atualizarConteudo();
                        break;
                    case "6":
                        excluirConteudo();
                        break;
                    case "7":
                        visualizarConteudo();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = obterOpcaoUsuario();
            }
        }

        private static void visualizarConteudo()
        {
            Console.WriteLine("---Visualizar conteúdo---");
            Console.Write("Digite o ID a ser visualizado:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(repositorio.retornaPorId(id).ToString());
        }

        private static void excluirConteudo()
        {
            Console.WriteLine("---Excluir conteúdo---");
            Console.Write("Digite o ID a ser excluído:");
            int id = int.Parse(Console.ReadLine());
            repositorio.exclui(id);
        }

        private static void atualizarConteudo()
        {
            Console.WriteLine("---Atualizar conteúdo---");
            Console.Write("Digite o ID a ser atualizado:");
            int id = int.Parse(Console.ReadLine());
            repositorio.atualiza(id, editaConteudo(false));
        }

        private static void inserirConteudo()
        {
            Console.WriteLine("---Inserir conteúdo---");
            repositorio.insere(editaConteudo(true));
        }
        private static Conteudo editaConteudo(bool inclusao)
        {
            //----------- Tipo:
            Console.WriteLine();
            foreach(int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0} = {1}", i, Enum.GetName(typeof(Tipo), i));
            }
            Console.Write("Digite o Tipo conforme acima:");
            int entradaTipo = int.Parse(Console.ReadLine());
            //----------- Gênero:
            Console.WriteLine();
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} = {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero conforme acima:");           
            int entradaGenero = int.Parse(Console.ReadLine());
            //----------- Título:
            Console.WriteLine();
            Console.Write("Digite o Título:");
            string entradaTitulo = Console.ReadLine();
            //----------- Descrição:
            Console.WriteLine();
            Console.Write("Digite a Descrição:");
            string entradaDescricao = Console.ReadLine();            
            //----------- Ano início:
            Console.WriteLine();
            Console.Write("Digite o Ano início:");
            int entradaAno = int.Parse(Console.ReadLine());

            int id = 0;
            if (inclusao)
            {
                id = repositorio.proximoId();
            }
            Conteudo conteudoEditado = new Conteudo(id,
                                                genero: (Genero)entradaGenero,
                                                tipo: (Tipo)entradaTipo,
                                                titulo: entradaTitulo,
                                                descricao: entradaDescricao,
                                                ano: entradaAno );
            return conteudoEditado;
        }

        private static void listarConteudo(string titulo, Tipo tipo)
        {
            Console.WriteLine("Listar " + titulo);
            var lista = repositorio.lista(tipo);
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum conteúdo cadastrado");
                return;
            }
            
            foreach (var conteudo in lista)
            {
                Console.WriteLine("{0} - {1} ({2})", conteudo.retornaId(), conteudo.retornaTitulo(), conteudo.retornaTipo());
            }
        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1= Listar Séries");
            Console.WriteLine("2= Listar Filmes");
            Console.WriteLine("3= Listar Tudo");
            Console.WriteLine("4= Inserir novo conteúdo");
            Console.WriteLine("5= Atualizar");
            Console.WriteLine("6= Excluir");
            Console.WriteLine("7= Visualizar");
            Console.WriteLine("C= Limpar a tela");
            Console.WriteLine("X= Sair");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            Console.Clear();
            return opcao;
        }
    }
}
