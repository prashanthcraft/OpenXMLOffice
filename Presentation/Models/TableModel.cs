// Copyright (c) DraviaVemal. Licensed under the MIT License. See License in the project root.

using System.Collections.Generic;
using OpenXMLOffice.Global_2007;
namespace OpenXMLOffice.Presentation_2007
{
	/// <summary>
	///
	/// </summary>
	public class TableBorderSetting
	{
		/// <summary>
		///
		/// </summary>
		public bool showBorder;
		/// <summary>
		///
		/// </summary>
		public string borderColor = "000000";
		/// <summary>
		///
		/// </summary>
		public float width = 1.27F;
		/// <summary>
		///
		/// </summary>
		public BorderStyleValues borderStyle = BorderStyleValues.SINGEL;
		/// <summary>
		///
		/// </summary>
		public DrawingPresetLineDashValues dashStyle = DrawingPresetLineDashValues.SOLID;
	}
	/// <summary>
	///
	/// </summary>
	public class TableBorderSettings
	{
		/// <summary>
		///
		/// </summary>
		public TableBorderSetting leftBorder = new TableBorderSetting();
		/// <summary>
		///
		/// </summary>
		public TableBorderSetting topBorder = new TableBorderSetting();
		/// <summary>
		///
		/// </summary>
		public TableBorderSetting rightBorder = new TableBorderSetting();
		/// <summary>
		///
		/// </summary>
		public TableBorderSetting bottomBorder = new TableBorderSetting();
		/// <summary>
		///
		/// </summary>
		public TableBorderSetting topLeftToBottomRightBorder = new TableBorderSetting();
		/// <summary>
		///
		/// </summary>
		public TableBorderSetting bottomLeftToTopRightBorder = new TableBorderSetting();
	}
	/// <summary>
	/// Presentation Table Cell Class for setting the cell properties.
	/// </summary>
	public class TableCell : TextOptions
	{
		/// <summary>
		/// Merge rows below this cell
		/// </summary>
		public uint rowSpan = 0;
		/// <summary>
		/// Merge Columns to the right of this cell
		/// </summary>
		public uint columnSpan = 0;
		/// <summary>
		/// Cell Alignment Option
		/// </summary>
		public HorizontalAlignmentValues? horizontalAlignment;
		/// <summary>
		///
		/// </summary>
		public VerticalAlignmentValues? verticalAlignment;
		/// <summary>
		///
		/// </summary>
		public TableBorderSettings borderSettings = new TableBorderSettings();
		/// <summary>
		/// Cell Background Color
		/// </summary>
		public string cellBackground;
		/// <summary>
		/// Text Background Color aka Highlight Color
		/// </summary>
		public string textBackground;
		/// <summary>
		/// Text Color
		/// </summary>
		public string textColor = "000000";
	}
	/// <summary>
	/// Table Row Customization Properties
	/// </summary>
	public class TableRow
	{
		/// <summary>
		/// Row Height
		/// </summary>
		public int height = 370840;
		/// <summary>
		/// Row Background Color.Will get overridden by TableCell.CellBackground
		/// </summary>
		public string rowBackground;
		/// <summary>
		/// Table Cell List
		/// </summary>
		public List<TableCell> tableCells = new List<TableCell>();
		/// <summary>
		/// Default Text Color for the row. Will get overridden by TableCell.TextColor
		/// </summary>
		public string textColor = "000000";
	}
	/// <summary>
	/// Table Customization Properties
	/// </summary>
	public class TableSetting
	{
		/// <summary>
		/// Overall Table Height
		/// </summary>
		public uint height = 741680;
		/// <summary>
		/// Table Name. Default: Table 1
		/// </summary>
		public string name = "Table 1";
		/// <summary>
		/// Table Column Width List.Works based on WidthType Setting
		/// </summary>
		public List<float> tableColumnWidth = new List<float>();
		/// <summary>
		/// Overall Table Width
		/// </summary>
		public uint width = 8128000;
		/// <summary>
		/// AUTO - Ignore User Width value and space the colum equally EMU - (English Metric Units)
		/// Direct PPT standard Sizing 1 Inch * 914400 EMU's PIXEL - Based on Target DPI the pixel
		/// is converted to EMU and used when running PERCENTAGE - 0-100 Width percentage split for
		/// each column RATIO - 0-10 Width ratio of each column
		/// </summary>
		public WidthOptionValues widthType = WidthOptionValues.AUTO;
		/// <summary>
		/// Table X Position in the slide in EMUs (English Metric Units).
		/// </summary>
		public uint x = 0;
		/// <summary>
		/// Table Y Position in the slide in EMUs (English Metric Units).
		/// </summary>
		public uint y = 0;
		/// <summary>
		/// Width Option Values
		/// </summary>
		public enum WidthOptionValues
		{
			/// <summary>
			/// AUTO - Ignore User Width value and space the colum equally
			/// </summary>
			AUTO,
			/// <summary>
			/// EMU - (English Metric Units) Direct PPT standard Sizing 1 Inch * 914400 EMU's
			/// </summary>
			EMU,
			/// <summary>
			/// PIXEL - Based on Target DPI the pixel is converted to EMU and used when running
			/// </summary>
			PIXEL,
			/// <summary>
			/// PERCENTAGE - 0-100 Width percentage split for each column
			/// </summary>
			PERCENTAGE,
			/// <summary>
			/// RATIO - 0-10 Width ratio of each column
			/// </summary>
			RATIO
		}
	}
}
