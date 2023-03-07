using System.Collections.Generic;

namespace Atria.Localization
{
    public class LocalizationItem
    {
        public LocalizationItem()
        {
            Values = new Dictionary<string, string>();
        }

        public string Key { get; set; }
        public Dictionary<string, string> Values { get; set; }
    }
}
