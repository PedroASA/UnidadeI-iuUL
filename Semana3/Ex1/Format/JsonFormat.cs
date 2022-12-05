using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ex1.ClienteNamespace;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/*
 * Classe Responsável pela lógica de Serialização e Deserialização do Input e Output
 */

namespace Ex1.Format
{
    public class JsonFormat : IFormat<Queue<Input>, List<(Input, Cliente.ClienteBuilder)>>
    {

        public string Encode(List<(Input, Cliente.ClienteBuilder)> output)
        {
            try
            {

                var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All), WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
                return System.Text.Json.JsonSerializer.Serialize<List<Output>>(output.Select(x=> new Output(x)).ToList(), options);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected Error");
            }
        }

        public Queue<Input> Decode(string json)
        {
            var clientes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Input>>(json);

            var q = new Queue<Input>(clientes);

            return q;
        }
    }

    public struct Output
    {
        public Input Dados { get; set; }
        public Dictionary<string, string> Erros { get; set; }

        public Output((Input, Cliente.ClienteBuilder) t)
        {
            this.Dados = t.Item1;

            this.Erros = new Dictionary<string, string>();

            foreach (var e in t.Item2.Erros.Where(x => x is not null))
            {
                Erros.Add(e.Campo, e.Mensagem);
            }
        }
    }

    public struct Input
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
