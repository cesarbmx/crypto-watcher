﻿using System;
using System.Linq.Expressions;
using CryptoWatcher.Domain.Models;

namespace CryptoWatcher.Domain.Expressions
{
    public static class IndicatorExpression
    {
        public static Expression<Func<Indicator, bool>> Indicator(string indicatorId)
        {
            return x => x.IndicatorId == indicatorId;
        }
        public static Expression<Func<Indicator, bool>> IndicatorFilter(string userId = null, IndicatorType ? indicatorType = null)
        {
            return x => (string.IsNullOrEmpty(userId) || x.UserId == userId) &&
                        (!indicatorType.HasValue || x.IndicatorType == indicatorType);
        }       
    }
}
