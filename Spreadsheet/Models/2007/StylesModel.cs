// Copyright (c) DraviaVemal. Licensed under the MIT License. See License in the project root.

using OpenXMLOffice.Global_2007;
namespace OpenXMLOffice.Spreadsheet_2007
{
	/// <summary>
	/// Color Pattern Type
	/// TODO: Add more pattern types
	/// </summary>
	public enum PatternTypeValues
	{
		/// <summary>
		/// None Pattern
		/// </summary>
		NONE,
		/// <summary>
		///
		/// </summary>
		GRAY125,
		/// <summary>
		/// Solid Pattern Type
		/// </summary>
		SOLID
	}
	/// <summary>
	/// Font Scheme values
	/// </summary>
	public enum SchemeValues
	{
		/// <summary>
		/// None Scheme
		/// </summary>
		NONE,
		/// <summary>
		/// Minor Scheme
		/// </summary>
		MINOR,
		/// <summary>
		/// Major Scheme
		/// </summary>
		MAJOR
	}
	/// <summary>
	/// Border style values
	/// </summary>
	public enum StyleValues
	{
		/// <summary>
		/// None Border option
		/// </summary>
		NONE,
		/// <summary>
		/// Thin Border option
		/// </summary>
		THIN,
		/// <summary>
		/// Medium Border option
		/// </summary>
		THICK,
		/// <summary>
		/// Dotted Border option
		/// </summary>
		DOTTED,
		/// <summary>
		/// Double Border option
		/// </summary>
		DOUBLE,
		/// <summary>
		/// Dashed Border option
		/// </summary>
		DASHED,
		/// <summary>
		/// Dash Dot Border option
		/// </summary>
		DASH_DOT,
		/// <summary>
		/// Dash Dot Dot Border option
		/// </summary>
		DASH_DOT_DOT,
		/// <summary>
		/// Medium Border option
		/// </summary>
		MEDIUM,
		/// <summary>
		/// Medium Dashed Border option
		/// </summary>
		MEDIUM_DASHED,
		/// <summary>
		/// Medium Dash Dot Border option
		/// </summary>
		MEDIUM_DASH_DOT,
		/// <summary>
		/// Medium Dash Dot Dot Border option
		/// </summary>
		MEDIUM_DASH_DOT_DOT,
		/// <summary>
		/// Slant Dash Dot Border option
		/// </summary>
		SLANT_DASH_DOT,
		/// <summary>
		/// Hair Border option
		/// </summary>
		HAIR
	}
	/// <summary>
	///
	/// </summary>
	public enum ColorSettingTypeValues
	{
		/// <summary>
		///
		/// </summary>
		INDEXED,
		/// <summary>
		///
		/// </summary>
		THEME,
		/// <summary>
		///
		/// </summary>
		RGB
	}
	/// <summary>
	/// Represents the base class for a border in a style.
	/// </summary>
	public class BorderSetting
	{
		/// <summary>
		/// Gets or sets the color of the border.
		/// </summary>
		public ColorSetting BorderColor { get; set; }
		/// <summary>
		/// Gets or sets the style of the border.
		/// </summary>
		public StyleValues Style { get; set; }
		/// <summary>
		///
		/// </summary>
		public BorderSetting()
		{
			BorderColor = new ColorSetting()
			{
				ColorSettingTypeValues = ColorSettingTypeValues.INDEXED,
				Value = "64"
			};
			Style = StyleValues.NONE;
		}
	}
	/// <summary>
	/// Represents the border style of a cell in a worksheet.
	/// </summary>
	public class BorderStyle
	{
		/// <summary>
		/// Gets or sets the ID of the border style.
		/// </summary>
		public uint Id { get; set; }
		/// <summary>
		/// Bottom border style
		/// </summary>
		public BorderSetting Bottom { get; set; }
		/// <summary>
		/// Left border style
		/// </summary>
		public BorderSetting Left { get; set; }
		/// <summary>
		/// Right border style
		/// </summary>
		public BorderSetting Right { get; set; }
		/// <summary>
		/// Top border style
		/// </summary>
		public BorderSetting Top { get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="BorderStyle"/> class.
		/// </summary>
		public BorderStyle()
		{
			Bottom = new BorderSetting();
			Left = new BorderSetting();
			Right = new BorderSetting();
			Top = new BorderSetting();
		}
	}
	/// <summary>
	/// Represents the style of a cell in a worksheet.
	/// </summary>
	public class CellStyleSetting
	{
		/// <summary>
		/// Gets or sets the background color of the cell.
		/// </summary>
		public string backgroundColor;
		/// <summary>
		/// Bottom border style
		/// </summary>
		public BorderSetting borderBottom = new BorderSetting();
		/// <summary>
		/// Left border style
		/// </summary>
		public BorderSetting borderLeft = new BorderSetting();
		/// <summary>
		/// Right border style
		/// </summary>
		public BorderSetting borderRight = new BorderSetting();
		/// <summary>
		/// Top border style
		/// </summary>
		public BorderSetting borderTop = new BorderSetting();
		/// <summary>
		/// Gets or sets the font family of the cell. default is Calibri
		/// </summary>
		public string fontFamily = "Calibri";
		/// <summary>
		/// Gets or sets the font size of the cell. default is 11
		/// </summary>
		public uint fontSize = 11;
		/// <summary>
		/// Get or Set Foreground Color
		/// </summary>
		public string foregroundColor;
		/// <summary>
		/// Horizontal alignment of the cell. default is left
		/// </summary>
		public HorizontalAlignmentValues horizontalAlignment = HorizontalAlignmentValues.NONE;
		/// <summary>
		/// Is Cell Bold. default is false
		/// </summary>
		public bool isBold;
		/// <summary>
		/// Is Cell Double Underline. default is false
		/// </summary>
		public bool isDoubleUnderline;
		/// <summary>
		/// Is Cell Italic. default is false
		/// </summary>
		public bool isItalic;
		/// <summary>
		/// Is Cell Underline. default is false
		/// </summary>
		public bool isUnderline;
		/// <summary>
		/// Is Wrap Text. default is false
		/// </summary>
		public bool isWrapText;
		/// <summary>
		/// Gets or sets the number format of the cell. default is General
		/// </summary>
		public string numberFormat = "General";
		/// <summary>
		/// Gets or sets the text color of the cell. default is 000000
		/// </summary>
		public ColorSetting textColor = new ColorSetting()
		{
			ColorSettingTypeValues = ColorSettingTypeValues.RGB,
			Value = "000000"
		};
		/// <summary>
		/// Vertical alignment of the cell. default is bottom
		/// </summary>
		public VerticalAlignmentValues verticalAlignment = VerticalAlignmentValues.NONE;
	}
	/// <summary>
	/// Represents the cell style of a cell in a worksheet.
	/// </summary>
	public class CellXfs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CellXfs"/> class.
		/// </summary>
		public CellXfs()
		{
			HorizontalAlignment = HorizontalAlignmentValues.NONE;
			VerticalAlignment = VerticalAlignmentValues.NONE;
			FormatId = 0;
		}
		/// <summary>
		/// CellXfs ID
		/// </summary>
		public uint Id { get; set; }
		/// <summary>
		/// Format Id from collection
		/// </summary>
		public uint FormatId { get; set; }
		/// <summary>
		/// Number Format Id from collection
		/// </summary>
		public uint NumberFormatId { get; set; }
		/// <summary>
		/// Font Id from collection
		/// </summary>
		public uint FontId { get; set; }
		/// <summary>
		/// Fill Id from collection
		/// </summary>
		public uint FillId { get; set; }
		/// <summary>
		/// Border Id from collection
		/// </summary>
		public uint BorderId { get; set; }
		/// <summary>
		/// Apply Font style
		/// </summary>
		public bool ApplyFont { get; set; }
		/// <summary>
		/// Apply Alignment
		/// </summary>
		public bool ApplyAlignment { get; set; }
		/// <summary>
		/// Apply Fill style
		/// </summary>
		public bool ApplyFill { get; set; }
		/// <summary>
		/// Apply Border style
		/// </summary>
		public bool ApplyBorder { get; set; }
		/// <summary>
		/// Apply Number Format
		/// </summary>
		public bool ApplyNumberFormat { get; set; }
		/// <summary>
		/// Apply Protection
		/// </summary>
		public bool ApplyProtection { get; set; }
		/// <summary>
		/// Is Wrap Text. default is false
		/// </summary>
		public bool IsWrapText { get; internal set; }
		/// <summary>
		/// Horizontal alignment of the cell. default is left
		/// </summary>
		public HorizontalAlignmentValues HorizontalAlignment { get; set; }
		/// <summary>
		/// Vertical alignment of the cell. default is bottom
		/// </summary>
		public VerticalAlignmentValues VerticalAlignment { get; set; }
	}
	/// <summary>
	/// Represents the fill style of a cell in a worksheet.
	/// </summary>
	public class FillStyle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FillStyle"/> class.
		/// </summary>
		public FillStyle()
		{
			PatternType = PatternTypeValues.NONE;
		}
		/// <summary>
		/// Gets or sets the background color of the cell.
		/// </summary>
		public ColorSetting BackgroundColor { get; set; }
		/// <summary>
		/// Gets or sets the foreground color of the cell.
		/// </summary>
		public ColorSetting ForegroundColor { get; set; }
		/// <summary>
		/// Fill style ID
		/// </summary>
		public uint Id { get; set; }
		/// <summary>
		/// Pattern Type
		/// </summary>
		public PatternTypeValues PatternType { get; set; }
	}
	/// <summary>
	///
	/// </summary>
	public class ColorSetting
	{
		/// <summary>
		///
		/// </summary>
		public ColorSettingTypeValues ColorSettingTypeValues { get; set; }
		/// <summary>
		///
		/// </summary>
		public string Value { get; set; }
		/// <summary>
		///
		/// </summary>
		public ColorSetting()
		{
			ColorSettingTypeValues = ColorSettingTypeValues.THEME;
			Value = "1";
		}
	}
	/// <summary>
	/// Represents the font style of a cell in a worksheet.
	/// </summary>
	public class FontStyle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FontStyle"/> class.
		/// </summary>
		public FontStyle()
		{
			Color = new ColorSetting() { Value = "1" };
			Family = 2;
			Size = 11;
			Name = "Calibri";
			FontScheme = SchemeValues.NONE;
		}
		/// <summary>
		/// Font style ID
		/// </summary>
		public uint Id { get; set; }
		/// <summary>
		/// Gets or sets the color of the font. default is accent1
		/// </summary>
		public ColorSetting Color { get; set; }
		/// <summary>
		/// Gets or sets the font family of the font.
		/// </summary>
		public int Family { get; set; }
		/// <summary>
		/// Configure Font Scheme
		/// </summary>
		public SchemeValues FontScheme { get; set; }
		/// <summary>
		/// Is Cell Bold
		/// </summary>
		public bool IsBold { get; set; }
		/// <summary>
		/// Is Cell Double Underline. default is false
		/// </summary>
		public bool IsDoubleUnderline { get; set; }
		/// <summary>
		/// Is Cell Italic. default is false
		/// </summary>
		public bool IsItalic { get; set; }
		/// <summary>
		/// Is Cell Underline. default is false
		/// </summary>
		public bool IsUnderline { get; set; }
		/// <summary>
		/// Font name default is Calibri
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the size of the font. default is 11
		/// </summary>
		public uint Size { get; set; }
	}
	/// <summary>
	/// Represents the number format of a cell in a worksheet.
	/// </summary>
	public class NumberFormats
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NumberFormats"/> class.
		/// </summary>
		public NumberFormats()
		{
			FormatCode = "General";
		}
		/// <summary>
		/// Number format code
		/// </summary>
		public string FormatCode { get; set; }
		/// <summary>
		/// Number format ID
		/// </summary>
		public uint Id { get; set; }
	}
}
