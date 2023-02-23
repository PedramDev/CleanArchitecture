namespace CleanArchitecture.Common.Shared
{
    public class ListOf<TViewModel> :
      Response<TViewModel>
    {
        public ListOf()
        {
            Data = new List<TViewModel>();
        }

        public int TotalSize { get; set; }
        public new IEnumerable<TViewModel> Data { get; set; }
    }
    public static class ResponseExtensions
    {
        public static Response Update(this Response response, Response newResponse)
        {
            return Response.UpdateCurrent(response, newResponse);
        }
    }

    public class Response
    {
        public bool IsSuccess { get; protected set; }
        public string? Message { get; protected set; }
        public ResponseType Type { get; protected set; }
        public object? Extra { get; protected set; }

        public virtual Response Success()
        {
            Type = ResponseType.Ok;
            this.IsSuccess = true;

            return this;
        }

        private Response Faild()
        {
            IsSuccess = false;
            return this;
        }

        public Response Unknown()
        => Unknown(null);

        public Response Unknown(string? message)
        {
            Faild();
            AddMessage(message);
            Type = ResponseType.Unknown;
            return this;
        }

        public Response NotFound()
        => NotFound(null);

        public Response NotFound(string? message)
        {
            Faild();
            AddMessage(message);
            Type = ResponseType.NotFound;
            return this;
        }

        public Response BadRequest()
          => BadRequest(null);

        public Response BadRequest(string? message)
        {
            Faild();
            AddMessage(message);
            Type = ResponseType.BadRequest;
            return this;
        }

        public Response NotAllowed()
        => NotAllowed(null);

        public Response NotAllowed(string? message)
        {
            Faild();
            AddMessage(message);
            Type = ResponseType.NotAllowed;
            return this;
        }

        public Response Conflict()
          => Conflict(null);

        public Response Conflict(string? message)
        {
            Faild();
            AddMessage(message);
            Type = ResponseType.Conflict;
            return this;
        }

        public Response ServiceUnavailable()
          => ServiceUnavailable(null);

        public Response ServiceUnavailable(string? message)
        {
            Faild();
            AddMessage(message);
            Type = ResponseType.ServiceUnavailable;
            return this;
        }

        public Response AddExtra(object? obj)
        {
            Extra = obj;
            return this;
        }

        public Response AddMessage(string? message)
        {
            if (message != null)
            {
                Message = message;
            }
            return this;
        }

        public static implicit operator bool(Response response) => response.IsSuccess;

        internal static Response UpdateCurrent(Response current, Response newOne)
        {
            current.Type = newOne.Type;
            current.Message = newOne.Message;
            current.IsSuccess = newOne.IsSuccess;
            current.Extra = newOne.Extra;
            return current;
        }
    }

    public class Response<TData> : Response
    {
        public virtual TData? Data { get; set; }

        public override Response<TData> Success()
        {
            Type = ResponseType.Ok;
            this.IsSuccess = true;

            return this;
        }
    }

    public enum ResponseType
    {
        NotFound = 404,
        Ok = 200,
        BadRequest = 400,
        Conflict = 409,
        NotAllowed = 405,
        Unknown = 500,
        ServiceUnavailable = 503,
    }
}