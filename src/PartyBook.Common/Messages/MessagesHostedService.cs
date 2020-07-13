namespace PartyBook.Common.Messages
{
    using Hangfire;
    using MassTransit;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PartyBook.Data.Common;
    using PartyBook.Data.Common.Models;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MessagesHostedService<TDbContext> : IHostedService where TDbContext : MessageDbContext
    {
        private readonly IRecurringJobManager recurringJob;
        private readonly IServiceProvider serviceProvider;
        private readonly IBus publisher;

        public MessagesHostedService(
            IRecurringJobManager recurringJob,
            IServiceProvider serviceProvider,
            IBus publisher)
        {
            this.recurringJob = recurringJob;
            this.serviceProvider = serviceProvider;
            this.publisher = publisher;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.recurringJob.AddOrUpdate(
                nameof(MessagesHostedService<TDbContext>),
                () => this.ProcessPendingMessages(),
                "*/5 * * * * *");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public void ProcessPendingMessages()
        {
            using var serviceScope = this.serviceProvider.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var data = serviceProvider.GetRequiredService<TDbContext>();

            var messages = data
                .Set<Message>()
                .Where(m => !m.Published)
                .OrderBy(m => m.Id)
                .ToList();

            foreach (var message in messages)
            {
                this.publisher.Publish(message.Data, message.Type);

                message.MarkAsPublished();

                data.SaveChanges();
            }
        }
    }
}
