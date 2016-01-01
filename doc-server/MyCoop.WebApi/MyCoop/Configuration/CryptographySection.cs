using System.Configuration;

namespace MyCoop.Configuration
{
    public class CryptographySection : ConfigurationSection
    {

        [ConfigurationProperty("key")]
        public string Key
        {
            get { return (string)this["key"]; }
        }

        [ConfigurationProperty("iv")]
        public string IV
        {
            get { return (string)this["iv"]; }
        }

        [ConfigurationProperty("salt")]
        public string Salt
        {
            get { return (string)this["salt"]; }
        }
    }
}