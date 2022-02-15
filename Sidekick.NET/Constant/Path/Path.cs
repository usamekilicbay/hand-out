namespace Sidekick.NET.Constant
{
    public static class Path
    {
        public static string WWWROOT { get; private set; }
        public static string IMAGES { get; private set; }
        public static string PROFILE_IMAGES { get; private set; }
        public static string PRODUCT_IMAGES { get; private set; }

        public static void SetPaths(string wwwRootPath)
        {
            WWWROOT = wwwRootPath;
            IMAGES = $"{WWWROOT}/images";
            PROFILE_IMAGES = $"{IMAGES}/profile-images";
            PRODUCT_IMAGES = $"{IMAGES}/product-images";
        }
    }
}
