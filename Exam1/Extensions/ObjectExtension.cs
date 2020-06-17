using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Extensions
{
    public static class ObjectExtension
    {
        public static ExpandoObject ToExpando(this object anonymousObject)
        {
            IDictionary<string, object> anonymousDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousObject);
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var item in anonymousDictionary)
                expando.Add(item);
            return (ExpandoObject)expando;
        }

        public static Dictionary<string,object> JsonObjectToDictionary(this object anomymousObject)
        {
            JObject jsonObject = JObject.Parse(anomymousObject.ToString());
            IEnumerable<JToken> jTokens = jsonObject.Descendants().Where(p => p.Count() == 0);
            Dictionary<string, object> results = jTokens.Aggregate(new Dictionary<string, object>(), (properties, jToken) =>
            {
                properties.Add(jToken.Path, jToken.ToString());
                return properties;
            });
            return results;
        }

        public static T ToObject<T>(this IDictionary<string, object> source)
        where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType
                         .GetProperty(item.Key)
                         .SetValue(someObject, item.Value, null);
            }

            return someObject;
        }

    }
}
