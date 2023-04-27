using DbUp;
using MikeCars.Infraestructure.Repository.Repositories.Internal;
using System.Reflection;

namespace MikeCars.Infraestructure.CrossCutting.Builders;

public static class DbUpBuider
{
    public static void BuildDatabaseMigration()
    {
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        EnsureDatabase.For.SqlDatabase(connectionString);

        var upgrader = 
            DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetAssembly(typeof(BaseRepository)), (string s) => s.EndsWith("sql"))
            .Build();

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
