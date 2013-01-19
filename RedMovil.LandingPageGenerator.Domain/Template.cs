using System;
using System.Collections.Generic;
using System.IO;

namespace RedMovil.LandingPageGenerator.Domain
{
    public static class Template
    {
        public static bool ProcessTemplate(List<string> keyWordList, string templatePath)
        {
            if (!File.Exists(templatePath))
            {
                throw new Exception("File doens't exists");
            }

            if (keyWordList.Count == 0)
            {
                throw new Exception("You need to provide the key words for generate the landing pages!");
            }

            using (StreamReader streamReader = new StreamReader(templatePath))
            {
                string template = streamReader.ReadToEnd();

                for (int i = 0; i < keyWordList.Count; i++)
                {
                    if (template.IndexOf("{0}") > -1)
                    {
                        string templateModified = template.Replace("{0}", keyWordList[i]);
                        string landinPagePath = string.Format(@"c:\salida\landing_page_{0}.html", i);

                        using (StreamWriter streamWriter = new StreamWriter(landinPagePath))
                        {
                            streamWriter.Write(templateModified);
                            streamWriter.Close();
                        }
                    }
                }
            }

            return true;
        }
    }
}