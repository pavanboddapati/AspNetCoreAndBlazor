using System;
using System.Collections.Generic;
using Bogus;

namespace AppAssessment.Models.DAL
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> GetApplications();
    }

    public class MockApplicationRepository : IApplicationRepository
    {
        public IEnumerable<Application> GetApplications()
        {
            var applicationId = 1;
            var applicationData = new Bogus.DataSets.Lorem("en");
            var applicationStatus = new[] { "New", "App Team Engaged", "Analyzed", "Disposition Initiated", "Dispositioned", "Deployed" };
            Randomizer.Seed = new Random(123789);

            var applicationGenerator = new Faker<Application>()
                                        .RuleFor(app => app.Id, mck => $"CA {applicationId++}")
                                        .RuleFor(app => app.Name, mck => String.Join(" ", applicationData.Words(4)))
                                        .RuleFor(app => app.RemedyId, mck => $"OI-{Guid.NewGuid()}")
                                        .RuleFor(app => app.Description, mck => applicationData.Sentence(8))
                                        .RuleFor(app => app.ShortAppId, mck => applicationData.Word())
                                        .RuleFor(app => app.Status, mck => mck.PickRandom(applicationStatus))
                                        .RuleFor(app => app.InstallDate, mck => mck.Date.Past(5).Date)
                                        .RuleFor(app => app.IsHighRisk, mck => mck.Random.Bool());
            return applicationGenerator.Generate(100);
        }
    }
}
