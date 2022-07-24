using Core.Business;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService : IEntityService<Color, int>
    {
    }
}
