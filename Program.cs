using GameStore.Api.Dtos;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

//constant
        const string GetGameEndpointName = "GetGame";

        List<GameDto> games =[
            new(1, "Final Fantasy", "Roleplaying", 59.99M, new DateOnly(2010,9,30)),
            new(2, "FIFA", "Sports", 69.99M, new DateOnly(2022,9,27)), 

        ];
        //GET/games
        app.MapGet("games", () => games);

        //GET/games/1
        app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));

        //POST/games
        app.MapGet("games",(CreateGameDto newGame) =>{
            GameDto game=new(games.Count+1,
            newGame.Name,newGame.Genre,newGame.Price,newGame.ReleaseDate);

            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndpointName, new{
                id=game.Id}, game);
            });

        

        app.Run();
    }
}