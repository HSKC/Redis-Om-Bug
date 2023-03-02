using Redis.OM.Modeling;

namespace Redis.OM.Skeleton.Model;

[Document(StorageType = StorageType.Json, Prefixes = new []{"Document"})]
public class Document
{
    // Id Field, also indexed, marked as nullable to pass validation
    [RedisIdField] 
    [Indexed]
    public string? Id { get; set; }
    
    public string? Text { get; set; }
    
}