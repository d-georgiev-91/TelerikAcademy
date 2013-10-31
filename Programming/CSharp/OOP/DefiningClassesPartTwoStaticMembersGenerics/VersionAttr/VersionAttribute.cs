namespace VersionAttr
{
    using System;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct |
                    AttributeTargets.Enum |
                    AttributeTargets.Interface |
                    AttributeTargets.Method)]

    public class VersionAttribute : Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }

        public int Major { get; set; }

        public int Minor { get; set; }
    }
}