namespace PAT.Application.Models.Authentication;
public readonly record struct ValidateTokenUserResponse(
          bool IsTokenValid
        );