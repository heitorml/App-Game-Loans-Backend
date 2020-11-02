using System.Collections.Generic;
using System.Net;

namespace AppGameLoans.Domain.Helpers
{
    public class Result<T> : Result where T : class
    {
        public Result()
        {
        }

        public Result(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }

    public class Result
    {
        public bool Success { get; protected set; }
        public string Message { get; set; }
        public bool HasError => !Success;
        public IList<string> Errors { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public object Object { get; set; }
        public List<object> Objects { get; set; } = new List<object>();
        public object Request { get; set; }
        public bool HasSuccess { get; protected set; }

        public Result()
        {
            HasSuccess = true;
            HttpStatusCode = HttpStatusCode.OK;
            Errors = new List<string>();
        }

        public void WithError(string errorMessage)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
            HasSuccess = false;
            Errors.Add(errorMessage);
        }


        public void ReturnInsert(object model)
        {
            Success = true;
            HttpStatusCode = HttpStatusCode.OK;
            Object = model;
            Message = "Inserido com sucesso";
        }
    }
}
