using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes
{
    public static class JsonHelper
    {
        /// <summary>
        /// Create an object from its JSON representation.
        /// </summary>
        /// <typeparam name="T">The type of object represented by the Json.</typeparam>
        /// <param name="json">json text to transform a object</param>
        /// <returns>array with objects</returns>
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        /// <summary>
        /// Generate a JSON representation of the fields of an object
        /// </summary>
        /// <typeparam name="T">>The type of object</typeparam>
        /// <param name="array">array with objects</param>
        /// <returns>string in json format with data</returns>
        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }


        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }

    }
}
