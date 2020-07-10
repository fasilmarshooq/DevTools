import http from "./HttpService.js";

const apiEndPoint = `${window.TestAutomationResultsAPIEndPoint}/api/TestAutomationResults/TestAutomationResults?`;

export async function GetChartData(Url, RunName) {
  try {
    const endPoint = `${apiEndPoint}runname=${RunName}&url=${Url}&datasetcount=${window.NumberOfDataSetsInDashboard}`;

    const response = await http.get(endPoint);

    const chartData = {
      data: {
        labels: response.data.Labels,

        datasets: [
          {
            label: "Passed",
            backgroundColor: "rgba(44, 223, 44, 0.3)",
            borderColor: "rgba(44, 223, 44,1)",
            borderWidth: 2,

            data: response.data.PassedCounts,
          },
          {
            label: "Failed",
            backgroundColor: "rgba(223, 110, 110, 0.3)",
            borderColor: "rgba(255,99,132,1)",
            borderWidth: 2,

            data: response.data.FailedCounts,
          },
        ],
      },
      options: {
        scales: {
          xAxes: [
            {
              stacked: true,
              barThickness: 45,
              ticks: {
                callback: function (label) {
                  return label.split(/_(.+)/);
                },
              },
              gridLines: {
                color: "rgba(0,0,0,0.5)",
                lineWidth: 1,
                drawBorder: true,
                borderDash: [5],
              },
            },
          ],
          yAxes: [
            {
              stacked: true,
              ticks: {
                fontColor: "#a3a3a3",
                beginAtZero: true,
              },
              gridLines: {
                display: false,
              },
            },
          ],
        },

        legend: {
          labels: {
            fontColor: "#a3a3a3",
          },
        },
      },
      AverageTimeTaken: response.data.AverageTimeTaken,
      TimeTakenForLastExecution: response.data.TimeTakenForLastExecution,
      AverageFailures: response.data.AverageFailures,
    };
    return chartData;
  } catch (ex) {
    return {};
  }
}
