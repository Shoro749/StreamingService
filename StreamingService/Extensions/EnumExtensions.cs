using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace StreamingService.Extensions 
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes.Length > 0)
                {
                    return ((DisplayAttribute)attributes[0]).Name;
                }
            }

            return enumValue.ToString();
        }

        public static string GetShortName(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes.Length > 0)
                {
                    var displayAttr = (DisplayAttribute)attributes[0];

                    return !string.IsNullOrEmpty(displayAttr.ShortName)
                        ? displayAttr.ShortName
                        : displayAttr.Name;
                }
            }

            return enumValue.ToString();
        }

        public static string GetSingularName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()?
                            .GetDescription() ?? enumValue.ToString(); 
        }
    }
}