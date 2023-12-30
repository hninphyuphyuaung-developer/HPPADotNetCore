using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();

        }

        public IActionResult HorizontalBarChart()
        {
            return View();
        }

        public IActionResult MultiAxisLineChart()
        {
            ChartJsMultiAxisLineChartResponseModel model =new ChartJsMultiAxisLineChartResponseModel
            {
                DataCount = 7,
                Labels = new List<string> {"January",
                            "February",
                            "March",
                            "April",
                            "May",
                            "June",
                            "July"},
                Datasets = new List<ChartJsMultiAxisLineChartModel> 
                { 
                    new ChartJsMultiAxisLineChartModel 
                    {
                        label = "Dataset1",
                        data = Enumerable.Range(1, 7).Select(x => GenerateData (1, 100)).ToList(),
                        borderColor = "rgb(255, 99, 132)",
                        backgroundColor = "rgb(255, 99, 132)",
                        yAxisID = "y"
                    },
                    new ChartJsMultiAxisLineChartModel
                    {
                        label = "Dataset2",
                        data = Enumerable.Range(1, 7).Select(x => GenerateData (1, 100)).ToList(),
                        borderColor = "rgb(0, 191, 255)",
                        backgroundColor = "rgb(0, 191, 255)",
                        yAxisID = "y1"
                    }
                }
            };
            return View(model);
        }

        private int GenerateData(int from, int to)
        {
            Random random = new Random();
            return random.Next(from, to);
        }
    }
}
