using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library {
    public class Serialization<T> {

        private BinaryFormatter formatter = new BinaryFormatter();
        public byte[] Serialize(T t) {
            byte[] buffer = new byte[4096];
            Stream stream = new MemoryStream(buffer);
            formatter.Serialize(stream, t);
            return buffer;
        }

        public T Deserialize(byte[] data) {
            return (T)formatter.Deserialize(new MemoryStream(data));
        }
    }
}