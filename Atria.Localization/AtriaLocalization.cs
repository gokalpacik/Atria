using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Atria.Localization
{
    public class AtriaLocalization
    {
        readonly List<LocalizationItem> _localizationItems = null;

        public AtriaLocalization()
        {
            string content = Helper.GetLocalizationJsonContent();
            _localizationItems = JsonSerializer.Deserialize<List<LocalizationItem>>(content);

            #region Duplicate Key Control

            var duplicatedLocalizationKeys = _localizationItems.GroupBy(x => x.Key)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            if (duplicatedLocalizationKeys.Any())
            {
                Console.WriteLine("Duplicated Localization Keys");
                Console.WriteLine("************************ \n");

                foreach (var duplicatedLocalizatinKey in duplicatedLocalizationKeys)
                {
                    Console.WriteLine(duplicatedLocalizatinKey);
                    throw new Exception("Duplicated Localization Keys");
                }

                Console.WriteLine("********************* \n");
            }

            #endregion
        }


        public string Get(string key, string languageCode)
        {
            string value = string.Empty;
            _localizationItems.Where(x => x.Key == key).SingleOrDefault()?.Values.TryGetValue(languageCode, out value);

            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value;
        }
    }
}