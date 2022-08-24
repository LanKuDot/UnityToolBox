#if NEWTON_SOFT_JSON

using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace LanKuDot.UnityToolBox.Generic
{
    /// <summary>
    /// The utility class for the Newtonsoft.Json
    /// </summary>
    public static class JsonUtility
    {
        /// <summary>
        /// Copy the properties of JsonProperty from one object to another
        /// </summary>
        /// <param name="fromObj">The source object</param>
        /// <param name="toObj">The target object</param>
        /// <typeparam name="T">The type of the object</typeparam>
        public static void CopyJsonProperties<T>(T fromObj, T toObj)
        {
            var jsonProperties =
                typeof(T).GetProperties().Where(HasJsonProperty);
            foreach (var property in jsonProperties) {
                var fromValue = property.GetValue(fromObj);
                property.SetValue(toObj, fromValue);
            }
        }

        /// <summary>
        /// Is the specified property has the JsonProperty attribute?
        /// </summary>
        private static bool HasJsonProperty(PropertyInfo info)
        {
            return info.GetCustomAttributes<JsonPropertyAttribute>().Any();
        }
    }
}

#endif
