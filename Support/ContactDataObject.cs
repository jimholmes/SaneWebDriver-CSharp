using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.Support
{
    /*
     * Data model for the contact grid.
     * See also https://github.com/jimholmes/Demo-Site/blob/master/WebApi/Models/Contact.cs
     * 
     * Note: Normally I would never name something "<x>DataObject" as it just adds noise.
     *    ...But for this example project it makes readability a bit clearer.
     */
    public class ContactDataObject
    {
        private int _id;
        private string _fname;
        private string _lname;
        private string _company;
        private string _region;

        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string Region
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }

        public string Company
        {
            get
            {
                return this._company;
            }
            set
            {
                this._company = value;
            }
        }

        public string LName
        {
            get
            {
                return this._lname;
            }
            set
            {
                this._lname = value;
            }
        }

        public string FName
        {
            get
            {
                return this._fname;
            }
            set
            {
                this._fname = value;
            }
        }
    }
}
