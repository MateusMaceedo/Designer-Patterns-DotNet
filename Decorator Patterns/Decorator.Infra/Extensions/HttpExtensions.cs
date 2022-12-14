using System.Net;
using System.Net.Http;

namespace Decorator.Domain.Extensions
{
    public static class HttpExtensions
    {
        public static bool IsSuccess(this HttpStatusCode statusCode) =>
           new HttpResponseMessage(statusCode).IsSuccessStatusCode;
    }
}
