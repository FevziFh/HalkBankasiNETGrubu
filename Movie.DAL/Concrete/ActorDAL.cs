using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Movie.DAL.Contexts;
using Movie.DAL.Interfaces;
using Movie.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DAL.Concrete
{
    public class ActorDAL : BaseDAL<Actor>, IActorDAL
    {
        public ActorDAL(FilmContext filmContext) : base (filmContext)
        {
        }

        public void GetActor(Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
