var TestAutomationResultsAPIEndPoint = "http://localhost:65412/";
var FileUtilAPIEndPoint = "http://localhost:65412/";
var NumberOfDataSetsInDashboard = 7;

var DashBoardListGroup = [
  {
    Id: 1,
    item: "DevIntegration Regression",
    url: "DFS.RegDevIntegration",
    RunName: "RegressionSuite_",
    Default: "True",
  },
  {
    Id: 2,
    item: "DevIntegration Smoke",
    url: "DFS.RegDevIntegration",
    RunName: "SmokeSuite_",
    Default: "False",
  },
  {
    Id: 3,
    item: "Main Regression",
    url: "DFS.Main",
    RunName: "RegressionSuite_",
    Default: "False",
  },
  {
    Id: 4,
    item: "Main Smoke",
    url: "DFS.Main",
    RunName: "SmokeSuite_",
    Default: "False",
  },
];

var FileUtilOptions = [
  { EnumValue: "EncryptFile", Lable: "Encrypt File", Default: "True" },
  { EnumValue: "DecryptFile", Lable: "Decrypt File" },
  { EnumValue: "GeneratePapReturn", Lable: "Generate Pap Return" },
];
