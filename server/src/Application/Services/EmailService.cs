using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using server.src.Domain.Entities;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;
    private readonly string _jwtSecret;

    public EmailService(IOptions<EmailSettings> settings, IOptions<JwtSettings> jwtSecret)
    {
        _settings = settings.Value;
        _jwtSecret = jwtSecret.Value.Secret;
    }

    public string GenerateToken(string userEmail)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, userEmail)
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public void SendEmailWithToken(string toEmail)
    {
        var token = GenerateToken(toEmail);

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("NoReply", _settings.FromEmail));
        message.To.Add(MailboxAddress.Parse(toEmail));
        message.Subject = "Your verification token";

        var link = $"{_settings.BaseUrl}?token={token}";

        message.Body = new TextPart("html")
        {
            Text = $"Please click <a href=\"{link}\">this link</a> to verify your account. This link expires in 5 minutes."
        };

        using var client = new SmtpClient();

        // For demo, connect without SSL first, change if needed
        client.Connect(_settings.SmtpServer, _settings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);

        // Authenticate if needed
        client.Authenticate(_settings.SmtpUser, _settings.SmtpPass);

        client.Send(message);
        Console.WriteLine(token);
        client.Disconnect(true);
    }
}
