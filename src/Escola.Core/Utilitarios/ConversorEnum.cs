using System.ComponentModel;

namespace Escola.Core.Utilitarios
{
    public static class ConversorEnum
    {
        public static string ObterDescricaoEnum<T>(this T source)
        {
            var fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}
