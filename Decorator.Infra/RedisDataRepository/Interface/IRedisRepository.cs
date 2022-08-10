﻿using Decorator.Models;

namespace Decorator.Infra.RedisDataRepository.Interface
{
    public interface IRedisRepository
    {
        string GetStringValue(string key);
        void SetStringValue(string key, string value, int timeOutHours);
        void DeleteStringValue(string key);
        CarDto GetType(object type);
    }
}
