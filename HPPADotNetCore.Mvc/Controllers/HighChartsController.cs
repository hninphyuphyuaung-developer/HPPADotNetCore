using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }

        public IActionResult AreaSplineChart()
        {
            HighChartsAreaSplineChartResponseModel model = new HighChartsAreaSplineChartResponseModel
            {
                Text = "Moose and deer hunting in Norway, 2000 - 2021",
                Series =new List<HighChartsAreaSplineChartModel> 
                { 
                    new HighChartsAreaSplineChartModel {name = "Moose", data = new List<int> 
                        {38000,37300,37892,38564,36770,36026,34978,35657,35620,35971,
                        36435,34643,34956,33199,31136,30835,31611,30666,30319,31766 } } ,

                    new HighChartsAreaSplineChartModel {name = "Deer", data = new List<int> 
                        {22534,23599,24533,25195,25896,27635,29173,32646,35686,37709,
                        39143,36829,35031,36202,35140,33718,37773,42556,43820,6445,50048 } }
                }
            };
            return View(model);
        }

        public IActionResult Chart3DBubblesChart()
        {
            HighCharts3DBubblesChartModel model = new HighCharts3DBubblesChartModel
            {
                data1 = new int[,]
                {
                    { 9, 81, 63 },
                    { 98, 5, 89 },
                    { 51, 50, 73 },
                    { 41, 22, 14 },
                    { 58, 24, 20 },
                    { 78, 37, 34 },
                    { 55, 56, 53 },
                    { 18, 45, 70 },
                    { 42, 44, 28 },
                    { 3, 52, 59 },
                    { 31, 18, 97 },
                    { 79, 91, 63 },
                    { 93, 23, 23 },
                    { 44, 83, 22 }
                },
                data2 = new int[,]
                {
                    { 42, 38, 20 },
                    { 6, 18, 1 },
                    { 1, 93, 55 },
                    { 57, 2, 90 },
                    { 80, 76, 22 },
                    { 11, 74, 96 },
                    { 88, 56, 10 },
                    { 30, 47, 49 },
                    { 57, 62, 98 },
                    { 4, 16, 16 },
                    { 46, 10, 11 },
                    { 22, 87, 89 },
                    { 57, 91, 82 },
                    { 45, 15, 98 }
                }
            };
            return View(model);
        }
    }
}
