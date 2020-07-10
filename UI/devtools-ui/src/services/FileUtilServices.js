import http from "./HttpService.js";
import { toast } from "react-toastify";

export async function handleFileUpload(method, file) {
  try {
    const apiEndPoint = `${window.FileUtilAPIEndPoint}/api/FileUtil/${method}`;
    const data = new FormData();
    data.append("file", file);
    const response = await http.post(apiEndPoint, data);

    return response;
  } catch (error) {
    toast.error(error.response.data);
  }
}

export function handleDownload(base64, name) {
  try {
    var binary_string = window.atob(base64);
    var len = binary_string.length;
    var bytes = new Uint8Array(len);
    for (var i = 0; i < len; i++) {
      bytes[i] = binary_string.charCodeAt(i);
    }
    toast.info(`${name} download in progress`);

    var blob = new Blob([bytes], { type: "text/plain" });
    var link = document.createElement("a");
    link.href = window.URL.createObjectURL(blob);
    var fileName = name;
    link.download = fileName;
    link.click();
  } catch (error) {
    toast.error("Something went wrong during file download!!");
  }
}
