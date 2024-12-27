using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.UoW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        ICommentRepository CommentRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IRoleRepository RoleRepository { get; }
        IScoreRepository ScoreRepository { get; }
        IUserRepository UserRepository { get; }
        Task Commit();
    }
}
