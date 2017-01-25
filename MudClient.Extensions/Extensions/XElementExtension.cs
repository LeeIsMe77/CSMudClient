namespace MudClient.Common.Extensions {

	#region Directives
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Xml.Linq;
	#endregion

	/// <summary>
	/// Extension class for working with XElements.
	/// </summary>
	public static class XElementExtension {

		/// <summary>
		/// Retrieves the element of the supplied name and safely returns its value as a the type specified.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="element">The element.</param>
		/// <param name="attributeName">Name of the element.</param>
		/// <returns>The value of the element converted to the type specified. If the element is null, or the conversion can't be performed, then the default value of the type specified.</returns>
		public static T SafeAttributeValue<T>(this XElement element, XName attributeName) {
			if (element == null) return default(T);
			var extractedAttribute = element.Attribute(attributeName);
			if (extractedAttribute == null) return default(T);

			var convertedType = default(T);
			try {
				if (typeof(T).IsEnum) {
					if (Enum.IsDefined(typeof(T), extractedAttribute.Value)) {
						return (T)Enum.Parse(typeof(T), extractedAttribute.Value, true);
					}
				}
				else if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>)) {
					var underlyingType = Nullable.GetUnderlyingType(typeof(T));
					convertedType = (T)Convert.ChangeType(extractedAttribute.Value, underlyingType);
				}
				else {
					convertedType = (T)Convert.ChangeType(extractedAttribute.Value, typeof(T));
				}
			}
			catch { }
			return convertedType;
		}

		/// <summary>
		/// Retrieves the element of the supplied name and safely returns its value as a the type specified.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="element">The element.</param>
		/// <param name="attributeName">Name of the element.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>The value of the element converted to the type specified. If the element is null, or the conversion can't be performed, then the default value of the type specified.</returns>
		public static T SafeAttributeValue<T>(this XElement element, XName attributeName, T defaultValue) {
			if (element == null) return defaultValue;
			var extractedAttribute = element.Attribute(attributeName);
			if (extractedAttribute == null) return defaultValue;

			var convertedType = default(T);
			try {
				if (typeof(T).IsEnum) {
					if (Enum.IsDefined(typeof(T), extractedAttribute.Value)) {
						return (T)Enum.Parse(typeof(T), extractedAttribute.Value, true);
					}
				}
				else if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>)) {
					var underlyingType = Nullable.GetUnderlyingType(typeof(T));
					convertedType = (T)Convert.ChangeType(extractedAttribute.Value, underlyingType);
				}
				else {
					convertedType = (T)Convert.ChangeType(extractedAttribute.Value, typeof(T));
				}
			}
			catch {
				return defaultValue;
			}
			return convertedType;
		}

		/// <summary>
		/// Retrieves the element of the supplied name and safely returns its value as a the type specified.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="element">The element.</param>
		/// <param name="elementName">Name of the element.</param>
		/// <returns>The value of the element converted to the type specified. If the element is null, or the conversion can't be performed, then the default value of the type specified.</returns>
		public static T SafeElementValue<T>(this XElement element, XName elementName) {
			if (element == null) return default(T);
			var extractedElement = element.Element(elementName);
			if (extractedElement == null) return default(T);
			var convertedType = default(T);
			try {
				if (typeof(T).IsEnum) {
					if (Enum.IsDefined(typeof(T), extractedElement.Value)) {
						return (T)Enum.Parse(typeof(T), extractedElement.Value, true);
					}
				}
				else {
					convertedType = (T)Convert.ChangeType(extractedElement.Value, typeof(T));
				}
			}
			catch { }
			return convertedType;
		}

		/// <summary>
		/// Retrieves the element of the supplied name and safely returns its value as a the type specified.
		/// </summary>
		/// <typeparam name="T">Can be any type included nullable and enumeration types.</typeparam>
		/// <param name="element">The element.</param>
		/// <param name="elementName">Name of the element.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>The value of the element converted to the type specified. If the element is null, or the conversion can't be performed, then the default value of the type specified.</returns>
		public static T SafeElementValue<T>(this XElement element, XName elementName, T defaultValue) {
			if (element == null) return defaultValue;
			var extractedElement = element.Element(elementName);
			if (extractedElement == null) return defaultValue;
			var convertedType = default(T);
			try {
				if (typeof(T).IsEnum) {
					if (Enum.IsDefined(typeof(T), extractedElement.Value)) {
						return (T)Enum.Parse(typeof(T), extractedElement.Value, true);
					}
				}
				else if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>)) {
					var underlyingType = Nullable.GetUnderlyingType(typeof(T));
					convertedType = (T)Convert.ChangeType(extractedElement.Value, underlyingType);
				}
				else {
					convertedType = (T)Convert.ChangeType(extractedElement.Value, typeof(T));
				}
			}
			catch {
				return defaultValue;
			}
			return convertedType;
		}
		
	}

}