using System;
namespace PAT.Application.Models.EgressManagement;

public readonly record struct AmountsEgressManagementRequest(
    string JwtToken,
    DateTime fecha
);