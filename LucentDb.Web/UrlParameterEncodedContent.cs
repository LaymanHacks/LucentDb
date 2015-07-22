using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LucentDb.Web
{
    public class UrlParameterEncodedContent 
    {
        private readonly Dictionary<string, string> _urlParametersDictionary;

        public UrlParameterEncodedContent(Dictionary<string, string> urlParametersDictionary)
        {
            _urlParametersDictionary = urlParametersDictionary;
        }

        public override string ToString()
        {
            var response = new StringBuilder("?");

            foreach (var urlParams in _urlParametersDictionary.Where(value => !String.IsNullOrEmpty(value.Key) && !String.IsNullOrEmpty(value.Value)))
            {
                response.AppendFormat("{0}={1}", urlParams.Key, HttpUtility.UrlEncode(urlParams.Value));
                response.Append(!urlParams.Equals(_urlParametersDictionary.Last()) ? "&" : string.Empty);
            } 
            return response.Length > 1 ? response.ToString(): string.Empty;
        }
    }
}