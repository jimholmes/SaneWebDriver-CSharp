using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.Support

{
    public static class Settings
    {
        /*
         * These settings should *NOT* be hard-coded in a real test suite.
         * Instead, they should read from envrionment variables,
         * a customized text file, or whatever other mechanism you might 
         * use in your build system.
         * 
         * For example, Jenkins builds might set environment properties to read.
         * Travis CI might drop an environment-specific text file. VSTS might
         * read from an App.config file. Etc.
         * 
         * This is merely showing one place to abstract all settings so
         * your tests don't know about them.
         */
        public static string SITE_URL = "http://jhdemos.azurewebsites.net/";
        public static string CONTACT_URI = "http://jhdemos.azurewebsites.net/api/contact";
    }
}
