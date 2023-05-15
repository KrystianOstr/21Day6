using Azure;
using Azure.Data.Tables;

var connectionString = "DefaultEndpointsProtocol=https;AccountName=voleyballsa;AccountKey=lLYGo8/u/eXeE01YgLxzxVyKF6r6Q3GIO7MUKMZwT3XKXHH3PrdKbJaGgRlkyXxQFangUHUjxQMp+ASteJz/HQ==;EndpointSuffix=core.windows.net";


string tableName = "Persons";

var tableClient = new TableClient(connectionString, tableName);

//Azure.Data.Tables 

// Create a table in your storage account
await tableClient.CreateIfNotExistsAsync();

//// Insert an entity into the table
//var entity = new TableEntity("volleyball", "player6")
//            {
//                { "firstname", "john" },
//                { "country", "brasil" },
//                { "phonenumber", "123456" },
//            };
//await tableClient.AddEntityAsync(entity);
//Console.WriteLine("Entity added to the table.");


// Query entities from the table
//var entity = new TableEntity("volleyball", "player6");
//string partitionKeyFilter = $"PartitionKey eq '{entity.PartitionKey}'";
//await foreach (var e in tableClient.QueryAsync<TableEntity>(partitionKeyFilter))
//{
//    Console.WriteLine($"" +
//        $"PartitionKey: {e.PartitionKey}, " +
//        $"RowKey: {e.RowKey}, " +
//        $"Property1: {e.GetString("country")}, " +
//        $"Property2: {e.GetString("firstname")}, " +
//        $"Property3: {e.GetString("lastname")}, " +
//        $"Property4: {e.GetString("phonenumber")}, +" +
//        $"Property5: {e.GetDateTime("databirth")}");
//}

// updating 
//var entity = new TableEntity("volleyball", "player6");
//entity["country"] = "NewValue1";
//await tableClient.UpdateEntityAsync(entity, ETag.All);
//Console.WriteLine("Entity updated in the table.");

// deleting 
var entity = new TableEntity("volleyball", "player6");
await tableClient.DeleteEntityAsync(entity.PartitionKey, entity.RowKey);
Console.WriteLine("Entity deleted from the table.");

