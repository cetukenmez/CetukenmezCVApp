using System.Diagnostics;
using CetukenmezCVApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CetukenmezCVApp.Controllers;

public sealed class HomeController(CvProfile profile) : Controller
{
    public IActionResult Index() => View(profile);

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int? code)
    {
        var statusCode = code ?? Response.StatusCode;
        if (statusCode < 400) statusCode = 500;
        Response.StatusCode = statusCode;

        return View(new ErrorViewModel(statusCode, Activity.Current?.Id ?? HttpContext.TraceIdentifier));
    }
}
