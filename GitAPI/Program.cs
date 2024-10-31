var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Entertainment> games = new List<Entertainment>()
{
    new Entertainment(2004, "ads", 21000, "lfgh", "msdad"),
    new Entertainment(2005, "sds", 22000, "kfgh", "nsdad"),
    new Entertainment(2006, "dds", 23000, "jfgh", "bsdad"),
    new Entertainment(2007, "fds", 24000, "hfgh", "vsdad")
};

app.MapGet("/", () =>
{
    return Results.Json(games);
});

app.MapPost("/", (Entertainment game) => games.Add(game));

app.MapPut("/{Title}", (string title, ChangesDTO change) =>
{
    Entertainment buff = games.Find(a => a.Title == title);
    buff.Price = change.Price;
    buff.Description = change.Description;
    return Results.Json(buff);
});


app.Run();

record class ChangesDTO(int Price, string Description);

class Entertainment
{
    int year;
    string title;
    int price;
    string company;
    string description;

    public Entertainment(int year, string title, int price, string company, string description)
    {
        Year = year;
        Title = title;
        Price = price;
        Company = company;
        Description = description;
    }

    public int Year { get => year; set => year = value; }
    public string Title { get => title; set => title = value; }
    public int Price { get => price; set => price = value; }
    public string Company { get => company; set => company = value; }
    public string Description { get => description; set => description = value; }
}
