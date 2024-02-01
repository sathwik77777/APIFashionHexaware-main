using FashionHexa.Database;
using FashionHexa.Entities;
using FashionHexa.Services;
using System.Security.Policy;

namespace FashionHexa.Services
{
    public class UnitOfWork
    {
        MyContext context = null;
        CartImpl cartImpl = null;
        /*ProductImpl productImpl = null;*/

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

        /*public ProductImpl ProductImplObject
        {
            get
            {
                if (productImpl == null)
                {
                    productImpl = new ProductImpl(context);
                }
                return productImpl;
            }
            
                
        }*/

        public void SaveAll()
        {
            if(context != null)
            {
                context.SaveChanges();
            }
        }
    }
}
