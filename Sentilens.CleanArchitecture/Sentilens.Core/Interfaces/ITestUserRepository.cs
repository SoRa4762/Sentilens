using Sentilens.Core.Entities;

namespace Sentilens.Core.Interfaces;
public interface ITestUserRepository
{
    Task<TestUser> GetTestUserByIdAsync(int id);
}