using Redis.OM;
using Redis.OM.Skeleton.HostedServices;
using Redis.OM.Skeleton.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(new RedisConnectionProvider(builder.Configuration["REDIS_CONNECTION_STRING"]));
builder.Services.AddHostedService<IndexCreationService>();

var app = builder.Build();

var redisConnectionProvider = app.Services.GetRequiredService<RedisConnectionProvider>();

var guid = Guid.NewGuid().ToString();

var document = new Document
{
    Id = guid,
    Text = "Whatever"
};
    
var collection = redisConnectionProvider.RedisCollection<Document>();

await collection.InsertAsync(document);

await collection.SaveAsync();

await collection.FindByIdAsync(guid);

document.Text = "Whatever \"";

await collection.UpdateAsync(document);

await collection.SaveAsync();

app.Run();