using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstruturaDeDados20140417___Arvore_03
{
    class Program
    {
        static void menu() {
            Console.Clear();
            Console.WriteLine(" ---Menu Principal---\n");
            Console.WriteLine("(1) - Insere um elemento");
            Console.WriteLine("(2) - Consulta um elemento");
            Console.WriteLine("(3) - Listagem em Pré Ordem");
            Console.WriteLine("(4) - Listagem em Pós Ordem");
            Console.WriteLine("(5) - Listagem \"In Ordem\" ");
            Console.WriteLine("(6) - Em Nivel");
            Console.WriteLine("(7) - Altura");
            Console.WriteLine("(8) - Sair");
            Console.Write("\n\n> ");
        }

        static void Main(string[] args) {

            int op, n;
            Arvore arv, raiz = null;

            do {
                menu();
                op = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (op) {

                    case 1:
                        Console.Write("Digite um valor para ser inserido : ");
                           n = int.Parse(Console.ReadLine());
                        arv = new Arvore();
                        arv.insere(n, ref raiz);
                        break;

                    case 2:
                        Console.Write("Digite um valor para ser buscado : ");
                        n = int.Parse(Console.ReadLine());
                        if (raiz != null) {
                            int i = raiz.pesquisa(n);

                            if (i != -1)
                                Console.WriteLine("O numero foi encontrado no nivél {0}", i);
                            else
                                Console.WriteLine("O numero não foi encontrado");
                        } else
                            Console.WriteLine("Não existem niveis para serem exibidos");
                        Console.ReadKey();
                        break;

                    case 3:
                        if (raiz != null)
                            raiz.preOrdem();
                        else
                            Console.WriteLine("Não existem niveis para serem exibidos");

                        Console.ReadKey();
                        break;

                    case 4:
                        if (raiz != null)
                            raiz.posOrdem();
                        else
                            Console.WriteLine("Não existem niveis para serem exibidos");

                        Console.ReadKey();
                        break;

                    case 5:
                        if (raiz != null)
                            raiz.inOrdem();
                        else
                            Console.WriteLine("Não existem niveis para serem exibidos");

                        Console.ReadKey();
                        break;

                    case 6:
                        if (raiz != null)
                            raiz.emNivel();
                        else
                            Console.WriteLine("Não existem niveis para serem exibidos");

                        Console.ReadKey();
                        break;

                    case 7:
                        int maxnivel = 0; ;
                        int aux = 0;

                       if (raiz != null)
                           Console.WriteLine("A altura da atual arvore é : {0}", raiz.altura(ref aux, ref  maxnivel));
                        else
                            Console.WriteLine("Arvore sem altura para ser exibida");

                        Console.ReadKey();
                        break;

                    case 98:
                        //Preenchimento automatico para teste
                        int[] valores98 = new int[] { 6, 2, 8, 1, 4, 7, 9, 3, 5 };
                        for (int i = 0; i < valores98.Length; i++) {
                            arv = new Arvore();
                            arv.insere(valores98[i], ref raiz);
                        }
                        break;

                    case 99:
                        //Preenchimento automatico para teste
                        int[] valores99 = new int[] { 50, 45, 60, 43, 47, 42, 44, 49, 48 };
                        for (int i = 0; i < valores99.Length; i++) {
                            arv = new Arvore();
                            arv.insere(valores99[i], ref raiz);
                        }
                        break;

                }
            } while (op != 8);
        }
    }
}
