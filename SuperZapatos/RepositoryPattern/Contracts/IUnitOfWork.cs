﻿using System;
using System.Data.Entity;

namespace SuperZapatos.RepositoryPattern.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Return the database reference for this UOW
        /// </summary>
        DbContext Db { get; }

        /// <summary>
        /// Call this to commit the unit of work
        /// </summary>
        void Commit();

        /// <summary>
        /// Starts a transaction on this unit of work
        /// </summary>
        void StartTransaction();
    }
}