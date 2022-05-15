using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace PinguBot.Commands;
[SlashCommandGroup("role", "various role commands")]
public class RoleCommands : ApplicationCommandModule
{
    [SlashCommand("add", "adds a role")]
    public async Task Role(InteractionContext ctx, [Option("name", "role name to add")] string roleName)
    {
        await ctx.Guild.CreateRoleAsync(roleName);
        await response($"Added role to server, {roleName}", ctx);
    }
    [SlashCommand("set", "adds a role to yourself")]
    public async Task SetRole(InteractionContext ctx, [Option("name", "role name to add")] DiscordRole roleName)
    {
        await ctx.Member.GrantRoleAsync(roleName);
        await response($"You now have role: {roleName.Name}", ctx);
    }

    [SlashCommand("remove", "removes a role you have")]
    public async Task RemoveRole(InteractionContext ctx, [Option("name", "role name to remove")] DiscordRole roleName)
    {
        await ctx.Member.RevokeRoleAsync(roleName);
        await response($"Removed role {roleName.Name}", ctx);
    }

    public async Task response(string message, InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
            new DiscordInteractionResponseBuilder()
                .WithContent(message));
    }
}