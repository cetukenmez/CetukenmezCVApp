namespace CetukenmezCVApp.Models;

public sealed record ErrorViewModel(int StatusCode, string? RequestId)
{
    public string Title => StatusCode switch
    {
        404 => "Page not found",
        _ => "Something went wrong"
    };

    public string Message => StatusCode switch
    {
        404 => "The page you are looking for does not exist or has moved.",
        _ => "An unexpected error occurred while processing your request."
    };
}
