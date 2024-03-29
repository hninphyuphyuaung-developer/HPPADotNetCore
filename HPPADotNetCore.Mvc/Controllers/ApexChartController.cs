﻿using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartModel model = new ApexChartPieChartModel 
            {
                Series = new List<int> { 44, 55, 13, 43, 22 },
                Labels = new List<string> { "Team A", "Team B", "Team C", "Team D", "Team E"}
            };
            return View(model);
        }

        public IActionResult CandleStickChart()
        {
            ApexChartCandleStickChartResponseModel model = new ApexChartCandleStickChartResponseModel
            {
                Data = new List<ApexChartCandleStickChartModel> 
                {
                    new ApexChartCandleStickChartModel {x = DateTime.Now.AddDays(1) ,y = new List<double> {6629.81, 6650.5, 6623.04, 6633.33}},
                    new ApexChartCandleStickChartModel {x = DateTime.Now.AddDays(2) ,y = new List<double> {6632.01, 6643.59, 6620, 6630.11}},
                    new ApexChartCandleStickChartModel {x = DateTime.Now.AddDays(3) ,y = new List<double> {6630.71, 6648.95, 6623.34, 6635.65}},
                    new ApexChartCandleStickChartModel {x = DateTime.Now.AddDays(4) ,y = new List<double> {6635.65, 6651, 6629.67, 6638.24}},
                    new ApexChartCandleStickChartModel {x = DateTime.Now.AddDays(5) ,y = new List<double> {6638.24, 6640, 6620, 6624.47}}
                }
            };
            return View(model);
        }

        public IActionResult ScatterChart()
        {
            ApexChartScatterChartResponseModel model = new ApexChartScatterChartResponseModel
            {
                Series = new List<ApexChartScatterChartModel>
                {
                    new ApexChartScatterChartModel{name = "SAMPLE A" ,data = new double[][]
                    { new double[] {16.4, 5.4},
                        new double[] {21.7, 2},
                        new double[] {25.4, 3},
                        new double[] { 19, 2 },
                        new double[] {10.9, 1},
                        new double[] {13.6, 3.2},
                        new double[] {21.7, 2},
                        new double[] {25.4, 3},
                        new double[] {19, 2},
                        new double[] {10.9, 1},
                        new double[] {13.6, 3.2},
                        new double[] {10.9, 7.4}
                    }},
                    new ApexChartScatterChartModel{name = "SAMPLE B" ,data = new double[][]
                    { new double[] {36.4, 13.4},
                        new double[] {1.7, 11},
                        new double[] { 5.4, 8 },
                        new double[] { 9, 17    },
                        new double[] { 1.9, 4 },
                        new double[] { 3.6, 12.2 },
                        new double[] { 1.4, 7 },
                        new double[] { 6.4, 8.8 },
                        new double[] { 3.6, 4.3 },
                        new double[] { 1.6, 10 },
                        new double[] { 9.9, 2 },
                        new double[] { 7.1, 15}
                    }},
                    new ApexChartScatterChartModel{name = "SAMPLE C" ,data = new double[][]
                    { new double[] { 23, 2 },
                        new double[] { 10.9, 3 },
                        new double[] { 28, 4    },
                        new double[] { 27.1, 0.3 },
                        new double[] {16.4, 4},
                        new double[] { 13.6, 0 },
                        new double[] {6.4, 8.8},
                        new double[] {28, 4},
                        new double[] {27.1, 0.3},
                        new double[] {13.6, 0},
                        new double[] {19, 5},
                        new double[] { 22.4, 3 }
                    }}
                }
            }; 
            return View(model);
        }
    }
}
