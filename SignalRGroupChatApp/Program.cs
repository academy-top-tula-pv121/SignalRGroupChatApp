using Microsoft.AspNetCore.SignalR;
using SignalRGroupChatApp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR(o => o.AddFilter<ChatHubFilter>());
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


app.MapHub<ChatHub>("/chat");

app.Run();
