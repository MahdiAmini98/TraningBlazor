using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TraningBlazorProject.Client.Common.Class_Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var member = enumType.GetMember(enumValue.ToString());
            var displayAttribute = member[0].GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? enumValue.ToString();
        }
    }
}
