using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.WindowsAzure.Storage;

var connectionString = "DefaultEndpointsProtocol=https;AccountName=voleyballsa;AccountKey=lLYGo8/u/eXeE01YgLxzxVyKF6r6Q3GIO7MUKMZwT3XKXHH3PrdKbJaGgRlkyXxQFangUHUjxQMp+ASteJz/HQ==;EndpointSuffix=core.windows.net";

var shareName = "pictures";


var storageAccount = CloudStorageAccount.Parse(connectionString);
var fileClient = storageAccount.CreateCloudFileClient();
var share = fileClient.GetShareReference(shareName);
var rootDirectory = share.GetRootDirectoryReference();

Console.WriteLine("Enter the file path of the image to upload:");
var imagePath = Console.ReadLine();

using var fileStream = File.OpenRead(imagePath);
var fileName = Path.GetFileName(imagePath);

var file = rootDirectory.GetFileReference(fileName);
await file.UploadFromStreamAsync(fileStream);

Console.WriteLine($"Image '{imagePath}' uploaded successfully to the File Share.");

Console.WriteLine("Enter the name of the image to download from the File Share:");
var imageNameToDownload = Console.ReadLine();

var downloadFile = rootDirectory.GetFileReference(imageNameToDownload);
Console.WriteLine("Enter the destination file path to save the downloaded image:");
var destinationPath = Console.ReadLine();

using var downloadFileStream = File.OpenWrite(destinationPath);
await downloadFile.DownloadToStreamAsync(downloadFileStream);

Console.WriteLine($"Image '{imageNameToDownload}' downloaded successfully from the File Share and saved to '{destinationPath}'.");