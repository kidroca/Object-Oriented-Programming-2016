namespace Telerik.Homeworks.OOP.Principles.Validator
{
    using System;

    public static class Validator
    {
        private const int MinNameLength = 3;

        private const int MaxNameLength = 20;

        public static string ValidateName(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "A person name cannot be null");
            }

            value = value.Trim();

            if (value.Length < MinNameLength)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The given name is too short");
            }

            if (value.Length > MaxNameLength)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The given name is too long");
            }

            return value;
        }
    }
}
