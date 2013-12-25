using System;

namespace Tqcsi.Qlkh.Web.Common.Security
{
    public interface IUserSession
    {
        int UserId { get; }
        string Firstname { get; }
        string Lastname { get; }
        string Username { get; }
        string Email { get; }
    }
}