﻿using System;
using CryptoWatcher.Domain.Builders;
using CryptoWatcher.Shared.Helpers;


namespace CryptoWatcher.Domain.Models
{
    public class Watcher : IEntity
    {
        public string Id => WatcherId;
        public string WatcherId { get; private set; }
        public string UserId { get; private set; }
        public string CurrencyId { get; private set; }
        public string IndicatorId { get; private set; }
        public decimal Value { get; private set; }
        public decimal Buy { get; private set; }
        public decimal Sell { get; private set; }
        public decimal AverageBuy { get; private set; }
        public decimal AverageSell { get; private set; }
        public bool Enabled { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime CreationTime { get; private set; }

        public WatcherStatus Status => WatcherBuilder.BuildStatus(Value, Buy, Sell);

        public Watcher() { }
        public Watcher(
            string userId,
            string currencyId,
            string indicatorId,
            decimal value,
            decimal buy,
            decimal sell,
            decimal averageBuy,
            decimal averageSell,
            bool enabled)
        {
            WatcherId = UrlHelper.BuildUrl(indicatorId, currencyId, userId); // Semantic id
            UserId = userId;
            CurrencyId = currencyId;
            IndicatorId = indicatorId;
            Value = value;
            Buy = buy;
            Sell = sell;
            AverageBuy = averageBuy;
            AverageSell = averageSell;
            Enabled = enabled;
            CreatedBy = userId;
            CreationTime = DateTime.Now;
        }

        public Watcher Update(decimal buy, decimal sell, bool enabled)
        {
            Buy = buy;
            Sell = sell;
            Enabled = enabled;

            return this;
        }
        public Watcher Sync(decimal value, decimal averageBuy, decimal averageSell)
        {
            Value = value;
            AverageBuy = averageBuy;
            AverageSell = averageSell;

            return this;
        }
    }
}
