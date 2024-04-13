﻿namespace backend_funcionario_webapi_aspdotnet.Models
{
    public class Response<T>
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; } = string.Empty;
        public T? Dados { get; set; }
    }
}