using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }

        public IActionResult LineChartWithAxis() 
        {
            CanvasJsLineChartWithAxisResponseModel model = new CanvasJsLineChartWithAxisResponseModel
            {
				//Type = "line",
		  //      XValueFormatString = "DD MMM",
		  //      Color = "#F08080",
                DataPoints = new List<CanvasJsLineChartWithAxisModel>
                {
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 1) ,y = 610 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 2) ,y = 680 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 3) ,y = 690 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 4) ,y = 700 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 5) ,y = 710 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 6) ,y = 658 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 7) ,y = 734 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 8) ,y = 963 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 9) ,y = 1850 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 10) ,y = 1905 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 11) ,y = 1858 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 12) ,y = 1034 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 13) ,y = 847 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 14) ,y = 853 },
                    new CanvasJsLineChartWithAxisModel {x = new DateTime(2017, 1, 15) ,y = 750 }
                }
			};
            return View(model);
        }

        public IActionResult ErrorBarChart()
        {
            CanvasJsErrorBarChartResponseModel model = new CanvasJsErrorBarChartResponseModel
            {
                Datapoints1 = new List<CanvasJsErrorBarChartModel>
                {
                    new CanvasJsErrorBarChartModel { y = 94, label = "Order Accuracy" },
                    new CanvasJsErrorBarChartModel { y = 74, label = "Packaging" },
                    new CanvasJsErrorBarChartModel { y = 80, label = "Quantity" },
                    new CanvasJsErrorBarChartModel { y = 88, label = "Quality" },
                    new CanvasJsErrorBarChartModel { y = 76, label = "Delivery" }
                },
                Datapoints2 = new List<CanvasJsErrorBarChartModel>
                {
                    new CanvasJsErrorBarChartModel { y2 = new List<int> {92, 98}, label2 = "Order Accuracy" },
                    new CanvasJsErrorBarChartModel { y2 = new List<int> {70, 78}, label2 = "Packaging" },
                    new CanvasJsErrorBarChartModel { y2 = new List<int> {78, 75}, label2 = "Quantity" },
                    new CanvasJsErrorBarChartModel { y2 = new List<int> {85, 92}, label2 = "Quality" },
                    new CanvasJsErrorBarChartModel { y2 = new List<int> {72, 78}, label2 = "Delivery" }
                }
            };
            return View(model);
        }
    }
}
