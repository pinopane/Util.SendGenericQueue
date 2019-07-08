=============Example to use==============

//Init Settings

var settings = new AzureQueueSettings(config["ServiceBus_ConnectionString"],config["ServiceBus_QueueName"]);

//Model

var model = new entityModel {};

//Create instance (T--> entityModel) & pass settings.

IAzureQueueSender<entityModel> sender = new AzureQueueSender<entityModel>(settings);
  
//Call send Queue

await sender.SendAsync(model);
