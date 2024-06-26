// Copyright (c) DraviaVemal. Licensed under the MIT License. See License in the project root.

using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using OpenXMLOffice.Global_2013;
using C = DocumentFormat.OpenXml.Drawing.Charts;
namespace OpenXMLOffice.Global_2007
{
	/// <summary>
	/// Area Chart Core data
	/// </summary>
	public class AreaChart<ApplicationSpecificSetting> : ChartAdvance<ApplicationSpecificSetting>
		where ApplicationSpecificSetting : class, ISizeAndPosition, new()
	{
		/// <summary>
		/// Area Chart Setting
		/// </summary>
		protected readonly AreaChartSetting<ApplicationSpecificSetting> areaChartSetting;
		internal AreaChart(AreaChartSetting<ApplicationSpecificSetting> areaChartSetting) : base(areaChartSetting)
		{
			this.areaChartSetting = areaChartSetting;
		}
		/// <summary>
		/// Create Area Chart with provided settings
		/// </summary>
		public AreaChart(AreaChartSetting<ApplicationSpecificSetting> areaChartSetting, ChartData[][] dataCols, DataRange dataRange = null) : base(areaChartSetting)
		{
			this.areaChartSetting = areaChartSetting;
			if (areaChartSetting.areaChartType == AreaChartTypes.CLUSTERED_3D ||
			areaChartSetting.areaChartType == AreaChartTypes.STACKED_3D ||
			areaChartSetting.areaChartType == AreaChartTypes.PERCENT_STACKED_3D)
			{
				this.areaChartSetting.is3DChart = true;
				Add3dControl();
			}
			SetChartPlotArea(CreateChartPlotArea(dataCols, dataRange));
		}
		private ColorOptionModel<SolidOptions> GetSeriesBorderColor(int seriesIndex, ChartDataGrouping chartDataGrouping)
		{
			ColorOptionModel<SolidOptions> solidFillModel = new ColorOptionModel<SolidOptions>();
			string hexColor = areaChartSetting.areaChartSeriesSettings
						.Select(item => item.borderColor)
						.ToList().ElementAtOrDefault(seriesIndex);
			if (hexColor != null)
			{
				solidFillModel.colorOption.hexColor = hexColor;
				return solidFillModel;
			}
			else
			{
				solidFillModel.colorOption.schemeColorModel = new SchemeColorModel()
				{
					themeColorValues = ThemeColorValues.ACCENT_1 + (chartDataGrouping.id % AccentColorCount),
				};
			}
			return solidFillModel;
		}
		private ColorOptionModel<SolidOptions> GetSeriesFillColor(int seriesIndex, ChartDataGrouping chartDataGrouping)
		{
			ColorOptionModel<SolidOptions> solidFillModel = new ColorOptionModel<SolidOptions>();
			string hexColor = areaChartSetting.areaChartSeriesSettings
						.Select(item => item.fillColor)
						.ToList().ElementAtOrDefault(seriesIndex);
			if (hexColor != null)
			{
				solidFillModel.colorOption.hexColor = hexColor;
				return solidFillModel;
			}
			else
			{
				solidFillModel.colorOption.schemeColorModel = new SchemeColorModel()
				{
					themeColorValues = ThemeColorValues.ACCENT_1 + (chartDataGrouping.id % AccentColorCount),
				};
			}
			return solidFillModel;
		}
		private C.AreaChartSeries CreateAreaChartSeries(int seriesIndex, ChartDataGrouping chartDataGrouping)
		{
			ShapePropertiesModel<SolidOptions, SolidOptions> shapePropertiesModel = new ShapePropertiesModel<SolidOptions, SolidOptions>()
			{
				fillColor = GetSeriesFillColor(seriesIndex, chartDataGrouping),
				lineColor = new OutlineModel<SolidOptions>()
				{
					lineColor = GetSeriesBorderColor(seriesIndex, chartDataGrouping)
				}
			};
			C.DataLabels dataLabels = null;
			AreaChartSeriesSetting areaChartSeriesSetting = areaChartSetting.areaChartSeriesSettings.ElementAtOrDefault(seriesIndex);
			if (seriesIndex < areaChartSetting.areaChartSeriesSettings.Count)
			{
				AreaChartDataLabel areaChartDataLabel = areaChartSeriesSetting != null ? areaChartSeriesSetting.areaChartDataLabel : null;
				int dataLabelCellsLength = chartDataGrouping.dataLabelCells != null ? chartDataGrouping.dataLabelCells.Length : 0;
				dataLabels = CreateAreaDataLabels(areaChartDataLabel ?? new AreaChartDataLabel(), dataLabelCellsLength);
			}
			C.AreaChartSeries series = new C.AreaChartSeries(
				new C.Index { Val = new UInt32Value((uint)chartDataGrouping.id) },
				new C.Order { Val = new UInt32Value((uint)chartDataGrouping.id) },
				CreateSeriesText(chartDataGrouping.seriesHeaderFormula, new[] { chartDataGrouping.seriesHeaderCells }));
			series.Append(CreateChartShapeProperties(shapePropertiesModel));
			if (areaChartSeriesSetting != null)
			{
				areaChartSeriesSetting.trendLines.ForEach(trendLine =>
				{
					if (areaChartSetting.areaChartType != AreaChartTypes.CLUSTERED)
					{
						throw new ArgumentException("Treadline is not supported in the given chart type");
					}
					ColorOptionModel<SolidOptions> solidFillModel = new ColorOptionModel<SolidOptions>();
					if (trendLine.hexColor != null)
					{
						solidFillModel.colorOption.hexColor = trendLine.hexColor;
					}
					else
					{
						solidFillModel.colorOption.schemeColorModel = new SchemeColorModel()
						{
							themeColorValues = ThemeColorValues.ACCENT_1 + (seriesIndex % AccentColorCount)
						};
					}
					TrendLineModel trendLineModel = new TrendLineModel
					{
						secondaryValue = trendLine.secondaryValue,
						trendLineType = trendLine.trendLineType,
						trendLineName = trendLine.trendLineName,
						forecastBackward = trendLine.forecastBackward,
						forecastForward = trendLine.forecastForward,
						setIntercept = trendLine.setIntercept,
						showEquation = trendLine.showEquation,
						showRSquareValue = trendLine.showRSquareValue,
						interceptValue = trendLine.interceptValue,
						solidFill = solidFillModel,
						drawingPresetLineDashValues = trendLine.lineStye,
					};
					series.Append(CreateTrendLine(trendLineModel));
				});
			}
			if (dataLabels != null)
			{
				series.Append(dataLabels);
			}
			series.Append(CreateCategoryAxisData(chartDataGrouping.xAxisFormula, chartDataGrouping.xAxisCells));
			series.Append(CreateValueAxisData(chartDataGrouping.yAxisFormula, chartDataGrouping.yAxisCells));
			if (chartDataGrouping.dataLabelCells != null && chartDataGrouping.dataLabelFormula != null)
			{
				series.Append(new C.ExtensionList(new C.Extension(
					CreateDataLabelsRange(chartDataGrouping.dataLabelFormula, chartDataGrouping.dataLabelCells.Skip(1).ToArray())
				)
				{ Uri = "{02D57815-91ED-43cb-92C2-25804820EDAC}" }));
			}
			return series;
		}
		private C.DataLabels CreateAreaDataLabels(AreaChartDataLabel areaChartDataLabel, int dataLabelCounter = 0)
		{
			if (areaChartDataLabel.showValue || areaChartSetting.chartDataSetting.advancedDataLabel.showValueFromColumn || areaChartDataLabel.showCategoryName || areaChartDataLabel.showLegendKey || areaChartDataLabel.showSeriesName)
			{
				C.DataLabels dataLabels = CreateDataLabels(areaChartDataLabel, dataLabelCounter);
				C.DataLabelPositionValues positionValue;
				switch (areaChartDataLabel.dataLabelPosition)
				{
					// Add cases for other dataLabelPosition values as needed
					default:
						positionValue = C.DataLabelPositionValues.Center;
						break;
				}
				C.DataLabelPosition dataLabelPosition = new C.DataLabelPosition { Val = positionValue };
				dataLabels.InsertAt(dataLabelPosition, 0);
				return dataLabels;
			}
			return null;
		}
		private C.PlotArea CreateChartPlotArea(ChartData[][] dataCols, DataRange dataRange)
		{
			C.PlotArea plotArea = new C.PlotArea();
			plotArea.Append(CreateLayout(areaChartSetting.plotAreaOptions != null ? areaChartSetting.plotAreaOptions.manualLayout : null));
			if (areaChartSetting.is3DChart)
			{
				plotArea.Append(CreateAreaChart<C.Area3DChart>(CreateDataSeries(areaChartSetting.chartDataSetting, dataCols, dataRange)));
			}
			else
			{
				plotArea.Append(CreateAreaChart<C.AreaChart>(CreateDataSeries(areaChartSetting.chartDataSetting, dataCols, dataRange)));
			}
			plotArea.Append(CreateAxis(new AxisSetting<XAxisOptions<CategoryAxis>, CategoryAxis>()
			{
				id = areaChartSetting.isSecondaryAxis ? SecondaryCategoryAxisId : CategoryAxisId,
				crossAxisId = areaChartSetting.isSecondaryAxis ? SecondaryValueAxisId : ValueAxisId,
				axisOptions = areaChartSetting.chartAxisOptions.xAxisOptions,
				axisPosition = areaChartSetting.chartAxisOptions.xAxisOptions.chartAxesOptions.inReverseOrder ? AxisPosition.TOP : AxisPosition.BOTTOM,
			}));
			plotArea.Append(CreateAxis(new AxisSetting<YAxisOptions<ValueAxis>, ValueAxis>()
			{
				id = areaChartSetting.isSecondaryAxis ? SecondaryValueAxisId : ValueAxisId,
				crossAxisId = areaChartSetting.isSecondaryAxis ? SecondaryCategoryAxisId : CategoryAxisId,
				axisOptions = areaChartSetting.chartAxisOptions.yAxisOptions,
				axisPosition = areaChartSetting.chartAxisOptions.yAxisOptions.chartAxesOptions.inReverseOrder ? AxisPosition.RIGHT : AxisPosition.LEFT,
			}));
			plotArea.Append(CreateChartShapeProperties());
			return plotArea;
		}
		internal ChartType CreateAreaChart<ChartType>(List<ChartDataGrouping> chartDataGroupings) where ChartType : OpenXmlCompositeElement, new()
		{
			ChartType areaChart = new ChartType();
			C.GroupingValues groupingValue;
			switch (areaChartSetting.areaChartType)
			{
				case AreaChartTypes.STACKED:
					groupingValue = C.GroupingValues.Stacked;
					break;
				case AreaChartTypes.PERCENT_STACKED:
					groupingValue = C.GroupingValues.PercentStacked;
					break;
				case AreaChartTypes.CLUSTERED_3D:
					groupingValue = C.GroupingValues.Standard;
					break;
				case AreaChartTypes.STACKED_3D:
					groupingValue = C.GroupingValues.Stacked;
					break;
				case AreaChartTypes.PERCENT_STACKED_3D:
					groupingValue = C.GroupingValues.PercentStacked;
					break;
				default:
					groupingValue = C.GroupingValues.Standard;
					break;
			}
			areaChart.Append(new C.Grouping { Val = groupingValue }, new C.VaryColors { Val = false });
			int seriesIndex = 0;
			chartDataGroupings.ForEach(Series =>
			{
				areaChart.Append(CreateAreaChartSeries(seriesIndex, Series));
				seriesIndex++;
			});
			C.DataLabels dataLabels = CreateAreaDataLabels(areaChartSetting.areaChartDataLabel);
			if (dataLabels != null)
			{
				areaChart.Append(dataLabels);
			}
			areaChart.Append(new C.AxisId { Val = CategoryAxisId });
			areaChart.Append(new C.AxisId { Val = ValueAxisId });
			return areaChart;
		}
	}
}
