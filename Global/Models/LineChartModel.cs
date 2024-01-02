namespace OpenXMLOffice.Global
{
    public enum LineChartTypes
    {
        CLUSTERED,
        STACKED,
        PERCENT_STACKED,
        CLUSTERED_MARKER,
        STACKED_MARKER,
        PERCENT_STACKED_MARKER,
        // CLUSTERED_3D
    }

    public class LineChartDataLabel
    {
        #region Public Fields

        public eDataLabelPosition DataLabelPosition = eDataLabelPosition.NONE;

        #endregion Public Fields

        #region Public Enums

        public enum eDataLabelPosition
        {
            NONE,
            LEFT,
            RIGHT,
            CENTER,
            ABOVE,
            BELOW,
            // CALLOUT
        }

        #endregion Public Enums
    }

    public class LineChartSeriesSetting : ChartSeriesSetting
    {
        #region Public Fields

        public string? BorderColor;
        public string? FillColor;
        public LineChartDataLabel LineChartDataLabel = new();

        #endregion Public Fields
    }

    public class LineChartSetting : ChartSetting
    {
        #region Public Fields

        public ChartAxesOptions ChartAxesOptions = new();
        public ChartAxisOptions ChartAxisOptions = new();
        public ChartGridLinesOptions ChartGridLinesOptions = new();
        public List<LineChartSeriesSetting> LineChartSeriesSettings = new();
        public LineChartTypes LineChartTypes = LineChartTypes.CLUSTERED;

        #endregion Public Fields
    }
}