using mcpservercsharpconsole.Database;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace mcpservercsharpconsole.McpTools;

[McpServerToolType]
public static class LibraryTools
{
    [McpServerTool, Description("Get list of books in the library")]
    public static async Task<string> GetBooks(MonkeyService monkeyService)
    {
        using var dbContext = new LibraryDbContext();
        return JsonSerializer.Serialize(await dbContext.Books.ToArrayAsync());
    }

    [McpServerTool, Description("Get members by name.")]
    public static async Task<string> GetMember(
        MonkeyService monkeyService, 
        [Description("The name of the member")] string name)
    {
        using var dbContext = new LibraryDbContext();
        return JsonSerializer.Serialize(
            await dbContext.Members
            .Where(x => x.LastName == name)
            .ToArrayAsync());
    }

    [McpServerTool, Description("Get list of members in the library.")]
    public static async Task<string> GetMembers(MonkeyService monkeyService)
    {
        using var dbContext = new LibraryDbContext();
        return JsonSerializer.Serialize(await dbContext.Members.ToArrayAsync());
    }
}
