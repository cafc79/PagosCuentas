namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct ChangeStatusIndicatorRequest
  (
         string JwtToken,
         string UserId,
         decimal Amount,
         bool Activate
        );
}
