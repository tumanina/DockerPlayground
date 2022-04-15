using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Users.Api.Models;
using Users.Data.Repositories;

namespace Users.Api.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMessageService _messageService;
        private readonly IUsersRepository _usersRepository;

        public UsersService(IMessageService messageService, IUsersRepository usersRepository)
        {
            _messageService = messageService;
            _usersRepository = usersRepository;
        }

        public void CreateUser(CreateUserModel user)
        {
            _messageService.Enqueue(JsonSerializer.Serialize(user));
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _usersRepository.GetUsers().Select(u => new UserModel { Id = u.Id, Name = u.Name, Email = u.Email });
        }
    }
}
