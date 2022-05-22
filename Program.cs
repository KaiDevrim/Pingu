using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using PinguBot.Commands;

public class Program
{
    private const UInt64 GuildId = 974523363231924234;
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
        discord.MessageCreated += AyushMessage;
            var slash = discord.UseSlashCommands();
        slash.RegisterCommands<RoleCommands>();
        await discord.ConnectAsync();
        await Task.Delay(-1);
    }

    private static async Task MemberAddedHandler(DiscordClient s, GuildMemberAddEventArgs e)
    {
        await e.Member.GrantRoleAsync(e.Guild.Roles.Values.FirstOrDefault(x => x.Id == 974526234086232104));
    }

    private static async Task AyushMessage(DiscordClient s, MessageCreateEventArgs e)
    {
        string[] EmojiNames =
        {
            ":shrimp:",
            ":fried_shrimp:",
            ":GemShrimp:",
            ":PepeShrimp:",
            ":WumpusShrimp:",
            ":goldshrimp:",
            ":shrimp_1:",
            ":shrimp_2:",
            ":shrimp_3:",
            ":shrimp_4:",
            ":shrimp_5:",
            ":shrimp_6:",
            ":shrimp_7:",
            ":shrimp_8:",
            ":shrimp_9:",
            ":shrimp_10:",
            ":shrimp_11:",

        };
        if (e.Author.Id == 589611658087891002)
        {
            foreach (string emoji in EmojiNames)
            {
                await Task.Delay(200);
                await e.Message.CreateReactionAsync(DiscordEmoji.FromName(s,emoji));
            }
        }
    }
}