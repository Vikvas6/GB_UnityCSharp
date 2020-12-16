using System.IO;
using UnityEngine;


namespace GeekbrainsUnityCSharp
{

    public class JSONSaver<T> : IMyData<T>
    {
        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, DataCrypto.XOR(str));
        }

        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(DataCrypto.XOR(str));
        }
    }
}