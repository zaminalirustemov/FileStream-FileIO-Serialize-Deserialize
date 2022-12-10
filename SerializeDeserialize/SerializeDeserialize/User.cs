using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDeserialize
{
    [Serializable]
    public class User : ISerializable
    {
        public User(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Name = (string)info.GetValue("Name",typeof(string));
            Surname = (string)info.GetValue("Surname",typeof(string));
        }

        public User()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id",Id,typeof(int));
            info.AddValue("Name", Name, typeof(string));
            info.AddValue("Surname", Surname, typeof(string));
        }
        public override string ToString()
        {
            return $" ID: {Id}\n Name: {Name}\n Surname: {Surname}";
        }
    }
}
