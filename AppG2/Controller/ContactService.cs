﻿using AppG2.Model;
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
        public static List<Contact> GetContactDB(User user, string key = null)
        {
            var db = new AppG2Context();
           
            if (key == null) key = "";
            return db.ContactDbset.Where(e => (e.UserName == user.UserName) && ((e.NameContact.Contains(key)) || (e.Email.Contains(key)) || (e.Phone.Contains(key)))).OrderBy(e => e.NameContact).ToList();
            
           
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
        public static void DeleteContactDB(string id)
        {
            var db = new AppG2Context();
            var contact = db.ContactDbset.Where(e => e.ID == id).FirstOrDefault();
            if (contact != null)
                db.ContactDbset.Remove(contact);
            db.SaveChanges();
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
        public static Boolean CreateContactDB( Contact contact)
        {
            var db = new AppG2Context();
            contact.ID = Guid.NewGuid().ToString();
            if (!ExistPhoneOrEmail(contact.Phone, contact.Email, contact.UserName, contact.ID))
            {
                db.ContactDbset.Add(contact);
                db.SaveChanges();
                return true;
            }
            return false;
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
        public static Boolean EditContactDB(Contact contact)
        {
            var db = new AppG2Context();
            var cnt = db.ContactDbset.Where(e => (e.ID == contact.ID) ).FirstOrDefault();
            cnt.NameContact = contact.NameContact;
            cnt.Email = contact.Email;
            cnt.Phone = contact.Phone;
            if(!ExistPhoneOrEmail(cnt.Phone, cnt.Email, cnt.UserName, cnt.ID))
            {
                db.SaveChanges();
                return true;
            }
              
            return false;
        }
        public static List<Contact> GetContactDBFromCharacter(string character)
        {
            var db = new AppG2Context();
            var lst = db.ContactDbset.Where(e => (string.Compare(e.NameContact, character) >= 0)).OrderBy(e => e.NameContact).ToList();
            return lst;
        }
        public static Boolean CheckLogin(User user)
        {
            var db = new AppG2Context();
            var us = db.UserDbset.Where(e => (e.UserName == user.UserName) && (e.PassWord == user.PassWord)).FirstOrDefault();
            if (us != null)
                return true;
            return false;
        }
        public static Boolean ExistPhoneOrEmail(string phone,string email, string username, string idcontact)
        {
            var db = new AppG2Context();
            var ct = db.ContactDbset.Where(e => (e.ID != idcontact) && (((e.Phone == phone) || (e.Email == email)) && e.UserName == username)).FirstOrDefault();
            if (ct != null)
                return true;
            return false;
        }
    }
}
