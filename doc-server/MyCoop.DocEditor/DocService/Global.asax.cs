using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Routing;
using FileConverterUtils2;
using log4net.Config;

namespace DocService
{
    public class global_asax : System.Web.HttpApplication
    {
        const int c_nBuildTimeYear = 2014;
        const int c_nBuildTimeMonth = 02;
        const int c_nBuildTimeDay = 04;

        public class LanguageInfo
        {
            public string languageCode;
            public string languageName;
            public string hunspellAffFile;
            public string hunspellDictFile;
            public string hunspellKey;
            public string hyphenDictFile;
            public string thesIdxFile;
            public string thesDatFile;
        };

        static public Object lockThis = new Object();

        static public Dictionary<int, LanguageInfo> dictMap;

        static LicenseInfo licenseInfo;
        static public LicenseInfo LicenseInfo { get { return licenseInfo; } }

        private void InitLangInfo()
        {

            LanguageInfo info_de_DE = new LanguageInfo();
            info_de_DE.languageCode = "de-DE";
            info_de_DE.languageName = "German, Germany";
            info_de_DE.hunspellAffFile = "de_DE_frami.aff";
            info_de_DE.hunspellDictFile = "de_DE_frami.dic";
            info_de_DE.hunspellKey = "";
            info_de_DE.hyphenDictFile = "hyph_de_DE.dic";

            dictMap.Add(0x0407, info_de_DE);

            LanguageInfo info_en_US = new LanguageInfo();
            info_en_US.languageCode = "en-US";
            info_en_US.languageName = "English, United States";
            info_en_US.hunspellAffFile = "en_us.aff";
            info_en_US.hunspellDictFile = "en_us.dic";
            info_en_US.hunspellKey = "";
            info_en_US.hyphenDictFile = "hyph_en_us.dic";
            info_en_US.thesIdxFile = "th_en_us_new.idx";
            info_en_US.thesDatFile = "th_en_us_new.dat";

            dictMap.Add(0x0409, info_en_US);

            LanguageInfo info_ru_RU = new LanguageInfo();
            info_ru_RU.languageCode = "ru-RU";
            info_ru_RU.languageName = "Russian, Russian Federation";
            info_ru_RU.hunspellAffFile = "ru_RU.aff";
            info_ru_RU.hunspellDictFile = "ru_RU.dic";
            info_ru_RU.hunspellKey = "";

            dictMap.Add(0x0419, info_ru_RU);

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            string sRoute = ConfigurationSettings.AppSettings["fonts.route"] ?? "fonts/";
            routes.Add(new Route(sRoute + "native/{fontname}", new FontServiceRoute()));
            routes.Add(new Route(sRoute + "js/{fontname}", new FontServiceRoute()));
        }

        void Application_Start(object sender, EventArgs e)
        {

            System.Diagnostics.Debug.Print("Application_Start() fired!" + sender.ToString());

            try
            {
                XmlConfigurator.Configure();
            }
            catch (Exception ex)
            {
            }

            RegisterRoutes(RouteTable.Routes);

            licenseInfo = LicenseInfo.CreateLicenseInfo(new DateTime(c_nBuildTimeYear, c_nBuildTimeMonth, c_nBuildTimeDay));

        }

        void Application_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Application_End() fired!" + sender.ToString());
        }

        void Application_Error(object sender, EventArgs e)
        {

        }

        void Session_Start(object sender, EventArgs e)
        {

        }

        void Session_End(object sender, EventArgs e)
        {

        }

        void Application_BeginRequest(Object sender, EventArgs e)
        {

        }
    }
}