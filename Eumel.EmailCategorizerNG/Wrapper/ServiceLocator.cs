﻿using Eumel.EmailCategorizer.Core;

namespace Eumel.EmailCategorizerNG.Wrapper
{
    internal static class ServiceLocator
    {
        public static ITopicPersister TopicPersister { get; internal set; }

        public static IConfigPersister ConfigPersister { get; internal set; }
    }
}