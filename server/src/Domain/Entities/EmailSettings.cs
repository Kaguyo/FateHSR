using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace server.src.Domain.Entities;

public class EmailSettings
{
    public string SmtpServer { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; } = string.Empty;
    public string SmtpPass { get; set; } = string.Empty;
    public string FromEmail { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;

    public EmailSettings()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var section = config.GetSection("EmailSettings");

        SmtpServer = section["SmtpServer"]!;
        SmtpPort = int.Parse(section["SmtpPort"] ?? "0");
        SmtpUser = section["SmtpUser"]!;
        SmtpPass = section["SmtpPass"]!;
        FromEmail = section["FromEmail"]!;
        BaseUrl = section["BaseUrl"]!;

        Console.WriteLine(this);
    }

    public override string ToString()
    {
        string s = $"SmtpServer: {SmtpServer}\n" +
                   $"SmtpPort: {SmtpPort}\n" +
                   $"SmtpUser: {SmtpUser}\n" +
                   $"FromEmail: {FromEmail}\n" +
                   $"BaseUrl: {BaseUrl}";

        return s;
    }
}

