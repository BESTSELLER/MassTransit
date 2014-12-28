﻿// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Testing
{
    using System;
    using ActionConfigurators;
    using TestInstanceConfigurators;


    public static class SendTestActionExtensions
    {
        public static void Send<TMessage>(this ITestInstanceConfigurator<IBusTestScenario> configurator, TMessage message)
            where TMessage : class
        {
            var actionConfigurator =
                new SendTestActionConfigurator<IBusTestScenario, TMessage>(x => x.Bus.GetSendEndpoint(x.Bus.Address).Result, message);

            configurator.AddActionConfigurator(actionConfigurator);
        }

        public static void Send<TMessage>(this ITestInstanceConfigurator<IBusTestScenario> configurator, TMessage message,
            Action<IBusTestScenario, SendContext<TMessage>> callback)
            where TMessage : class
        {
            var actionConfigurator =
                new SendTestActionConfigurator<IBusTestScenario, TMessage>(x => x.Bus.GetSendEndpoint(x.Bus.Address).Result, message,
                    callback);

            configurator.AddActionConfigurator(actionConfigurator);
        }

        public static void Send<TMessage>(this ITestInstanceConfigurator<IBusEndpointTestScenario> configurator, TMessage message)
            where TMessage : class
        {
            var actionConfigurator = new SendTestActionConfigurator<IBusEndpointTestScenario, TMessage>(x => x.SubjectSendEndpoint, message);

            configurator.AddActionConfigurator(actionConfigurator);
        }

        public static void Send<TMessage>(this ITestInstanceConfigurator<IBusEndpointTestScenario> configurator, TMessage message,
            Action<IBusEndpointTestScenario, SendContext<TMessage>> callback)
            where TMessage : class
        {
            var actionConfigurator = new SendTestActionConfigurator<IBusEndpointTestScenario, TMessage>(x => x.SubjectSendEndpoint, message,
                callback);

            configurator.AddActionConfigurator(actionConfigurator);
        }
    }
}