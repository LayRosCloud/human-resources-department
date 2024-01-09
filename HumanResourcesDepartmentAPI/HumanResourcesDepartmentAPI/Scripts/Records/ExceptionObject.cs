using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesDepartmentAPI.Scripts.Records
{
    public class ExceptionObject
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ExceptionObject(int status, string message)
        {
            StatusCode = status;
            Message = message;
        }
    }
}
