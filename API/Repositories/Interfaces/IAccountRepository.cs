using API.Models;
using API.ViewModels;

namespace API.Repositories.Interfaces;
// Membuat interface pada IAccount
public interface IAccountRepository : IGeneralRepository<Account, string>
{
    int Register (RegisterVM registerVM);
    bool Login (LoginVM loginVM);
}