﻿using System;
using CryptoWatcher.Shared.Helpers;

namespace CryptoWatcher.Domain.Models
{
    public class Log : IEntity
    {
        public string Id => LogId;
        public string LogId { get; private set; }
        public string Action { get; private set; }
        public string Entity { get; private set; }
        public string EntityId { get; private set; }
        public string Json { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime CreationTime { get; private set; }

        public Log() { }
        public Log(string action, object entity, string entityId, string createdBy, DateTime creationTime)
        {
            var entityName = entity.GetType().Name;
            if (entityName == "List`1")
            {
                entityName = entity.GetType().GetGenericArguments()[0].Name + "List";
            }

            LogId = Guid.NewGuid().ToString();
            Action = action;
            Entity = entityName;
            EntityId = entityId;
            CreatedBy = createdBy;
            CreationTime = creationTime;
            Json = JsonConvertHelper.SerializeObjectRaw(entity);
        }
        public T ModelJsonToObject<T>()
        {
            return JsonConvertHelper.DeserializeObjectRaw<T>(Json);
        }
    }
}
