namespace StudyBuddy.Core.GenericResponse
{
   public class GenericResponse<T>
   {
      public int StatusCode { get; private set; }

      public T? Payload { get; private set; }
      public string? Message { get; private set; }
      public bool Status { get; private set; }
      public IEnumerable<string> Errors { get; private set; } = [];

      public static GenericResponse<T> Success(T? payload, string message, short statusCode) => new()
      {
         Payload = payload,
         StatusCode = statusCode,
         Message = message,
         Status = true
      };

      public static GenericResponse<T> Success(string message, short statusCode) => new()
      {
         Status = true,
         Message = message,
         StatusCode = statusCode
      };

      public static GenericResponse<T> Failure(T? payload, string message, short statusCode) => new()
      {
         Status = false,
         StatusCode = statusCode,
         Message = message,
         Payload = payload
      };

      public static GenericResponse<T> Failure(string message, short statusCode) => new()
      {
         Status = false,
         StatusCode = statusCode,
         Message = message
      };

      public static GenericResponse<T> Error(string message, short statusCode, IEnumerable<string> error) => new()
      {
         Status = false,
         StatusCode = statusCode,
         Message = message,
         Errors = error
      };

   }
}

public class GenericResponse
{
   public int StatusCode { get; private set; }
   public string? Message { get; private set; }
   public bool Status { get; private set; }
   public IEnumerable<string> Errors { get; private set; } = [];

   public static GenericResponse Success(string message, short statusCode) => new()
   {
      Status = true,
      Message = message,
      StatusCode = statusCode
   };

   public static GenericResponse Failure(string message, short statusCode) => new()
   {
      Status = false,
      Message = message,
      StatusCode = statusCode
   };

   public static GenericResponse Error(string message, short statusCode, IEnumerable<string> error) => new()
   {
      Status = false,
      StatusCode = statusCode,
      Message = message,
      Errors = error
   };
}