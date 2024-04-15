using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

public class MyPlaywrightTest
{
    [Test]
    public async Task BasicTest()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.example.com");
        Assert.AreEqual("Example Domain", await page.TitleAsync());
    }
}