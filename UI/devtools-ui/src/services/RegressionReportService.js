import http from "./HttpService.js";
import { toast } from "react-toastify";

const apiEndPoint = `${window.TestAutomationResultsAPIEndPoint}/api/TestAutomationResults/RegressionReport?runname=`;

export async function handleDownload(runName) {
  try {
    toast.info(`${runName} Report downloaded is in Progress`);
    const Endpoint = `${apiEndPoint}${runName}`;
    const response = await http.get(Endpoint);
    var fileName = `${runName}_report.xls`;
    var blob = new Blob([response.data], { type: "application/xls" });
    var link = document.createElement("a");
    link.href = window.URL.createObjectURL(blob);
    link.download = fileName;
    link.click();
  } catch (error) {
    toast.error("Something went wrong during file download!!");
  }
}
