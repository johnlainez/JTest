using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
[Test]
public async Task MyTest()
{
await Page.GotoAsync("https://buggy.justtestit.org/");

//Start of Register
await Page.GetByRole(AriaRole.Link, new() { Name = "Register" }).ClickAsync();
await Page.GetByLabel("Login").ClickAsync();
await Page.GetByLabel("Login").FillAsync("johnTest125466"); // Change this
await Page.GetByLabel("First Name").ClickAsync();
await Page.GetByLabel("First Name").FillAsync("john");
await Page.GetByLabel("Last Name").ClickAsync();
await Page.GetByLabel("Last Name").FillAsync("test");
await Page.GetByLabel("Password", new() { Exact = true }).ClickAsync();
await Page.GetByLabel("Password", new() { Exact = true }).FillAsync("Test123.,");
await Page.GetByLabel("Confirm Password").ClickAsync();
await Page.GetByLabel("Confirm Password").FillAsync("Test123.,");
await Page.GetByRole(AriaRole.Button, new() { Name = "Register" }).ClickAsync();
await Expect(Page.GetByText("Registration is successful")).ToBeVisibleAsync();

//Start of Login Test
await Page.GetByPlaceholder("Login").ClickAsync();
await Page.GetByPlaceholder("Login").FillAsync("johntestxx");
await Page.GetByRole(AriaRole.Navigation).Locator("input[name=\"password\"]").ClickAsync();
await Page.GetByRole(AriaRole.Navigation).Locator("input[name=\"password\"]").FillAsync("Test123.,");
await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Logout" })).ToBeVisibleAsync();

//Start of Add additional info
await Page.GetByRole(AriaRole.Link, new() { Name = "Profile" }).ClickAsync();
await Page.GetByLabel("Gender").ClickAsync();
await Page.GetByLabel("Gender").FillAsync("Male");
await Page.GetByLabel("Age", new() { Exact = true }).ClickAsync();
await Page.GetByLabel("Age", new() { Exact = true }).FillAsync("22");
await Page.GetByLabel("Address").ClickAsync();
await Page.GetByLabel("Address").FillAsync("Test ADdress");
await Page.GetByLabel("Phone").ClickAsync();
await Page.GetByLabel("Phone").FillAsync("3849234234234");
await Page.GetByLabel("Hobby").SelectOptionAsync(new[] { "Working" });
await Page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
await Expect(Page.GetByText("The profile has been saved").First).ToBeVisibleAsync();

//Start of Logout Test
await Page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
await Expect(Page.GetByRole(AriaRole.Button, new() { Name = "Login" })).ToBeVisibleAsync();

}
}