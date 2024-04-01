var builder = WebApplication.CreateBuilder(args);

// Azure Key Vault'tan sırları almak için yapılandırma ekleme
builder.Configuration.AddAzureKeyVault(
    $"https://sonkey.vault.azure.net/",  // Azure Key Vault URL'si
    "b00f8ec2-d3ea-474c-b19a-e5e796c97910",  // Azure AD Uygulama Kimliği
    "EthemBayraktar2002");        // Azure AD Uygulama Şifresi

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/hello", () => "Hello World!");

app.Run();
app.Run();