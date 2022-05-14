using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

public class Program
{
    private const long guildId = 974523363231924234;
    private static string token = File.ReadAllText("../../../.env");
    static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

    static async Task MainAsync()
    {
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All
        });
        discord.GuildMemberAdded += MemberAddedHandler;
        await discord.ConnectAsync();
        Console.WriteLine("????");
        await Task.Delay(-1);
    }

    private static async Task MemberAddedHandler(DiscordClient s, GuildMemberAddEventArgs e)
    {
        Console.WriteLine("232323");
        await e.Member.GrantRoleAsync(e.Guild.Roles.Values.FirstOrDefault(x => x.Id == 974526234086232104));
    }
}