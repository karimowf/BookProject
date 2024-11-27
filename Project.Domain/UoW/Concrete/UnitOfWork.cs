using Project.Domain.UoW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.UoW.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext context;

        public UnitOfWork(BookDbContext context)
        {
            this.context = context;

            BookRepository = new BookRepository(this.context);
            CommentRepository = new CommentRepository(this.context);
            PaymentRepository = new PaymentRepository(this.context);
            RoleRepository = new RoleRepository(this.context);
            ScoreRepository = new ScoreRepository(this.context);
            UserRepository = new UserRepository(this.context);
        }

        public IBookRepository BookRepository { get; private set; }

        public ICommentRepository CommentRepository { get; private set; }

        public IPaymentRepository PaymentRepository { get; private set; }

        public IRoleRepository RoleRepository { get; private set; }

        public IScoreRepository ScoreRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public async Task Commit()
        {
            using (var tr = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    await context.SaveChangesAsync();

                    await tr.CommitAsync();
                }
                catch (Exception ex)
                {
                    tr.Rollback();

                    throw new Exception(ex.Message);
                }
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
