using AppG2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Controller
{
    class ContactService
    {
        /// <summary>
        /// Lấy sinh viên theo mã sinh viên từ mockdata
        /// </summary>
        /// <param name="ID">ID contact</param>
        /// <returns>Lấy sinh viên theo mã sinh viên</returns>
        public static List<Contact> GetContact(string pathDataFileContact, string key = null)
        {
            if (key == null) key = "";
            List<Contact> contacts = new List<Contact>();
            if (File.Exists(pathDataFileContact))
            {
                string[] listLinesContact = File.ReadAllLines(pathDataFileContact);
                foreach (var lineContact in listLinesContact)
                {
                    var ls = lineContact.Split(new char[] { '#' });
                    if (ls[1].ToUpper().Contains(key.ToUpper()) || ls[2].ToUpper().Contains(key.ToUpper()) || ls[3].ToUpper().Contains(key.ToUpper()))
                    {
                        Contact cont = new Contact
                        {
                            ID = ls[0],
                            NameContact = ls[1],
                            Phone = ls[2],
                            Email = ls[3]
                        };
                        contacts.Add(cont);

                    }
                }
                return contacts;
            }


            return null;
        }
        public static void DeleteContact(string id, string pathDataFileContact)
        {
            if (File.Exists(pathDataFileContact))
            {
                string[] listContact = File.ReadAllLines(pathDataFileContact); //Lấy file ra , nên dùng var cho an toàn
                File.WriteAllText(pathDataFileContact, ""); // Làm cho file đó trống
                foreach (var lineContact in listContact)
                {
                    var ls = lineContact.Split(new char[] { '#' });
                    var line = "\n";
                    if (lineContact == listContact[listContact.Length - 1] || lineContact == listContact[listContact.Length - 2])
                        line = "";
                    if (ls[0] != id)
                    {
                        
                            File.AppendAllText(pathDataFileContact, lineContact + line); //Append là thêm vào, chèn vào sau chuỗi có trước, thêm vào ở File nào, nội dung là gì
                      
                            
                    }
                   
                }
            }
        }
        public static void CreateContact(string pathDataFileContact, Contact contact)
        {
            if (File.Exists(pathDataFileContact))
            {
                string[] listContact = File.ReadAllLines(pathDataFileContact); //Lấy file ra , nên dùng var cho an toàn

                contact.ID = Guid.NewGuid().ToString();               
                string contentContact = contact.ID + "#" + contact.NameContact + "#" + contact.Phone + "#" + contact.Email;
                File.AppendAllText(pathDataFileContact, "\n" + contentContact); //Append là thêm vào, chèn vào sau chuỗi có trước, thêm vào ở File nào, nội dung là gì                 
            }
        }
        public static void EditContact(string pathDataFileContact, Contact contact)
        {
            if (File.Exists(pathDataFileContact))
            {
                string[] listContact = File.ReadAllLines(pathDataFileContact); //Lấy file ra , nên dùng var cho an toàn
                File.WriteAllText(pathDataFileContact, ""); // Làm cho file đó trống             
                foreach (var lineContact in listContact)
                {
                    var ls = lineContact.Split(new char[] { '#' });
                    var line = "\n";
                    if (lineContact == listContact[listContact.Length - 1])
                        line = "";
                    if (ls[0] != contact.ID)
                    {
                        File.AppendAllText(pathDataFileContact, lineContact + line); //Append là thêm vào, chèn vào sau chuỗi có trước, thêm vào ở File nào, nội dung là gì
                    }
                    else
                    {
                        string contentContact = contact.ID + "#" + contact.NameContact + "#" + contact.Phone + "#" + contact.Email;

                        File.AppendAllText(pathDataFileContact, contentContact + line);
                    }

                }
            }
        }
        public static List<Contact> SearchContact(string pathDataFileContact, string key = null)
        {       
            List<Contact> contacts = new List<Contact>();
            if (File.Exists(pathDataFileContact))
            {
                string[] listLinesContact = File.ReadAllLines(pathDataFileContact);
                foreach (var lineContact in listLinesContact)
                {
                    var ls = lineContact.Split(new char[] { '#' });
                    if (ls[1].Contains(key) || ls[2].Contains(key) || ls[3].Contains(key))
                    {
                        Contact cont = new Contact
                        {
                            ID = ls[0],
                            NameContact = ls[1],
                            Phone = ls[2],
                            Email = ls[3]
                        };
                        contacts.Add(cont);

                    }
                }
                return contacts;
            }
            return null;
        }
    }
}
