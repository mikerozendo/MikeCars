namespace MikeCars.Tests.Utils;

public static class UserSecretsBuilder<T> where T : class
{
    public static string Build()
    {
        var builder = new ConfigurationBuilder()
        .AddUserSecrets<T>();

        var configuration = builder.Build();

        string cpfStoredInUserSecret = configuration["Config:CpfValidoTests"].ToString();
        
        return cpfStoredInUserSecret;
    }
}
