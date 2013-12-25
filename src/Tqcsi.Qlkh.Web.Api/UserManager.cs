using Tqcsi.Qlkh.Data;
using Tqcsi.Qlkh.Web.Api.Models;
using Tqcsi.Qlkh.Web.Api.TypeMappers;
using Tqcsi.Qlkh.Web.Common.Security;

namespace Tqcsi.Qlkh.Web.Api
{
    public class UserManager : IUserManager
    {
        private readonly IMembershipInfoProvider _membershipAdapter;
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserManager(IMembershipInfoProvider membershipAdapter, IUserRepository userRepository, IUserMapper userMapper)
        {
            _membershipAdapter = membershipAdapter;
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public User CreateUser(string username, string password, string firstname, string lastname, string email)
        {
            var userId = _membershipAdapter.CreateUser(username, password, firstname, lastname, email);

            var user = _userMapper.CreateUser(username, firstname, lastname, email, userId);

            return user;
        }
    }
}