﻿namespace Otal.lmaoo.Data.Interfaces.Base
{
    public interface IDaoBase<T>
    {
        T Create(T TObject);

        T GetById(int id);

        T Update(T TObject, int id);

        void Delete(int id);
    }
}