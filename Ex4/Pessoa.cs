using System;

namespace Ex4
{
    internal class Pessoa
    {

        private readonly string nome;

        private CertidaoNascimento certidao;

        internal Pessoa(string nome) 
        {
            this.nome = nome;
        }

        internal void SetCertidao(DateTime d)
        {
            if (certidao is null)
                this.certidao = new(this, d);
            else
                throw new Exception("Certidão é imutável");
        }

        public override string ToString()
        {
            return $"{nome}\t{(certidao == null ? "N/A" : this.certidao)}";
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
