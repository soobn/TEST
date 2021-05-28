﻿using System;
using System.Reflection;

namespace BF.Dependency
{
    public interface IIocRegistrar
    {


        void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class;

        void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;

        void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        bool IsRegistered(Type type);

        bool IsRegistered<TType>();
    }
}