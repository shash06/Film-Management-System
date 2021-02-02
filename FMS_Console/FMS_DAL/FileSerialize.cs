using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using FMS_Entity;
using FMS_Exception;

namespace FMS_DAL
{
    public class FileSerialize
    {
        //static List<Film> filmList = new List<Film>();
        static BinaryFormatter bf = null;
        static FileStream fs = null;


        public static void DoSerialize(List<Film> filmList)
        {
            fs = new FileStream("Film Management System.bin", FileMode.Open, FileAccess.Write);
            bf = new BinaryFormatter();
            bf.Serialize(fs, filmList);
            fs.Close();
        }

        public static List<Film> DoDeserialize()
        {
            fs = new FileStream("Film Management System.bin", FileMode.OpenOrCreate, FileAccess.Read);
            if (fs.Length == 0)
            {
                fs.Close(); 
                return new List<Film>();
            }
            bf = new BinaryFormatter();
            List<Film> newList = (List<Film>)bf.Deserialize(fs);
            fs.Close();
            return newList;
            
        }
    }
}
