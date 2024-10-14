using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFChat
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IChatService
    {
        [OperationContract]
        ChatUser ClientConnect(string userName);

        [OperationContract]
        List<ChatMessage> GetNewMessages(ChatUser user);

        [OperationContract]
        void SendNewMessage(ChatMessage newMessage);

        [OperationContract]
        List<ChatUser> GetAllUsers();

        [OperationContract]
        void removeUser(ChatUser user);
    }

    [DataContract]
    public class ChatUser
    {
        private string userName;
        private string ipAddress;
        private string hostName;

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [DataMember]
        public string IpAddress 
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        [DataMember]
        public string HostName 
        {
            get { return hostName; }
            set { hostName = value; }
        }
    }

    [DataContract]
    public class ChatMessage
    {
        private ChatUser user;
        private string message;
        private DateTime date;

        [DataMember]
        public ChatUser User
        {
            get { return user; }
            set { user = value; }
        }

        [DataMember]
        public string Message
        { 
            get { return message; }
            set { message = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
