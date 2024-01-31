using FashionHexa.Database;
using FashionHexa.Entities;
using FashionHexa.Services;
namespace FashionHexa.Services
{
    public class UnitOfWork
    {
        MyContext context = null;
        CartImpl cartImpl = null;

        public UnitOfWork(MyContext ctx)
        {
            context = ctx;
        }

        public CartImpl CartImplObject
        {
            get
            {
                if(cartImpl == null)
                {
                    cartImpl = new CartImpl(context);
                }
                return cartImpl;
            }
        }

        public void SaveAll()
        {
            if(context != null)
            {
                context.SaveChanges();
            }
        }
    }
}
