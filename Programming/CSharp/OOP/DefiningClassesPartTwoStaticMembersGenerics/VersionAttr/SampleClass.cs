namespace VersionAttr
{
    using System;
    using System.Linq;

    [Version(2, 11)]
    public class SampleClass
    {
        public void ShowVersion()
        {
            var versionString = "Class: SampleClass\n" + GetAttribute(typeof(SampleClass));
            Console.WriteLine(versionString);
        }

        public static string GetAttribute(Type type)
        {
            VersionAttribute versionAttribute =
                (VersionAttribute)Attribute.GetCustomAttribute(type, typeof(VersionAttribute));
            
            if (versionAttribute == null)
            {
                return null;
            }
            else
            {
                return string.Format("Version: {0}.{1}", versionAttribute.Major, versionAttribute.Minor);
            }
        }
    }
}