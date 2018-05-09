using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.Support
{
    /* This is an example of a class that helps with test generation and API calls.
     * 
     * Please note the actual calls to web services and database are FAKED OUT.
     * Implementation of these calls requires a lot of additional goo that would
     * complicate these examples due to lots of dependencies.
     * 
     * For a working, practical example of API support please see my "Demo-Site"
     * project on GitHub, specifically: 
     * https://github.com/jimholmes/Demo-Site/blob/master/SupportApi/DataHelpers.cs
     * 
     * That file in turn uses the Models of the enclosing Demo-Site project.
     * 
     */
    public class DataHelpers
    {
        public const int MADE_UP_ID = 255;
        public static ContactDataObject Generate_random_contact() {
            ContactDataObject contact = new ContactDataObject();
            contact.Company = Faker.Company.BS();
            contact.FName = Faker.Name.First();
            contact.LName = Faker.Name.Last();
            contact.Region = Faker.Address.Country();
            contact.Id = MADE_UP_ID;

            return contact;
        }

        /*
         * This method is a stub. It STORES NOTHING IN A DATABASE!
         * It simply returns a Contact object with a fake ID.
         * 
         * This is just meant to show you how a helper/support library
         * might work.
         * 
         * Did I mention this doesn't save to a database???
         */
        public static ContactDataObject Store_random_contact_in_db()
        {
            return Generate_random_contact();
        }
        
        /*
         * This method is a stub. It RETRIVES NOTHING FROM A DATABASE!
         * It simply returns a Contact object with a fake ID.
         * 
         * This is just meant to show you how a helper/support library
         * might work.
         * 
         * Did I mention this doesn't get anything from a database???
         */
        public static ContactDataObject Return_contact_by_id(int id)
        {
            return Generate_random_contact();
        }

        /*
         * This method is a stub. It DELETES NOTHING FROM A DATABASE!
         * It simply returns true to simulate having deleted actual data.
         * 
         * This is just meant to show you how a helper/support library
         * might work.
         * 
         * Did I mention this doesn't delete anything from a database???
         */
        public static bool Delete_contact_by_id(int id)
        {
            return true;
        }
    }

}
