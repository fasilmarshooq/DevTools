import http from "./HttpService.js";

const apiEndPoint = `${window.TestAutomationResultsAPIEndPoint}/api/TestAutomationResults/ScenarioStatus?runname=`;

export async function GetScenarioStatus(runName) {
  try {
    const endPoint = `${apiEndPoint}${runName}`;

    const response = await http.get(endPoint);

    return response.data;
  } catch (error) {
    return {};
  }
}
