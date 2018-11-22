﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoWatcher.Domain.Models;

namespace CryptoWatcher.Domain.Repositories
{
    public interface IWatcherRepository : IRepository<Watcher>
    {
        Task<List<Watcher>> GetByUserId(string userId);
    }
}