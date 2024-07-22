﻿using System.Net;

namespace Dataflow.Server.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public async Task<string?> GetErrorMessageAsync() 
        {
            if (!Error) 
            {
                return null;
            }
            var statusCode = HttpResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound) 
            {
                return "Recurso no encontrado";
            }
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Tiene que estar logueado para ejecutar esta operacion";
            }
            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "No tiene permisos para realizar esta operacion.";
            }
            return "Ha ocurrido un error inesperado.";
        } 
    }
}
