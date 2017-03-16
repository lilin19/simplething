using System;

namespace Library {
    [Serializable]
    public class Request {
        public enum Type {
            Upload = 0,
            Download = 1,
        }

        public Type type;
        public Message message = null;

        public Request(Type type, Message message) {
            this.type = type;
            this.message = message;
        }
    }
}