using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
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


        public static IList<Dictionary<string, object>> ToListDictionary<T>(this List<T> param)
        {
            IList<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            if (param == null)
                results = null;

            foreach(var item in param)
            {
                results.Add(item.ObjectToDictionary());
            }
            return results;
        }


        public static Dictionary<string,object> ObjectToDictionary<T>(this T param)
        {
            return param.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary(prop => prop.Name, prop => prop.GetValue(param, null));
        }

        public static T DictionaryToObject<T>(this IDictionary<string, object> source)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in source)
            {
                type.GetProperty(kv.Key).SetValue(obj, kv.Value);
            }
            return (T)obj;
        }


    }
}
