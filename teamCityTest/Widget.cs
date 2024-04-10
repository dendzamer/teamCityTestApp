namespace teamCityTest;

public class Widget
{
    public required string Name { get; init; }
    public Guid Id { get; set; }
    public required string HtmlTag { get; init; }
    public List<WidgetVersion> Versions { get; set; } = [];

    public string? GetLatestVersion() => Versions.MaxBy(v => v.Version)?.Version;
}

public class WidgetVersion
{
    public required string Version { get; init; }
    public required string JsBundle { get; init; }
    public List<string> Styles { get; init; } = [];
}