using System.Text.Json.Serialization;

namespace backend_funcionario_webapi_aspdotnet.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Departamento
    {
        RH,
        Financeiro,
        Compras,
        Atendimento,
        Zeladoria
    }
}
