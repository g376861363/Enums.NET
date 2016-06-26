﻿#region License
// Copyright (c) 2016 Tyler Brinkley
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace EnumsNET.Unsafe
{
    /// <summary>
    /// Identical to <see cref="FlagEnums"/> but is not type safe which is useful when dealing with generics and instead throws an <see cref="ArgumentException"/> if TEnum is not an enum/>
    /// </summary>
    public static class UnsafeFlagEnums
    {
        #region "Properties"
        /// <summary>
        /// Indicates if <typeparamref name="TEnum"/> is marked with the <see cref="FlagsAttribute"/>.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>Indication if <typeparamref name="TEnum"/> is marked with the <see cref="FlagsAttribute"/>.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static bool IsFlagEnum<TEnum>()
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.IsFlagEnum;
        }

        /// <summary>
        /// Retrieves all the flags defined by <typeparamref name="TEnum"/>.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>All the flags defined by <typeparamref name="TEnum"/>.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum GetAllFlags<TEnum>()
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.AllFlags;
        }
        #endregion

        #region Main Methods
        /// <summary>
        /// Indicates whether <paramref name="value"/> is a valid flag combination of the defined enum values.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns>Indication of whether <paramref name="value"/> is a valid flag combination of the defined enum values.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static bool IsValidFlagCombination<TEnum>(TEnum value)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.IsValidFlagCombination(value);
        }

        /// <summary>
        /// Returns the names of <paramref name="value"/>'s flags delimited with commas or if empty returns the name of the zero flag if defined otherwise "0".
        /// If <paramref name="value"/> is not a valid flag combination null is returned.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns>The names of <paramref name="value"/>'s flags delimited with commas or if empty returns the name of the zero flag if defined otherwise "0".
        /// If <paramref name="value"/> is not a valid flag combination null is returned.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static string FormatAsFlags<TEnum>(TEnum value) => FormatAsFlags(value, null, null);

        /// <summary>
        /// Returns <paramref name="value"/>'s flags formatted with <paramref name="formatOrder"/> and delimited with commas
        /// or if empty return the zero flag formatted with <paramref name="formatOrder"/>.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="formatOrder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static string FormatAsFlags<TEnum>(TEnum value, params EnumFormat[] formatOrder) => FormatAsFlags(value, null, formatOrder);

        /// <summary>
        /// Returns the names of <paramref name="value"/>'s flags delimited with <paramref name="delimiter"/> or if empty returns the name of the zero flag if defined otherwise "0".
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="delimiter">The delimiter to use to separate individual flag names. Cannot be null or empty.</param>
        /// <returns>The names of <paramref name="value"/>'s flags delimited with <paramref name="delimiter"/> or if empty returns the name of the zero flag if defined otherwise "0".
        /// If <paramref name="value"/> is not a valid flag combination null is returned.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static string FormatAsFlags<TEnum>(TEnum value, string delimiter) => FormatAsFlags(value, delimiter, null);

        /// <summary>
        /// Returns <paramref name="value"/>'s flags formatted with <paramref name="formatOrder"/> and delimited with <paramref name="delimiter"/>
        /// or if empty return the zero flag formatted with <paramref name="formatOrder"/>.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="delimiter"></param>
        /// <param name="formatOrder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static string FormatAsFlags<TEnum>(TEnum value, string delimiter, params EnumFormat[] formatOrder)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.FormatAsFlags(value, delimiter, formatOrder);
        }

        /// <summary>
        /// Returns an array of the flags that compose <paramref name="value"/>.
        /// If <paramref name="value"/> is not a valid flag combination null is returned.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns>Array of the flags that compose <paramref name="value"/>.
        /// If <paramref name="value"/> is not a valid flag combination null is returned.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static IEnumerable<TEnum> GetFlags<TEnum>(TEnum value)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.GetFlags(value);
        }

        /// <summary>
        /// Indicates if <paramref name="value"/> has any flags set.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns>Indication if <paramref name="value"/> has any flags set.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static bool HasAnyFlags<TEnum>(TEnum value)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.HasAnyFlags(value);
        }

        /// <summary>
        /// Indicates if <paramref name="value"/> has any flags set that are also set in <paramref name="flagMask"/>.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="flagMask"></param>
        /// <returns>Indication if <paramref name="value"/> has any flags set that are also set in <paramref name="flagMask"/>.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static bool HasAnyFlags<TEnum>(TEnum value, TEnum flagMask)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.HasAnyFlags(value, flagMask);
        }

        /// <summary>
        /// Indicates if <paramref name="value"/> has all flags set that are defined in <typeparamref name="TEnum"/>.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns>Indication if <paramref name="value"/> has all flags set that are defined in <typeparamref name="TEnum"/>.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static bool HasAllFlags<TEnum>(TEnum value)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.HasAllFlags(value);
        }

        /// <summary>
        /// Indicates if <paramref name="value"/> has all of the flags set that are also set in <paramref name="flagMask"/>.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="flagMask"></param>
        /// <returns>Indication if <paramref name="value"/> has all of the flags set that are also set in <paramref name="flagMask"/>.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static bool HasAllFlags<TEnum>(TEnum value, TEnum flagMask)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.HasAllFlags(value, flagMask);
        }

        /// <summary>
        /// Returns <paramref name="value"/> with all of it's flags toggled. Equivalent to the bitwise "xor" operator with <see cref="GetAllFlags{TEnum}()"/>.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns><paramref name="value"/> with all of it's flags toggled.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum ToggleFlags<TEnum>(TEnum value)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.ToggleFlags(value);
        }

        /// <summary>
        /// Returns <paramref name="value"/> with all of it's flags toggled. If <paramref name="toggleValidFlagsOnly"/> is <c>true</c> then equivalent to the bitwise "xor" operator with <see cref="GetAllFlags{TEnum}()"/>
        /// else is equivalent to the bitwise "not" operator.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="toggleValidFlagsOnly"></param>
        /// <returns><paramref name="value"/> with all of it's flags toggled.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum ToggleFlags<TEnum>(TEnum value, bool toggleValidFlagsOnly)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.ToggleFlags(value, toggleValidFlagsOnly);
        }

        /// <summary>
        /// Returns <paramref name="value"/> while toggling the flags that are set in <paramref name="flagMask"/>. Equivalent to the bitwise "xor" operator.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="flagMask"></param>
        /// <returns><paramref name="value"/> while toggling the flags that are set in <paramref name="flagMask"/>.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum ToggleFlags<TEnum>(TEnum value, TEnum flagMask)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.ToggleFlags(value, flagMask);
        }

        /// <summary>
        /// Returns <paramref name="value"/> with only the flags that are also set in <paramref name="flagMask"/>. Equivalent to the bitwise "and" operation.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="flagMask"></param>
        /// <returns><paramref name="value"/> with only the flags that are also set in <paramref name="flagMask"/>.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum CommonFlags<TEnum>(TEnum value, TEnum flagMask)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.CommonFlags(value, flagMask);
        }

        /// <summary>
        /// Returns <paramref name="flag0"/> with the flags specified in <paramref name="flag1"/> set. Equivalent to the bitwise "or" operation.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="flag0"></param>
        /// <param name="flag1"></param>
        /// <returns><paramref name="flag0"/> with the flags specified in <paramref name="flag1"/> set.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum CombineFlags<TEnum>(TEnum flag0, TEnum flag1)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.CombineFlags(flag0, flag1);
        }

        /// <summary>
        /// Returns all of <paramref name="flags"/> combined with the bitwise "or" operation.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="flags">Must be valid flag combinations.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum CombineFlags<TEnum>(params TEnum[] flags)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.CombineFlags(flags);
        }

        /// <summary>
        /// Returns <paramref name="value"/> with the flags specified in <paramref name="flagMask"/> cleared.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="flagMask"></param>
        /// <returns><paramref name="value"/> with the flags specified in <paramref name="flagMask"/> cleared.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum ExcludeFlags<TEnum>(TEnum value, TEnum flagMask)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.ExcludeFlags(value, flagMask);
        }
        #endregion

        #region Parsing
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants
        /// to an equivalent enumerated object.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
        /// -or-
        /// <paramref name="value"/> is either an empty string or only contains white space
        /// -or-
        /// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/>.</exception>
        [Pure]
        public static TEnum Parse<TEnum>(string value) => Parse<TEnum>(value, false, null, null);

        [Pure]
        public static TEnum Parse<TEnum>(string value, params EnumFormat[] parseFormatOrder) => Parse<TEnum>(value, false, null, parseFormatOrder);

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants
        /// to an equivalent enumerated object. A parameter specifies whether the operation is case-insensitive.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
        /// -or-
        /// <paramref name="value"/> is either an empty string or only contains white space
        /// -or-
        /// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/>.</exception>
        [Pure]
        public static TEnum Parse<TEnum>(string value, bool ignoreCase) => Parse<TEnum>(value, ignoreCase, null, null);

        [Pure]
        public static TEnum Parse<TEnum>(string value, bool ignoreCase, params EnumFormat[] parseFormatOrder) => Parse<TEnum>(value, ignoreCase, null, parseFormatOrder);

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants
        /// delimited with the specified delimiter to an equivalent enumerated object.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="delimiter">The effective delimiter will be the <paramref name="delimiter"/> trimmed if it's not all whitespace.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
        /// -or-
        /// <paramref name="value"/> is either an empty string or only contains white space
        /// -or-
        /// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/>.</exception>
        [Pure]
        public static TEnum Parse<TEnum>(string value, string delimiter) => Parse<TEnum>(value, false, delimiter, null);

        [Pure]
        public static TEnum Parse<TEnum>(string value, string delimiter, params EnumFormat[] parseFormatOrder) => Parse<TEnum>(value, false, delimiter, parseFormatOrder);

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants
        /// delimited with the specified delimiter to an equivalent enumerated object.
        /// A parameter specifies whether the operation is case-insensitive.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="delimiter">The effective delimiter will be the <paramref name="delimiter"/> trimmed if it's not all whitespace.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
        /// -or-
        /// <paramref name="value"/> is either an empty string or only contains white space
        /// -or-
        /// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/>.</exception>
        [Pure]
        public static TEnum Parse<TEnum>(string value, bool ignoreCase, string delimiter) => Parse<TEnum>(value, ignoreCase, delimiter, null);

        [Pure]
        public static TEnum Parse<TEnum>(string value, bool ignoreCase, string delimiter, params EnumFormat[] parseFormatOrder)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.ParseFlags(value, ignoreCase, delimiter, parseFormatOrder);
        }

        /// <summary>
        /// Tries to convert the specified string representation of the name or numeric value of one or more enumerated
        /// constants to an equivalent enumerated object but if it fails returns the specified enumerated value.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum ParseOrDefault<TEnum>(string value, TEnum defaultValue) => ParseOrDefault(value, false, null, defaultValue, null);

        [Pure]
        public static TEnum ParseOrDefault<TEnum>(string value, TEnum defaultValue, params EnumFormat[] parseFormatOrder) => ParseOrDefault(value, false, null, defaultValue, parseFormatOrder);

        /// <summary>
        /// Tries to convert the specified string representation of the name or numeric value of one or more enumerated
        /// constants to an equivalent enumerated object but if it fails returns the specified enumerated value.
        /// A parameter specifies whether the operation is case-insensitive.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static TEnum ParseOrDefault<TEnum>(string value, bool ignoreCase, TEnum defaultValue) => ParseOrDefault(value, ignoreCase, null, defaultValue, null);

        [Pure]
        public static TEnum ParseOrDefault<TEnum>(string value, bool ignoreCase, TEnum defaultValue, params EnumFormat[] parseFormatOrder) => ParseOrDefault(value, ignoreCase, null, defaultValue, parseFormatOrder);

        /// <summary>
        /// Tries to convert the specified string representation of the name or numeric value of one or more enumerated
        /// constants delimited with the specified delimiter to an equivalent enumerated object but if it fails
        /// returns the specified enumerated value.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="delimiter"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
        /// -or-
        /// <paramref name="delimiter"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="delimiter"/> is null.</exception>
        [Pure]
        public static TEnum ParseOrDefault<TEnum>(string value, string delimiter, TEnum defaultValue) => ParseOrDefault(value, false, delimiter, defaultValue, null);

        [Pure]
        public static TEnum ParseOrDefault<TEnum>(string value, string delimiter, TEnum defaultValue, params EnumFormat[] parseFormatOrder) => ParseOrDefault(value, false, delimiter, defaultValue, parseFormatOrder);

        /// <summary>
        /// Tries to convert the specified string representation of the name or numeric value of one or more enumerated
        /// constants delimited with the specified delimiter to an equivalent enumerated object but if it fails
        /// returns the specified enumerated value. A parameter specifies whether the operation is case-insensitive.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="delimiter"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
        /// -or-
        /// <paramref name="delimiter"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="delimiter"/> is null.</exception>
        [Pure]
        public static TEnum ParseOrDefault<TEnum>(string value, bool ignoreCase, string delimiter, TEnum defaultValue) => ParseOrDefault(value, ignoreCase, delimiter, defaultValue, null);

        [Pure]
        public static TEnum ParseOrDefault<TEnum>(string value, bool ignoreCase, string delimiter, TEnum defaultValue, params EnumFormat[] parseFormatOrder)
        {
            TEnum result;
            return TryParse(value, ignoreCase, delimiter, out result, parseFormatOrder) ? result : defaultValue;
        }

        /// <summary>
        /// Tries to convert the specified string representation of the name or numeric value of one or more enumerated
        /// constants to an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static bool TryParse<TEnum>(string value, out TEnum result) => TryParse(value, false, null, out result, null);

        [Pure]
        public static bool TryParse<TEnum>(string value, out TEnum result, params EnumFormat[] parseFormatOrder) => TryParse(value, false, null, out result, parseFormatOrder);

        /// <summary>
        /// Tries to convert the specified string representation of the name or numeric value of one or more enumerated
        /// constants to an equivalent enumerated object. The return value indicates whether the conversion succeeded.
        /// A parameter specifies whether the operation is case-insensitive.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type</exception>
        [Pure]
        public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result) => TryParse(value, ignoreCase, null, out result, null);

        [Pure]
        public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result, params EnumFormat[] parseFormatOrder) => TryParse(value, ignoreCase, null, out result, parseFormatOrder);

        /// <summary>
        /// Tries to convert the specified string representation of the name or numeric value of one or more enumerated
        /// constants delimited with the specified delimiter to an equivalent enumerated object. The return value
        /// indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="delimiter"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
        /// -or-
        /// <paramref name="delimiter"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="delimiter"/> is null.</exception>
        [Pure]
        public static bool TryParse<TEnum>(string value, string delimiter, out TEnum result) => TryParse(value, false, delimiter, out result, null);

        [Pure]
        public static bool TryParse<TEnum>(string value, string delimiter, out TEnum result, params EnumFormat[] parseFormatOrder) => TryParse(value, false, delimiter, out result, parseFormatOrder);

        /// <summary>
        /// Tries to convert the specified string representation of the name or numeric value of one or more enumerated
        /// constants delimited with the specified delimiter to an equivalent enumerated object. The return value
        /// indicates whether the conversion succeeded. A parameter specifies whether the operation is case-insensitive.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="delimiter"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum type
        /// -or-
        /// <paramref name="delimiter"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="delimiter"/> is null.</exception>
        [Pure]
        public static bool TryParse<TEnum>(string value, bool ignoreCase, string delimiter, out TEnum result) => TryParse(value, ignoreCase, delimiter, out result, null);

        [Pure]
        public static bool TryParse<TEnum>(string value, bool ignoreCase, string delimiter, out TEnum result, params EnumFormat[] parseFormatOrder)
        {
            UnsafeEnums.VerifyTypeIsEnum(typeof(TEnum));
            return Enums<TEnum>.Info.TryParseFlags(value, ignoreCase, delimiter, out result, parseFormatOrder);
        }
        #endregion
    }
}
