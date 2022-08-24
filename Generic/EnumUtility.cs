using System;

namespace LanKuDot.UnityToolBox.Generic
{
    public static class EnumUtility
    {
        /// <summary>
        /// Convert the enum value to the int value
        /// </summary>
        /// <param name="value">The enum value</param>
        /// <typeparam name="TEnum">The type of the enum</typeparam>
        /// <returns>The corresponding int value</returns>
        public static int ToInt<TEnum>(TEnum value)
            where TEnum : Enum =>
            int.Parse(Enum.Format(typeof(TEnum), value, "d"));

        /// <summary>
        /// Convert the int value to the enum value
        /// </summary>
        /// <param name="value">The int value</param>
        /// <typeparam name="TEnum">The type of enum to convert to</typeparam>
        /// <returns>The converted enum</returns>
        /// <exception cref="MissingMemberException">
        /// If there has no matched int value in the TEnum
        /// </exception>
        public static TEnum ToEnum<TEnum>(int value)
            where TEnum : Enum
        {
            if (!Enum.TryParse(typeof(TEnum), $"{value}", out var result))
                throw new MissingMemberException(
                    $"Value '{value}' is not defined in the '{typeof(TEnum)}'");

            return (TEnum)result;
        }
    }
}
