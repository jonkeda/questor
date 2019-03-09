using System;

namespace Questor.UI.Icons
{
    /// <summary>
    /// Represents the field is an alias of another icon.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class IconAliasAttribute
        : Attribute
    { }
}