using Microsoft.AspNetCore.SignalR;

namespace FaceDetectionApp.Hubs
{
    public class VideoHub : Hub
{
    private readonly FaceService _faceService;

    public VideoHub(FaceService faceService)
    {
        _faceService = faceService;
    }

    public async Task SendFrame(string imageData)
    {
        var imageBytes = Convert.FromBase64String(imageData.Split(',')[1]);
        var result = await _faceService.DetectFaceAsync(imageBytes);
        await Clients.Caller.SendAsync("ReceiveExpression", result);
    }
}
}