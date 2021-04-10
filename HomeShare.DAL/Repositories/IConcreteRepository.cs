﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL.Repositories
{
    public interface IConcreteRepository<T>
    {
        bool Insert(T toInsert);
        bool Update(T toUpdate);
        bool Delete(T toDelete);
        List<T> Get();

        T GetOne(int PK);
        bool InsertBienDB(HomeShare.Entities.AjoutBienEntity abe);
    }
}
