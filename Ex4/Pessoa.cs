using System;

namespace Ex4
{
    internal class Pessoa
    {

        private readonly string nome;

        private CertidaoNascimento Certidao { get; set; }

        internal Pessoa(string nome) 
        {
            this.nome = nome;
        }

        internal void SetCertidao(DateTime d)
        {
            Certidao = new(this, d);
        }

        public override string ToString()
        {
            return $"{nome}\t{(Certidao == null ? "N/A" : Certidao)}";
        }

        // Certidão de Nascimento só pode ser criada
        // pela classe Pessoa. Assim, uma 
        private class CertidaoNascimento
        {
            private readonly DateTime dataDeEmissao;

            private readonly Pessoa p;

            internal CertidaoNascimento(Pessoa p, DateTime dataDeEmissao)
            {
                this.dataDeEmissao = dataDeEmissao;
                this.p = p;
            }

            public override string ToString()
            {
                return $"{dataDeEmissao}";
            }
        }
    }
}
