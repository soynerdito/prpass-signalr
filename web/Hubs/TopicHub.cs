using Microsoft.AspNetCore.SignalR;

namespace asp_test.Hubs;

public class TopicHub : Hub
{
    public async Task SendTopicStatus(string topicName, string status)
    {
        await Clients.All.SendAsync("ReceiveTopicStatus", topicName, status);
    }

    public async Task SendTopicAction(string topicName, string action, object? data = null)
    {
        await Clients.All.SendAsync("ReceiveTopicAction", topicName, action, data);
    }

    public async Task SendIotMessage(IotMessage message)
    {
        await Clients.All.SendAsync("ReceiveIotMessage", message);
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
        await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
    }
}

public class IotMessage
{
    public string Destination { get; set; }
    public string Action { get; set; }
    public string Source { get; set; }
}