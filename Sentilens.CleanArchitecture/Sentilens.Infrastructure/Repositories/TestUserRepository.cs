using Sentilens.Core.Entities;
using Sentilens.Core.Interfaces;

namespace Sentilens.Infrastructure.Repositories;
public class TestUserRepository : ITestUserRepository
{
    public Task<TestUser> GetTestUserByIdAsync(int id)
    {
        Console.WriteLine("Getting test user by id: " + id);
        // return dara from application db context
    }
};