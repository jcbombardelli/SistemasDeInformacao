using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstruturaDeDados20140417___Arvore_03
{
    class Arvore
    {
        public Arvore() {
            info = 0; 
            SAE = SAD = null;
        }

        private int info;

        //SAE = Subárvore da esquerda.
        //SAD = Subárvore da direita.
        Arvore SAE, SAD;

        public void insere(int n, ref Arvore raiz) {
            Arvore temp, subarv;
            this.info = n;

            if (raiz == null)
                raiz = this;
            else {
                temp = raiz;
                while (temp != null) {
                    subarv = temp;
                    if (n <= temp.info) {
                        temp = temp.SAE;
                        if (temp == null)
                            subarv.SAE = this;
                    }
                    else {
                        temp = temp.SAD;
                        if (temp == null)
                            subarv.SAD = this;
                    }
                }
            }
        }

        public int pesquisa(int n)  {
            Arvore temp = this;
            int nivel = 0;

            do {
                if (n == temp.info)
                    return nivel;
                else if (n > temp.info)
                    temp = temp.SAD;
                else
                    temp = temp.SAE;
                nivel++;

            } while (temp != null);
            return -1;

        }

        public void preOrdem() {
            Console.WriteLine(this.info);
            if (this.SAE != null)
                (this.SAE).preOrdem();
            if (this.SAD != null)
                (this.SAD).preOrdem();
        }

        public void posOrdem() {
            if (this.SAE != null)
                (this.SAE).posOrdem();
            if (this.SAD != null)
                (this.SAD).posOrdem();
            Console.WriteLine(this.info);
        }

        public void inOrdem() {
            if (this.SAE != null)
                (this.SAE).inOrdem();
            Console.WriteLine(this.info);
            if (this.SAD != null)
                (this.SAD).inOrdem();
        }

        public void emNivel() {
            Arvore temp;
            List<Arvore> arrayarvore = new List<Arvore>() { this };

            while (arrayarvore.Count != 0) {
                temp = arrayarvore.First();
                Console.WriteLine(temp.info);
                if (temp.SAE != null)
                    arrayarvore.Add(temp.SAE);
                if (temp.SAD != null)
                    arrayarvore.Add(temp.SAD);
                arrayarvore.RemoveAt(0);
            }
        }

        public int altura(ref int aux, ref int maxnivel) {

            if (this.SAE != null) {
                aux++;
                (this.SAE).altura(ref aux, ref  maxnivel);
            }

            maxnivel = aux;
            if (this.SAD != null) {
                aux++;
                (this.SAD).altura(ref aux, ref maxnivel);
            }
            if (aux > maxnivel)
                maxnivel = aux;

            aux--;
            return maxnivel;
        }
    }
}