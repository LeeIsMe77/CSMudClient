namespace CommandClient.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Xml.Linq;
	using MudClient.Common.Extensions;
	#endregion

	public sealed class OptionsManager {

		#region Properties

		#region BackgroundColor

		public Color BackgroundColor { get; set; } = Color.LightGray;

		#endregion

		#region ForegroundColor

		public Color ForegroundColor { get; set; } = Color.Black;

		#endregion

		#region CommandColor

		public Color CommandColor { get; set; } = Color.Gold;

		#endregion

		#region ColorConverter

		private ColorConverter _colorConverter;

		/// <summary>
		/// Gets the color converter.
		/// </summary>
		/// <value>The color converter.</value>
		public ColorConverter ColorConverter {
			get { return _colorConverter ?? (_colorConverter = new ColorConverter()); }
		}

		#endregion

		#region Font

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public Font Font { get; set; } = new Font(FontFamily.GenericSerif, 10f, FontStyle.Regular);

		#endregion

		#region FontConverter

		private FontConverter _fontConverter;

		/// <summary>
		/// Gets the font converter.
		/// </summary>
		/// <value>The font converter.</value>
		public FontConverter FontConverter {
			get { return _fontConverter ?? (_fontConverter = new FontConverter()); }
		}

		#endregion

		#region CommandDelimiter

		public char CommandDelimiter { get; set; } = ';';

		#endregion

		#region OptionsXml

		/// <summary>
		/// Gets the options XML.
		/// </summary>
		/// <value>The options XML.</value>
		public XElement OptionsXml {
			get {
				return new XElement(@"Options",
					new XElement(@"BackgroundColor", ColorConverter.ConvertToString(this.BackgroundColor)),
					new XElement(@"ForegroundColor", ColorConverter.ConvertToString(this.ForegroundColor)),
					new XElement(@"CommandColor", ColorConverter.ConvertToString(this.CommandColor)),
					new XElement(@"CommandDelimiter", this.CommandDelimiter),
					new XElement(@"Font", this.FontConverter.ConvertToString(this.Font))
					);
			}
			set {
				if (value != null) {
					var colorString = string.Empty;

					colorString = value.SafeElementValue<string>(@"BackgroundColor", string.Empty);
					this.BackgroundColor = string.IsNullOrWhiteSpace(colorString) ? this.BackgroundColor : (Color)this.ColorConverter.ConvertFromString(colorString);

					colorString = value.SafeElementValue<string>(@"ForegroundColor", string.Empty);
					this.ForegroundColor = string.IsNullOrWhiteSpace(colorString) ? this.ForegroundColor : (Color)this.ColorConverter.ConvertFromString(colorString);

					colorString = value.SafeElementValue<string>(@"CommandColor", string.Empty);
					this.CommandColor = string.IsNullOrWhiteSpace(colorString) ? this.CommandColor : (Color)this.ColorConverter.ConvertFromString(colorString);

					this.CommandDelimiter = value.SafeElementValue<char>(@"CommandDelimiter");

					var fontString = value.SafeElementValue<string>(@"Font", string.Empty);
					this.Font = string.IsNullOrWhiteSpace(fontString) ? this.Font : (Font)this.FontConverter.ConvertFromString(fontString);
				}

			}

		}

	}

	#endregion

	#endregion

}
