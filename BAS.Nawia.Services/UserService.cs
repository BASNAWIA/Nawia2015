using AutoMapper;
using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Common.Models;
using BAS.Nawia.DAL.Entities;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Services
{
    public class UserService : BaseService, IUserService
    {
        private IUnitOfWork unitOfWork = null;

        public UserService(IUnitOfWork uow)
            : base(uow)
        {
            this.unitOfWork = uow;
        }

        public ICollection<Common.Models.UserModel> GetAll()
        {
            var userrepo = unitOfWork.Repository<User>();
            var users = userrepo.Queryable().ToList();
            var usersreturn = Mapper.Map<ICollection<User>, ICollection<UserModel>>(users);
            return usersreturn;
        }

        public Common.Models.UserModel Get(string _id)
        {
            var userrepo = unitOfWork.Repository<User>();
            var user = userrepo.Queryable().Where(userid => userid.Id == _id);
            if (user == null)
                throw new ArgumentException("User not found");
            UserModel usermodel = Mapper.Map<User, UserModel>(user.FirstOrDefault());
            return usermodel;
        }

        public UserModel GetByUsername(string username)
        {
            var userrepo = unitOfWork.Repository<User>();
            var user = userrepo.Queryable().Where(user2 => user2.UserName == username);
            if (user == null)
                throw new ArgumentException("User not found");
            UserModel usermodel = Mapper.Map<User, UserModel>(user.FirstOrDefault());
            return usermodel;
        }

        public void UpdateUser(Common.Models.UserModel User)
        {
            var userrepo = unitOfWork.Repository<User>();
            var userquery = userrepo.Queryable().Where(userid => userid.Id == User.Id);
            if (userquery == null)
                throw new ArgumentException("User not found");
            User usertoupdate = userquery.FirstOrDefault();
            usertoupdate.Email = User.Email;
            usertoupdate.EmailConfirmed = User.EmailConfirmed;
            usertoupdate.IsConfirmed = User.IsConfirmed;
            usertoupdate.Name = User.Name;
            usertoupdate.LastName = User.LastName;
            usertoupdate.Title = User.Title;
            base.Transaction(() =>
            {
                userrepo.Update(usertoupdate);
            });
        }


        public ICollection<UserModel> GetUsersByRole(string _id)
        {
            var userrepo = unitOfWork.Repository<User>();
            var userrolesrepo = unitOfWork.Repository<UserRoles>();
            var usersids = userrolesrepo.Queryable().Where(roleid => roleid.RoleId == _id).ToList();
            var users = new List<User>();
            foreach (var i in usersids)
            {
                var user = userrepo.Queryable().Where(userid => userid.Id == i.UserId).First();
                if (user != null)
                {
                    users.Add(user);
                }
            }
            var usersreturn = Mapper.Map<ICollection<User>, ICollection<UserModel>>(users);
            return usersreturn;
        }
    }
}