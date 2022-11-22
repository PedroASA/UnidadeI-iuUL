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

        // Adicionar Certidão de Nascimento
        internal void SetCertidao(DateTime d)
        {
            if (certidao is null)
                this.certidao = new(this, d);
            else
                throw new Exception("Certidão é imutável");
        }

        public override string ToString()
        {
            return $"Nome: {nome}\nCertidão: {(certidao == null ? "N/A" : this.certidao)}";
        }

        // Certidão de Nascimento só pode ser criada
        // pela classe Pessoa. (Construtor Privado)
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
                return $"\n\tTitular: {p.nome}\n\tData de Emissão: {dataDeEmissao}";
            }
        }
    }
}
