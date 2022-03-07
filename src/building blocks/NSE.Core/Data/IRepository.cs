﻿using NSE.Core.DomainObjects;

namespace NSE.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAgregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
