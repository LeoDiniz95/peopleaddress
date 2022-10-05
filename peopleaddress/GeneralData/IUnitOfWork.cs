﻿namespace peopleaddress.GeneralData
{
    public interface IUnitOfWork: IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
