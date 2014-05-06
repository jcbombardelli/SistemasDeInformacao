using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstruturaDeDados20140424_Arvore_04_Balanceada_AVL
{
    class Arvore
    {
        private int info;
        private int fb;

        private int maxnivel, aux, maxnivelb, auxb;

        //SAE = Subárvore da esquerda.
        //SAD = Subárvore da direita.
        Arvore SAE, SAD;
        
        public Arvore()
        {
            info = fb = 0;
            SAE = SAD = null;

        }

        public void insere(int n, ref Arvore raiz)
        {
            Arvore temp, subarv;
            this.info = n;
            maxnivel = aux = maxnivelb = auxb = 0;

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

        public int pesquisa(int n) {
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

        public void preOrdem()
        {
            Console.WriteLine("Info: {0}    Fator Balanceamento: {1}",this.info, this.fb);
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

            while (arrayarvore.Count != 0)
            {
                temp = arrayarvore.First();
                Console.WriteLine(temp.info);
                if (temp.SAE != null)
                    arrayarvore.Add(temp.SAE);
                if (temp.SAD != null)
                    arrayarvore.Add(temp.SAD);
                arrayarvore.RemoveAt(0);
            }
        }

        public int altura(ref int aux, ref int maxnivel)
        {

            if (this.SAE != null)
            {
                aux++;
                (this.SAE).altura(ref aux, ref  maxnivel);
            }

            maxnivel = aux;
            if (this.SAD != null)
            {
                aux++;
                (this.SAD).altura(ref aux, ref maxnivel);
            }
            if (aux > maxnivel)
                maxnivel = aux;

            aux--;
            return maxnivel;
        }

        public bool isAvl() {

            if (this.fb <= -1 || this.fb >= 1)
                return false;

            if (this.SAE != null)
                (this.SAE).isAvl();
            if (this.SAD != null)
                (this.SAD).isAvl();
            return true;

        }

        public void calculaAvl() {
            
            if (this.SAD != null && this.SAE != null)
                this.fb = (this.SAD.altura(ref aux, ref maxnivel)+1) - (this.SAE.altura(ref auxb, ref maxnivelb)+1);
            else if (this.SAD != null && this.SAE == null)
                this.fb = (this.SAD.altura(ref aux, ref maxnivel)+1) - 0;
            else if (this.SAD == null && this.SAE != null)
                this.fb = 0 - (this.SAE.altura(ref auxb, ref maxnivelb)+1);
            else
                this.fb = 0;

            maxnivel = aux = maxnivelb = auxb =  0;
            if (this.SAE != null)
                (this.SAE).calculaAvl();
            if (this.SAD != null)
                (this.SAD).calculaAvl();
        }

    }
}
