using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TipoClienteBuilder = Ex1.Cliente.ClienteBuilder;
using TipoCliente = Ex1.Cliente.Cliente;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Newtonsoft.Json;

namespace Ex1.Format
{
    public class JsonFormat : IFormat
    {

        public string Encode(object output)
        {
            try
            {
                var tmp = (List<TipoClienteBuilder>)output;

                var t = tmp.Select(x=> new Output(x)).ToList();

                var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All), WriteIndented = true };
                return System.Text.Json.JsonSerializer.Serialize<List<Output>>(t, options);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected Error");
            }
        }

        public Queue<string> Decode(string json)
        {
            var clientes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Input>>(json);

            var q = new Queue<string>();

            foreach (var cliente in clientes)
            {
                q.Enqueue(cliente.Nome);
                q.Enqueue(cliente.Cpf);
                q.Enqueue(cliente.DataDeNascimento);
                q.Enqueue(cliente.RendaMensal);
                q.Enqueue(cliente.EstadoCivil);
                q.Enqueue(cliente.Dependentes);
            }

            return q;
        }

        private struct Output
        {
            public TipoCliente Dados { get; set; }
            public string[] Erros { get; set; }

            public Output(TipoClienteBuilder t)
            {
                this.Dados = Newtonsoft.Json.JsonConvert.DeserializeObject<TipoCliente>(t.ToJson());
                this.Erros = t.Erros.Where(x => x is not null).ToArray();
            }
        }

        private struct Input
        {
            [JsonProperty("nome")]
            public string Nome { get; set; }
            [JsonProperty("cpf")]
            public string Cpf { get; set; }
            [JsonProperty("dt_nascimento")] 
            public string DataDeNascimento { get; set; }
            [JsonProperty("renda_mensal")]
            public string RendaMensal { get; set; }
            [JsonProperty("estado_civil")]
            public string EstadoCivil { get; set; }
            [JsonProperty("dependentes")]
            public string Dependentes { get; set; }
        }
    }
}
