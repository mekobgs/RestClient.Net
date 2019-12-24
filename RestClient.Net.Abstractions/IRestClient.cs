using System;
using System.Threading.Tasks;

namespace RestClientDotNet.Abstractions
{
    public interface IRestClient
    {
        ISerializationAdapter SerializationAdapter { get; }
        Task<RestResponseBase<TResponseBody>> SendAsync<TResponseBody, TRequestBody>(RestRequest<TRequestBody> restRequest);
        IRestHeaders DefaultRequestHeaders { get; }
        string DefaultContentType { get; }
        TimeSpan Timeout { get; set; }
    }
}