using Dapper;
using Microsoft.Data.SqlClient;
using SpecflowTestcontainers.Contexts;

namespace SpecflowTestcontainers.StepDefinitions;

[Binding]
public class DatabaseContainerStepDefinitions
{
    private readonly TestContext context;

    private int recordsCount = 0;

    public DatabaseContainerStepDefinitions(TestContext context)
    {
        this.context = context;
    }

    [BeforeFeature]
    public static async Task BeforeFeature(TestContext context)
    {
        context.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "DatabaseSources");
        context.DBPassword = "P@ssw0rd";
        context.SourceDBName = "test_db";

        await context.CreateDatabaseAsync();
    }

    [AfterFeature]
    public static async Task AfterFeature(TestContext context)
    {
        await context.DropDatabaseAsync();
    }

    [When(@"I execute '([^']*)'")]
    public async Task WhenIExecuteAsync(string sql)
    {
        using var connection = new SqlConnection(context.ConnectionString);
        var results = await connection.QueryAsync(sql);

        recordsCount = results.Count();
    }

    [Then(@"the result should have '([^']*)' records")]
    public void ThenTheResultShouldHaveRecords(int expectedCount)
    {
        recordsCount.Should().Be(expectedCount);
    }
}
