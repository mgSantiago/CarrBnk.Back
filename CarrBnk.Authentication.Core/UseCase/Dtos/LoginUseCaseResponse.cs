namespace CarrBnk.Authentication.Core.UseCase.Dtos
{
    public record LoginUseCaseResponse(String Username, String Role, String Token);
}
