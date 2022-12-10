using System.IO;
using System.Net.Http.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SerializeDeserialize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //////////----------------||BinaryFormatter||------------------------------------------------------------
            User user = new User();
            user.Id = 1;
            user.Name = "Zaminali";
            user.Surname = "Rustemov";

            SerializableToBinary(user);

            //User user1 = DeserializableToBinary();
            //Console.WriteLine(user1);


            //////////----------------||XMLFormatter||----------------------------------------------------------------
            User user2 = new User();
            user2.Id = 2;
            user2.Name = "Namiq";
            user2.Surname = "Mikayilov";

            SerializableToXML(user2);

            //User user3 = DeserializableToXMl();
            //Console.WriteLine(user3);


            //////////----------------||JSONFormatter||----------------------------------------------------------------
            User user4 = new();
            user4.Id = 3;
            user4.Name = "Ali";
            user4.Surname = "Ibrahimov";

            SerializableToJson(user4);

            //User user6 = DeserializableToJson();
            //Console.WriteLine(user6);


        }


        //////////----------------||BinaryFormatter||------------------------------------------------------------
        public static void SerializableToBinary(User user)
        {
            string path = "C:\\Users\\HP\\Desktop\\User.dat";
            Stream stream = new FileStream(path, FileMode.Create);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, user);
        }
        public static User DeserializableToBinary()
        {
            string path = "C:\\Users\\HP\\Desktop\\User.dat";
            Stream stream = new FileStream(path, FileMode.Open);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (User)binaryFormatter.Deserialize(stream);
        }


        //////////----------------||XMLFormatter||----------------------------------------------------------------
        public static void SerializableToXML(User user)
        {
            string path = "C:\\Users\\HP\\Desktop\\User2.xml";
            Stream stream = new FileStream(path, FileMode.Create);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
            xmlSerializer.Serialize(stream, user);
        }

        public static User DeserializableToXMl()
        {
            string path = "C:\\Users\\HP\\Desktop\\User2.xml";
            Stream stream = new FileStream(path, FileMode.Open);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
            return (User)xmlSerializer.Deserialize(stream);
        }


        //////////----------------||JSONFormatter||----------------------------------------------------------------
        public static void SerializableToJson(User user)
        {
            string path = "C:\\Users\\HP\\Desktop\\User.json";

            string json = JsonSerializer.Serialize(user);
            File.WriteAllText(path, json);
        }
        public static User DeserializableToJson()
        {
            string path = "C:\\Users\\HP\\Desktop\\User.json";
            Stream stream = new FileStream(path, FileMode.Open);

            User user=JsonSerializer.Deserialize<User>(stream);
            return user;
        }
    }
}