using System;
using UnityEngine;

namespace LanKuDot.UnityToolBox.Generic
{
    /// <summary>
    /// The item of the game option
    /// </summary>
    /// <typeparam name="T">The type of the data</typeparam>
    public abstract class GameOptionItem<T>
    {
        /// <summary>
        /// The key of the option in the stored data
        /// </summary>
        public readonly string Key;
        /// <summary>
        /// The value of the option
        /// </summary>
        public T Value { get; protected set; }

        public GameOptionItem(string key, T defaultValue)
        {
            Key = key;
            Value = defaultValue;
        }

        /// <summary>
        /// Load the option stored in the target PlayerPrefs
        /// </summary>
        public abstract void Load();
        /// <summary>
        /// Set the value to the target PlayerPrefs
        /// </summary>
        /// Note that it has to invoke PlayerPrefs.Save() to apply the value.
        public abstract void Set(T value);

        public override string ToString() => $"{Key} - {Value}";
    }

    /// <summary>
    /// The game option of a boolean value
    /// </summary>
    public class BoolGameOption : GameOptionItem<bool>
    {
        public BoolGameOption(string key, bool defaultValue) :
            base(key, defaultValue)
        {}

        public override void Load()
        {
            var intValue = PlayerPrefs.GetInt(Key, ToInt(Value));
            Value = ToBool(intValue);
        }

        public override void Set(bool value)
        {
            Value = value;
            PlayerPrefs.SetInt(Key, ToInt(value));
        }

        private static bool ToBool(int value) =>
            value == 1;

        private static int ToInt(bool value) =>
            value ? 1 : 0;
    }

    /// <summary>
    /// The game option of a integer value
    /// </summary>
    public class IntGameOption : GameOptionItem<int>
    {
        public IntGameOption(string key, int defaultValue) :
            base(key, defaultValue)
        {}

        public override void Load() =>
            Value = PlayerPrefs.GetInt(Key, Value);

        public override void Set(int value)
        {
            Value = value;
            PlayerPrefs.SetInt(Key, Value);
        }
    }

    /// <summary>
    /// The game option of an enum value
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum</typeparam>
    public class EnumGameOption<TEnum> : GameOptionItem<TEnum>
        where TEnum : Enum
    {
        public EnumGameOption(string key, TEnum defaultValue) :
            base(key, defaultValue)
        {}

        public override void Load()
        {
            var intValue = PlayerPrefs.GetInt(Key, EnumUtility.ToInt(Value));
            Value = EnumUtility.ToEnum<TEnum>(intValue);
        }

        public override void Set(TEnum value)
        {
            Value = value;
            PlayerPrefs.SetInt(Key, EnumUtility.ToInt(Value));
        }
    }
}
