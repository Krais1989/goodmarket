using System;
using System.Collections.Generic;

namespace GoodMarket.Application.Utils
{
    public static class EntityDefaultFactory
    {
        private static Dictionary<Type, object> Cache = new Dictionary<Type, object>();
        
        /// <summary>
        /// Создаёт дефолтный объект с учётом иерархии из дочерних объектов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetDefault<T>()
            where T:class, new()
        {
            var type = typeof(T);
            T result = null;
            if (Cache.ContainsKey(type))
                result = (T)Cache[type];
            else
            {
                result = new T();
                //result = (T)Activator.CreateInstance(typeof(T));
                //result = (T)PopulateDefault(Activator.CreateInstance(typeof(T)));
                Cache.Add(type, result);
            }

            return result;
        }

        private static object PopulateDefault(object obj)
        {
            Type objType = obj.GetType();

            foreach(var prop in objType.GetProperties())
            {
                var propType = prop.PropertyType;

                if (propType == typeof(string))
                {
                    prop.SetValue(obj, "");
                }
                else if (!propType.IsValueType )
                {
                    prop.SetValue(obj, PopulateDefault(Activator.CreateInstance(propType)));
                }
            }
            return obj;
        }
    }
}
