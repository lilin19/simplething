using System;

namespace Library {
    [Serializable]
    public class Message {
        public String content = null;
        public String username = null;
        public String date = null;

        public Message(String content, String username, String date) {
            this.content = content;
            this.username = username;
            this.date = date;
        }
    }
}