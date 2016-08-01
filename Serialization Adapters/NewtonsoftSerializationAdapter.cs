﻿using CF.RESTClientDotNet;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace RESTServiceConsumer
{
    public class NewtonsoftSerializationAdapter : ISerializationAdapter
    {
        public async Task<byte[]> DecodeStringAsync(string theString)
        {
            return await Task.Run(() => Encoding.UTF8.GetBytes(theString));
        }

        public async Task<T> DeserializeAsync<T>(string markup)
        {
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(markup));
        }

        public async Task<string> EncodeStringAsync(byte[] bytes)
        {
            return await Task.Run(() => Encoding.UTF8.GetString(bytes, 0, bytes.Length));
        }

        public async Task<string> SerializeAsync(object objectToSerialize)
        {
            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(objectToSerialize));
        }
    }
}
