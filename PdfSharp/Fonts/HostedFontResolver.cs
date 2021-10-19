using System;
using System.Reflection;

namespace PdfSharp.Fonts
{
    public class HostedFontResolver : IFontResolver
    {
        public const string ArialUnicodeMs = "Arial Unicode MS";

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            var name = familyName.ToLower();

            return name switch
            {
                "arial unicode ms" => new FontResolverInfo("ArialUnicodeMs"),
                _ => PlatformFontResolver.ResolveTypeface("Arial", isBold, isItalic)
            };
        }

        public byte[] GetFont(string faceName)
        {
            return faceName switch
            {
                "ArialUnicodeMs" => HostedFontLoader.ArialUnicodeMs,
                _ => null
            };
        }
    }
    
    public static class HostedFontLoader
    {
        public static byte[] ArialUnicodeMs => LoadFontData($"{nameof(PdfSharp)}.{nameof(Fonts)}.ArialUnicodeMs.ttf");

        private static byte[] LoadFontData(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(name);

            if (stream == null)
            {
                throw new ArgumentException("No resource with name " + name);
            }

            var count = (int)stream.Length;
            var data = new byte[count];
            stream.Read(data, 0, count);
            return data;
        }
    }
}
