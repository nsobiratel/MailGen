namespace MailGen.Classes
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using fastJSON;
    using Microsoft.Exchange.WebServices.Data;

    public sealed class StoredContact
    {
        private const string StoredFolder = "Contacts";
        private const string FileExt = ".json";

        static StoredContact()
        {
            if (Directory.Exists(StoredFolder))
                return;
            Directory.CreateDirectory(StoredFolder);
        }

        public StoredContact()
        {

        }

        public StoredContact(Contact obj)
        {
            this.UniqId = obj.Id.UniqueId;
            this.Email = obj.EmailAddresses[EmailAddressKey.EmailAddress1].Address;
            this.CanBeSender = true;
            this.CanBeRecipient = true;
        }

        public string Email { get; set; }

        public string UniqId
        { get; set; }

        public bool CanBeSender
        { get; set; }

        public bool CanBeRecipient
        { get; set; }

        public string FileName { get; private set; }

        public bool IsEwsContact
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.UniqId);
            }
        }

        public void Save()
        {
            string fileName = Path.Combine(
                StoredFolder, this.IsEwsContact ? this.UniqId + FileExt : this.Email + FileExt);
            string obj = JSON.ToJSON(this);
            File.WriteAllText(fileName, obj, Encoding.UTF8);
        }

        public static List<StoredContact> GetAll()
        {
            List<StoredContact> list = new List<StoredContact>();
            foreach (string p in 
                Directory.GetFiles(StoredFolder, "*" + FileExt, SearchOption.AllDirectories))
            {
                StoredContact cont = JSON.ToObject<StoredContact>(File.ReadAllText(p, Encoding.UTF8));
                cont.FileName = p;
                list.Add(cont);
            }
            return list;
        }

        public void Delete()
        {
            File.Delete(this.FileName);
        }
    }
}
