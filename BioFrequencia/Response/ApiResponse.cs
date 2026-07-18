using BioFrequencia.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BioFrequencia.Response
{
        public class ApiResponse<T>
        {
            public bool Sucesso { get; set; }
            public string Mensagem { get; set; }
            public T Dados { get; set; }
        }
    
}
