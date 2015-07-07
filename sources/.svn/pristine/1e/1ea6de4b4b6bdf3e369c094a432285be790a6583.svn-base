using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.DirectoryServices;


namespace MPBA.SIAC.Bll
{

    public partial class LoginDomain
    {
        public bool Authenticate(string userName, string password, string domain)
        {
            bool authentic = false;
            try
            {
                //Valida que el usuario pertenezca al dominio

                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, userName, password);
                object nativeObject = entry.NativeObject;
                if (entry != null)
                {
                    authentic = true;
                    
                }


                //Valida que el usuario pertenezca al grupo "Informatica"

                //ArrayList grupos = Groups(getDistinguishedName(userName), true);
                //IEnumerator en = grupos.GetEnumerator();
                //while (en.MoveNext() && !authentic)
                //{
                //    if (en.Current != null)
                //    {
                //        if (en.Current.ToString().Contains("Informatica"))
                //        {
                //            authentic = true;
                //        }
                //    }
                //}

            }
            catch (DirectoryServicesCOMException) { }
            return authentic;
        }

       
        public ArrayList Groups(string userDn, bool recursive)
        {
            ArrayList groupMemberships = new ArrayList();
            return AttributeValuesMultiString("memberOf", "LDAP://" + userDn,
                groupMemberships, recursive);
        }

        public ArrayList AttributeValuesMultiString(string attributeName,
         string objectDn, ArrayList valuesCollection, bool recursive)
        {
            DirectoryEntry ent = new DirectoryEntry(objectDn);
            PropertyValueCollection ValueCollection = ent.Properties[attributeName];
            IEnumerator en = ValueCollection.GetEnumerator();

            while (en.MoveNext())
            {
                if (en.Current != null)
                {
                    if (!valuesCollection.Contains(en.Current.ToString()))
                    {
                        valuesCollection.Add(en.Current.ToString());
                        if (recursive)
                        {
                            AttributeValuesMultiString(attributeName, "LDAP://" +
                            en.Current.ToString(), valuesCollection, true);
                        }
                    }
                }
            }
            ent.Close();
            ent.Dispose();
            return valuesCollection;
        }


        private string getDistinguishedName(string user)
        {
            string fullpath;

            DirectoryEntry objRoot = new DirectoryEntry("LDAP://rootDSE");
            DirectoryEntry objUsers = new DirectoryEntry("LDAP://" + (string)objRoot.Properties["defaultNamingContext"].Value);

            DirectorySearcher Filter1 = new DirectorySearcher(objUsers);
            Filter1.Filter = "(&(objectClass=user)(sAMAccountName=" + user + "))";
            SearchResultCollection FilterResult1 = Filter1.FindAll();

            fullpath = "***";

            foreach (SearchResult iter in FilterResult1)
            {
                fullpath = (string)iter.GetDirectoryEntry().Properties["distinguishedName"].Value;
            }

            return fullpath;
        }

        public string getCommonName(string user)
        {
            string fullpath;

            DirectoryEntry objRoot = new DirectoryEntry("LDAP://rootDSE");
            DirectoryEntry objUsers = new DirectoryEntry("LDAP://" + (string)objRoot.Properties["defaultNamingContext"].Value);

            DirectorySearcher Filter1 = new DirectorySearcher(objUsers);
            Filter1.Filter = "(&(objectClass=user)(sAMAccountName=" + user + "))";
            SearchResultCollection FilterResult1 = Filter1.FindAll();

            fullpath = "***";

            foreach (SearchResult iter in FilterResult1)
            {
                fullpath = (string)iter.GetDirectoryEntry().Properties["CN"].Value;
            }

            return fullpath;
        }
    }

}
