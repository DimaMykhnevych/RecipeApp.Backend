using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Constants;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;
using RecipeApp.Domain.Services.Email.SendEmail;

namespace RecipeApp.Infrastructure.Persistance.Services.StoredIngredientN
{
    public class MonitorStoredIngredientService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        private readonly int _sendEmailPeriodDays = 1;
        private Timer _timer = null;

        public MonitorStoredIngredientService(
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider;
            string sendEmailPeriodDaysString = configuration.GetValue<string>(ConfigurationKeys.IngredientsExpirationEmailsSendingPeriodDays);
            if (int.TryParse(sendEmailPeriodDaysString, out int value) && value > 0)
            {
                _sendEmailPeriodDays = value;
            }

            _logger = loggerFactory?.CreateLogger(nameof(MonitorStoredIngredientService));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Monitor Ingredient Service running.");

            _timer = new Timer(async o => await SendIngredientExpirationEmail(o), null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Monitor Ingredient Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async Task SendIngredientExpirationEmail(object state)
        {
            using var scope = _serviceProvider.CreateScope();
            IStoredIngredientRepository storedIngredientRepository = scope.ServiceProvider.GetRequiredService<IStoredIngredientRepository>();
            ISendEmailService sendEmailService = scope.ServiceProvider.GetRequiredService<ISendEmailService>();
            IEnumerable<StoredIngredient> expiredStoredIngredients =
                await storedIngredientRepository.GetExpiredStoredIngredientsWithUserInfo();

            var expiredIngredientsByUsers = expiredStoredIngredients.GroupBy(s => s.AppUserId);
            foreach (var userExpiredIngredients in expiredIngredientsByUsers)
            {
                await sendEmailService
                    .SendStoredIngredientExpirationEmail(userExpiredIngredients.First().AppUser, userExpiredIngredients.ToList());
            }
        }
    }
}
