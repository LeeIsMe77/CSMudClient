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
		/// Used to read attributes that contain a string.
		/// </summary>
		public static string ReadAttributeValue(this XElement element, string attributeName, string defaultValue) {
			if (element == null) throw new ArgumentNullException(nameof(element), "The extended XElement is null.");
			var attribute = element.Attribute(attributeName);
			return attribute?.Value ?? defaultValue;
		}

		/// <summary>
		/// Used to read attributes that contain a value type.
		/// </summary>
		public static T ReadAttributeValue<T>(this XElement element, string attributeName, T defaultValue) where T : struct {
			if (element == null) throw new ArgumentNullException(nameof(element), "The extended XElement is null.");
			var attribute = element.Attribute(attributeName);
			if (attribute == null) {
				return defaultValue;
			}
			try {
				return (T)Convert.ChangeType(attribute.Value, typeof(T));
			}
			catch {
				return defaultValue;
			}
		}

		/// <summary>
		/// Used to read attributes that contain a Guid.
		/// </summary>
		public static Guid ReadAttributeValue(this XElement element, string attributeName, Guid defaultValue) {
			if (element == null) throw new ArgumentNullException(nameof(element), "The extended XElement is null.");
			var attribute = element.Attribute(attributeName);
			if (attribute == null) {
				return defaultValue;
			}
			try {
				return Guid.Parse(attribute.Value);
			}
			catch {
				return defaultValue;
			}
		}

		/// <summary>
		/// Used to read attributes that contain a nullable type.
		/// </summary>
		public static T? ReadAttributeValue<T>(this XElement element, string attributeName, T? defaultValue) where T : struct {
			if (element == null) throw new ArgumentNullException(nameof(element), "The extended XElement is null.");
			var attribute = element.Attribute(attributeName);
			if (attribute == null) {
				return defaultValue;
			}
			try {
				return (T)Convert.ChangeType(attribute.Value, typeof(T));
			}
			catch {
				return defaultValue;
			}
		}

		/// <summary>
		/// Used to read attributes that contain an enumeration value.
		/// </summary>
		public static TEnumeration ReadAttributeValue<TEnumeration>(this XElement element, string attributeName, TEnumeration defaultValue, bool ignoreCase) {
			var enumType = typeof(TEnumeration);
			if (!enumType.IsEnum) {
				throw new ArgumentException($"Type {enumType.Name} is not an enumeration type.");
			}
			if (element == null) throw new ArgumentNullException(nameof(element), "The extended XElement is null.");
			var attribute = element.Attribute(attributeName);
			if (attribute == null) {
				return defaultValue;
			}
			return ignoreCase || Enum.IsDefined(enumType, attribute.Value)
				? (TEnumeration)Enum.Parse(enumType, attribute.Value, ignoreCase)
				: defaultValue;
		}

		/// <summary>
		/// Used to read child elements that contain a string.
		/// </summary>
		public static string ReadChildElementValue(this XElement element, string childElementName, string defaultValue) {
			if (element == null) throw new ArgumentNullException(nameof(element), "The extended XElement is null.");
			var childElement = element.Element(childElementName);
			return childElement?.Value ?? defaultValue;
		}

		/// <summary>
		/// Used to read child elements that contain an enumeration value.
		/// </summary>
		public static TEnumeration ReadChildElementValue<TEnumeration>(this XElement element, string childElementName, TEnumeration defaultValue, bool ignoreCase) {
			var enumType = typeof(TEnumeration);
			if (!enumType.IsEnum) {
				throw new ArgumentException($"Type {enumType.Name} is not an enumeration type.");
			}
			if (element == null) throw new ArgumentNullException(nameof(element), "The extended XElement is null.");
			var childElement = element.Element(childElementName);
			if (childElement == null) {
				return defaultValue;
			}
			return ignoreCase || Enum.IsDefined(enumType, childElement.Value)
				? (TEnumeration)Enum.Parse(enumType, childElement.Value, ignoreCase)
				: defaultValue;
		}

		/// <summary>
		/// Retrieves the attribute of the supplied name and safely returns its value as a string.
		/// </summary>
		/// <param name="element">The attribute.</param>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <returns>The string of the value, if present, else, an empty string.</returns>
		/// <remarks>
		/// This extension method is meant for situations where its unsure whether or not the attribute will actually be present.
		/// Rather than using a syntax such as 
		///		element.Attribute(attributeName).Value.SafeString(true)
		///	which can result in an exception if the element is null,
		///	this extension method takes care of handling that potential null reference.
		/// </remarks>
		[DebuggerStepThrough]
		public static string SafeAttributeValue(this XElement element, XName attributeName) {
			if (element == null) return string.Empty;
			var extractedAttribute = element.Attribute(attributeName);
			return extractedAttribute?.Value?.Trim() ?? string.Empty;
		}

		/// <summary>
		/// Retrieves the element of the supplied name and safely returns its value as a the type specified.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="element">The element.</param>
		/// <param name="attributeName">Name of the element.</param>
		/// <returns>The value of the element converted to the type specified. If the element is null, or the conversion can't be performed, then the default value of the type specified.</returns>
		[DebuggerStepThrough]
		public static T SafeAttributeValue<T>(this XElement element, XName attributeName) {
			if (element == null) return default(T);
			var extractedAttribute = element.Attribute(attributeName);
			if (extractedAttribute == null) return default(T);
			var convertedAttribute = default(T);
			try {
				convertedAttribute = (T)Convert.ChangeType(extractedAttribute.Value, typeof(T));
			}
			catch { }
			return convertedAttribute;
		}

		/// <summary>
		/// Retrieves the element of the supplied name and safely returns its value as a string.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="elementName">Name of the element.</param>
		/// <returns>The string of the value, if present, else, an empty string.</returns>
		/// <remarks>
		/// This extension method is meant for situations where its unsure whether or not the element will actually be present.
		/// Rather than using a syntax such as 
		///		element.Element(attributeName).Value.SafeString(true)
		///	which can result in an exception if the element is null,
		///	this extension method takes care of handling that potential null reference.
		/// </remarks>
		[DebuggerStepThrough]
		public static string SafeElementValue(this XElement element, XName elementName) {
			if (element == null) return string.Empty;
			var extractedElement = element.Element(elementName);
			return extractedElement?.Value?.Trim() ?? string.Empty;
		}

		/// <summary>
		/// Retrieves the element of the supplied name and safely returns its value as a the type specified.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="element">The element.</param>
		/// <param name="elementName">Name of the element.</param>
		/// <returns>The value of the element converted to the type specified. If the element is null, or the conversion can't be performed, then the default value of the type specified.</returns>
		[DebuggerStepThrough]
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
		/// <exception cref="System.ArgumentNullException">element;The extended XElement is null.</exception>
		[DebuggerStepThrough]
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

		/// <summary>
		/// Writes the contents of a <see cref="XElement" /> to a file.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="fileName">Name of the file.</param>
		public static void WriteToFile(this XElement element, string fileName) {
			if (element == null) return;
			using (var outputFileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) {
				element.Save(outputFileStream);
				outputFileStream.Flush();
			}
		}

	}

}