using System.IO;
using System.Reflection;

namespace Atria.Localization
{
    internal static class Helper
    {
        public static string GetLocalizationJsonContent()
        {
            var assembly = Assembly.GetEntryAssembly();

            string result = string.Empty;
            using (Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.localization.json"))
            {
                using StreamReader reader = new(stream);
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}