using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetTest.Utilities.Extension
{
    public static class ObjectExtension
    {
        public static object RemoveNullKey(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
