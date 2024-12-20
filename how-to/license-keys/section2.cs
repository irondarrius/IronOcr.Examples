using IronOcr;
namespace IronOcr.Examples.HowTo.LicenseKeys
{
    public static class Section2
    {
        public static void Run()
        {
            bool result = IronOcr.License.IsValidLicense("IRONOCR-MYLICENSE-KEY-1EF01");
        }
    }
}