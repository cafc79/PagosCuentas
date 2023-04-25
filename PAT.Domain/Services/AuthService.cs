using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PAT.Common.Extensions;
using PAT.Common.Interfaces;
using PAT.Domain.Interfaces;
using PAT.Domain.Models.UserManagement;
using PAT.Models.Database.Tablas;
using PAT.Models.Identity;

namespace PAT.Domain.Services;

public class AuthService : IAuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly SignInManager<PATUser> _signInManager;
    private readonly ISqlRepository<DbContext> _sqlRepository;
    private readonly UserManager<PATUser> _userManager;

    public AuthService(
        ILogger<AuthService> logger,
        ISqlRepository<DbContext> sqlRepository,
        SignInManager<PATUser> signInManager,
        UserManager<PATUser> userManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _sqlRepository = sqlRepository;
        _userManager = userManager;
    }

    public async Task<string> GetNombrePila(string email)
    {
        var usr = await _userManager.FindByEmailAsync(email);
        return usr.NombrePila;
    }
    public async Task<string> GetUsuarioId(string email)
    {
        var usr = await _userManager.FindByEmailAsync(email);
        return usr.Id;
    }

    public async Task<List<string>> GetUserRoles(string email)
        => await _userManager.FindByEmailAsync(email)
            .FlatMap(_userManager.GetRolesAsync)
            .Map(r => r.ToList());

    public async Task<AuthenticateResult> Authenticate(string email, string password)
    {
        var r = await SignInInternal(email, password);
        if (r.User is null)
        {
            _logger.LogInformation(
                "Authentication challenge complete for {Email}. Success: {Success}, LockedOut: {LockedOut}, NotAllowed: {NotAllowed}, DoesNotExist: {DoesNotExist}",
                email, false, false, false, true);
            return r;
        }

        _logger.LogInformation(
            "Authentication challenge complete for {Email}. Success: {Success}, LockedOut: {LockedOut}, NotAllowed: {NotAllowed}",
            email,
            r.Result!.Succeeded,
            r.Result!.IsLockedOut,
            r.Result!.IsNotAllowed);
        return r;
    }

    public async Task SaveJwtToken(
        string email,
        string token,
        string remoteAddress,
        DateTime expirationDate)
        => await new ABCJwtTokenUsuario(email, token, remoteAddress, expirationDate)
            .MapV(userToken => _sqlRepository.CreateAsync(userToken));

    private async Task<AuthenticateResult> SignInInternal(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is not null && user.Activo)
            return new(user,
                await _signInManager.CheckPasswordSignInAsync(user, password, false));
        else
            return new(null, null);
    }
    public async Task<bool> ValidateJwtTokenLogIn(string email, string token)
    {
        var userList = await _sqlRepository.QueryAsync<ABCJwtTokenUsuario>(d => d.Correo.Equals(email) && d.Token .Equals(token) );
        if (userList.Count==0)
            return false;
        else
         return !userList.First().Eliminado;
    }
    public async Task<RevokeTokenLogInResult> RevokeJwtTokenLogIn(string email,string tokenLogIn)
    {

        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@Email",
                            Value = email
                        },
                        new SqlParameter() {
                            ParameterName = "@Token",
                            Value = tokenLogIn
                        }
            };

        var data = await _sqlRepository.InsertUpdateByStore("stp_ABC_RevocarJwtTokenLogin",
          param);
        return new(data>0, new List<string>());
    }
}
