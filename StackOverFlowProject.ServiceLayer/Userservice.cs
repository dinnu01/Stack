using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverFlowProject.DomainModels;
using StackOverFlowProject.ViewModels;
using AutoMapper;
namespace StackOverFlowProject.ServiceLayer
{
    public interface IUserService
    {
        int Insertuser(RegisterViewModel uvm);

    }
    public class Userservice : IUserService
    {
        IUsersRepository ur;

        public Userservice()
        {

            ur = new UsersRepository();
        }
        public int Insertuser(RegisterViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<RegisterViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<RegisterViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GeneraterHash(uvm.Password);
            ur.InsertUser(u);
            int id=ur.GetLatestUserID();
            return id;
        }
    }
}
