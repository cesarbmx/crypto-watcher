﻿using System;
using System.Linq;
using AutoMapper;
using CesarBmx.Shared.Application.Responses;
using CesarBmx.Shared.Common.Extensions;
using CesarBmx.Shared.Domain.Entities;
using CoinpaprikaAPI.Entity;
using Microsoft.Extensions.DependencyInjection;
using CryptoWatcher.Application.Responses;
using CryptoWatcher.Domain.Models;
using Version = CryptoWatcher.Domain.Models.Version;

namespace CryptoWatcher.Api.Configuration
{
    public static class AutomapperConfig
    {
        public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(

                 cfg => {

                    // Responses
                    cfg.CreateMap<Version, VersionResponse>();
                     cfg.CreateMap<Health, HealthResponse>();
                     cfg.CreateMap<Version, VersionResponse>()
                         .ForMember(dest => dest.BuildDateTime, opt => opt.MapFrom(src => src.LastBuild.ToString("yyyy/MM/dd HH:mm")))
                         .ForMember(dest => dest.LastBuildOccurred, opt => opt.MapFrom(src => src.LastBuild.DaysHoursMinutesAndSecondsSinceDate()));
                     cfg.CreateMap<Health, HealthResponse>();
                     cfg.CreateMap<Currency, CurrencyResponse>();
                     cfg.CreateMap<Log, LogResponse>();
                     cfg.CreateMap<Watcher, WatcherResponse>();
                     cfg.CreateMap<User, UserResponse>();
                     cfg.CreateMap<Notification, NotificationResponse>();
                     cfg.CreateMap<Order, OrderResponse>();
                     cfg.CreateMap<Indicator, IndicatorResponse>()
                         .ForMember(dest => dest.Dependencies, opt => opt.MapFrom(src => src.Dependencies.Select(x => x.DependencyId).ToArray()));
                     cfg.CreateMap<Line, LineResponse>();
                     cfg.CreateMap<LineChart, LineChartResponse>();

                    // Others
                    cfg.CreateMap<TickerWithQuotesInfo, Currency>()
                         .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.Id))
                         .ForMember(dest => dest.Price, opt => opt.MapFrom(src => Convert.ToDecimal(src.Quotes["USD"].Price)))
                         .ForMember(dest => dest.Volume24H, opt => opt.MapFrom(src => Convert.ToDecimal(src.Quotes["USD"].Volume24H)))
                         .ForMember(dest => dest.MarketCap, opt => opt.MapFrom(src => Convert.ToDecimal(src.Quotes["USD"].MarketCap)))
                         .ForMember(dest => dest.PercentageChange24H, opt => opt.MapFrom(src => Convert.ToDecimal(src.Quotes["USD"].PercentChange24H)));
                 }, typeof(Startup));

            return services;
        }
    }
}
