namespace Dzaba.TeamCityClient;

/// <summary>
/// TeamCity client extensions
/// </summary>
public static class TeamCityClientExtensions
{
    /// <summary>
    /// Get all agent pools.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">AgentPoolLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<AgentPool> GetAllAgentPoolsAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<AgentPool, Locators.AgentPoolLocator>(
            l => ToAsyncEnumerable(client.GetAllAgentPoolsAsync(l.ToString(), fields, cancellationToken), r => r.AgentPool),
            locator ?? new Locators.AgentPoolLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get the agent pool matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentPool> GetAgentPoolOfAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return await client.GetAgentPoolOfAgentPoolAsync(agentPoolLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete the agent pool matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        await client.DeleteAgentPoolAsync(agentPoolLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the agent of the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="locator">AgentLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Agent> GetAllAgentsFromAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        Locators.AgentLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return TeamCityPageExpander.GetAllAsync<Agent, Locators.AgentLocator>(
            l => ToAsyncEnumerable(client.GetAllAgentsFromAgentPoolAsync(agentPoolLocator.ToString(), l.ToString(), fields, cancellationToken), r => r.Agent),
            locator ?? new Locators.AgentLocator(), itemsPerPage);
    }

    /// <summary>
    /// Assign the agent to the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Agent> AddAgentToAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        Agent body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return await client.AddAgentToAgentPoolAsync(agentPoolLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Generates one-time tokens that can be used by agents to be automatically authorized in the specified agent pool upon registration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Items> GenerateAutomaticAgentAuthorizationTokensAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        AuthorizationTokensRequirements body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return await client.GenerateAutomaticAgentAuthorizationTokensAsync(agentPoolLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all projects of the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Projects> GetAllProjectsFromAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return await client.GetAllProjectsFromAgentPoolAsync(agentPoolLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Assign the project to the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Project> AddProjectToAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        Project body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return await client.AddProjectToAgentPoolAsync(agentPoolLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update projects of the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Projects> SetAgentPoolProjectsAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        Projects body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return await client.SetAgentPoolProjectsAsync(agentPoolLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Unassign all projects from the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteAllProjectsFromAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        await client.DeleteAllProjectsFromAgentPoolAsync(agentPoolLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Unassign the project from the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteProjectFromAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);
        ArgumentNullException.ThrowIfNull(projectLocator);

        await client.DeleteProjectFromAgentPoolAsync(agentPoolLocator.ToString(), projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetFieldFromAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return await client.GetFieldFromAgentPoolAsync(agentPoolLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a field of the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetAgentPoolFieldAsync(this ITeamCityClient client,
        Locators.AgentPoolLocator agentPoolLocator,
        string field,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        return await client.SetAgentPoolFieldAsync(agentPoolLocator.ToString(), field, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get agent type matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentTypeLocator">AgentTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentType> GetAgentTypeAsync(this ITeamCityClient client,
        Locators.AgentTypeLocator agentTypeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentTypeLocator);

        return await client.GetAgentTypeAsync(agentTypeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all known agents.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">AgentLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Agent> GetAllAgentsAsync(this ITeamCityClient client,
        Locators.AgentLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Agent, Locators.AgentLocator>(
            l => ToAsyncEnumerable(client.GetAllAgentsAsync(l.ToString(), fields, cancellationToken), r => r.Agent),
            locator ?? new Locators.AgentLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get agent matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Agent> GetAgentAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.GetAgentAsync(agentLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete an inactive agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteAgentAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        await client.DeleteAgentAsync(agentLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the authorization info of the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AuthorizedInfo> GetAuthorizedInfoAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.GetAuthorizedInfoAsync(agentLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the authorization info of the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AuthorizedInfo> SetAuthorizedInfoAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        AuthorizedInfo body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.SetAuthorizedInfoAsync(agentLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the build configuration run policy of the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<CompatibilityPolicy> GetBuildConfigurationRunPolicyAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.GetBuildConfigurationRunPolicyAsync(agentLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build configuration run policy of agent matching locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<CompatibilityPolicy> SetBuildConfigurationRunPolicyAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        CompatibilityPolicy body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.SetBuildConfigurationRunPolicyAsync(agentLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build types compatible with the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildTypes> GetCompatibleBuildTypesAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.GetCompatibleBuildTypesAsync(agentLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Check if the matching agent is enabled.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<EnabledInfo> GetEnabledInfoAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.GetEnabledInfoAsync(agentLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the enablement status of the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<EnabledInfo> SetEnabledInfoAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        EnabledInfo body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.SetEnabledInfoAsync(agentLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build types incompatible with the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Compatibilities> GetIncompatibleBuildTypesAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.GetIncompatibleBuildTypesAsync(agentLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the agent pool of the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentPool> GetAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.GetAgentPoolAsync(agentLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Assign the matching agent to the specified agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentPool> SetAgentPoolAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        AgentPool body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.SetAgentPoolAsync(agentLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetAgentFieldAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.GetAgentFieldAsync(agentLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a field of the matching agent.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="agentLocator">AgentLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetAgentFieldAsync(this ITeamCityClient client,
        Locators.AgentLocator agentLocator,
        string field,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(agentLocator);

        return await client.SetAgentFieldAsync(agentLocator.ToString(), field, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all audit events.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">AuditLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<AuditEvent> GetAllAuditEventsAsync(this ITeamCityClient client,
        Locators.AuditLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<AuditEvent, Locators.AuditLocator>(
            l => ToAsyncEnumerable(client.GetAllAuditEventsAsync(l.ToString(), fields, cancellationToken), r => r.AuditEvent),
            locator ?? new Locators.AuditLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get audit event matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="auditEventLocator">AuditLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AuditEvent> GetAuditEventAsync(this ITeamCityClient client,
        Locators.AuditLocator auditEventLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(auditEventLocator);

        return await client.GetAuditEventAsync(auditEventLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a users avatar
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="avatar">Avatar file.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task PutAvatarAsync(this ITeamCityClient client,
        FileParameter avatar,
        Locators.UserLocator userLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.PutAvatarAsync(avatar, userLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete a users avatar
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteAvatarAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.DeleteAvatarAsync(userLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a users avatar
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="size">Size.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> GetAvatarAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        int size,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetAvatarAsync(userLocator.ToString(), size, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a users avatar
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="size">Size.</param>
    /// <param name="hash">Hash.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> GetAvatarWithHashAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        int size,
        string hash,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetAvatarWithHashAsync(userLocator.ToString(), size, hash, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all queued builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">BuildQueueLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Build> GetAllQueuedBuildsAsync(this ITeamCityClient client,
        Locators.BuildQueueLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Build, Locators.BuildQueueLocator>(
            l => ToAsyncEnumerable(client.GetAllQueuedBuildsAsync(l.ToString(), fields, cancellationToken), r => r.Build),
            locator ?? new Locators.BuildQueueLocator(), itemsPerPage);
    }

    /// <summary>
    /// Delete all queued builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">BuildQueueLocator. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteAllQueuedBuildsAsync(this ITeamCityClient client,
        Locators.BuildQueueLocator locator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        await client.DeleteAllQueuedBuildsAsync(locator?.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get approval info of a queued matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ApprovalInfo> GetApprovalInfoAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetApprovalInfoAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Approve queued build with approval feature enabled.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="approveAll">Approve all.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ApprovalInfo> ApproveQueuedBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        string fields,
        bool? approveAll,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.ApproveQueuedBuildAsync(buildLocator.ToString(), body, fields, approveAll, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get tags of the queued matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="locator">TagLocator. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Tags> GetQueuedBuildTagsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        Locators.TagLocator locator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetQueuedBuildTagsAsync(buildLocator.ToString(), locator?.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add tags to the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task AddTagsToBuildOfBuildQueueAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        Tags body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.AddTagsToBuildOfBuildQueueAsync(buildLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a queued matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="queuedBuildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Build> GetQueuedBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator queuedBuildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(queuedBuildLocator);

        return await client.GetQueuedBuildAsync(queuedBuildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Cancel a queued matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="queuedBuildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Build> CancelQueuedBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator queuedBuildLocator,
        BuildCancelRequest body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(queuedBuildLocator);

        return await client.CancelQueuedBuildAsync(queuedBuildLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete a queued matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="queuedBuildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteQueuedBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator queuedBuildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(queuedBuildLocator);

        await client.DeleteQueuedBuildAsync(queuedBuildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get compatible agents for a queued matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="queuedBuildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Agents> GetCompatibleAgentsForBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator queuedBuildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(queuedBuildLocator);

        return await client.GetCompatibleAgentsForBuildAsync(queuedBuildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all build configurations.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">BuildTypeLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<BuildType> GetAllBuildTypesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<BuildType, Locators.BuildTypeLocator>(
            l => ToAsyncEnumerable(client.GetAllBuildTypesAsync(l.ToString(), fields, cancellationToken), r => r.BuildType),
            locator ?? new Locators.BuildTypeLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get build configuration matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildType> GetBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildTypeAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete build configuration matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteBuildTypeAsync(btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all agent requirements of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentRequirements> GetAllAgentRequirementsAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllAgentRequirementsAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add an agent requirement to the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentRequirement> AddAgentRequirementToBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        AgentRequirement body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddAgentRequirementToBuildTypeAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all agent requirements of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentRequirements> ReplaceAllAgentRequirementsAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        AgentRequirements body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceAllAgentRequirementsAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get an agent requirement of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="agentRequirementLocator">Agent requirement locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentRequirement> GetAgentRequirementAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string agentRequirementLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAgentRequirementAsync(btLocator.ToString(), agentRequirementLocator, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update an agent requirement of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="agentRequirementLocator">Agent requirement locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentRequirement> ReplaceAgentRequirementAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string agentRequirementLocator,
        string fields,
        AgentRequirement body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceAgentRequirementAsync(btLocator.ToString(), agentRequirementLocator, fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove an agent requirement of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="agentRequirementLocator">Agent requirement locator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteAgentRequirementAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string agentRequirementLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteAgentRequirementAsync(btLocator.ToString(), agentRequirementLocator, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a setting of an agent requirement of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="agentRequirementLocator">Agent requirement locator.</param>
    /// <param name="fieldName">Field name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetAgentRequirementParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string agentRequirementLocator,
        string fieldName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAgentRequirementParameterAsync(btLocator.ToString(), agentRequirementLocator, fieldName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a parameter of an agent requirement of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="agentRequirementLocator">Agent requirement locator.</param>
    /// <param name="fieldName">Field name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetAgentRequirementParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string agentRequirementLocator,
        string fieldName,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.SetAgentRequirementParameterAsync(btLocator.ToString(), agentRequirementLocator, fieldName, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get external IDs of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Items> GetAliasesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAliasesAsync(btLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all artifact dependencies of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ArtifactDependencies> GetAllArtifactDependenciesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllArtifactDependenciesAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add an artifact dependency to the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ArtifactDependency> AddArtifactDependencyToBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        ArtifactDependency body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddArtifactDependencyToBuildTypeAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all artifact dependencies of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ArtifactDependencies> ReplaceAllArtifactDependenciesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        ArtifactDependencies body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceAllArtifactDependenciesAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get an artifact dependency of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="artifactDepLocator">Artifact dependency locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ArtifactDependency> GetArtifactDependencyAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string artifactDepLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetArtifactDependencyAsync(btLocator.ToString(), artifactDepLocator, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update an artifact dependency of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="artifactDepLocator">Artifact dependency locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ArtifactDependency> ReplaceArtifactDependencyAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string artifactDepLocator,
        string fields,
        ArtifactDependency body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceArtifactDependencyAsync(btLocator.ToString(), artifactDepLocator, fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove an artifact dependency from the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="artifactDepLocator">Artifact dependency locator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteArtifactDependencyAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string artifactDepLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteArtifactDependencyAsync(btLocator.ToString(), artifactDepLocator, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a parameter of an artifact dependency of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="artifactDepLocator">Artifact dependency locator.</param>
    /// <param name="fieldName">Field name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetArtifactDependencyParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string artifactDepLocator,
        string fieldName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetArtifactDependencyParameterAsync(btLocator.ToString(), artifactDepLocator, fieldName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a parameter of an artifact dependency of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="artifactDepLocator">Artifact dependency locator.</param>
    /// <param name="fieldName">Field name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetArtifactDependencyParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string artifactDepLocator,
        string fieldName,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.SetArtifactDependencyParameterAsync(btLocator.ToString(), artifactDepLocator, fieldName, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all branches of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="locator">BranchLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Branch> GetAllBranchesOfBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        Locators.BranchLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return TeamCityPageExpander.GetAllAsync<Branch, Locators.BranchLocator>(
            l => ToAsyncEnumerable(client.GetAllBranchesOfBuildTypeAsync(btLocator.ToString(), l.ToString(), fields, cancellationToken), r => r.Branch),
            locator ?? new Locators.BranchLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get tags of builds of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Tags> GetBuildTypeBuildTagsAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildTypeBuildTagsAsync(btLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get builds of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Builds> GetBuildTypeBuildsAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildTypeBuildsAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all build features of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Features> GetAllBuildFeaturesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllBuildFeaturesAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add build feature to the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Feature> AddBuildFeatureToBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        Feature body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddBuildFeatureToBuildTypeAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all build features of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Features> ReplaceAllBuildFeaturesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        Features body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceAllBuildFeaturesAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a build feature of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Feature> GetBuildFeatureAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildFeatureAsync(btLocator.ToString(), featureId, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a build feature of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Feature> ReplaceBuildFeatureAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        string fields,
        Feature body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceBuildFeatureAsync(btLocator.ToString(), featureId, fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove a build feature of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteFeatureOfBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteFeatureOfBuildTypeAsync(btLocator.ToString(), featureId, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all parameters of a build feature of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetAllBuildFeatureParametersAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllBuildFeatureParametersAsync(btLocator.ToString(), featureId, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a parameter of a build feature of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> ReplaceBuildFeatureParametersAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        Properties body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceBuildFeatureParametersAsync(btLocator.ToString(), featureId, body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a parameter of a build feature of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="parameterName">Parameter name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildFeatureParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        string parameterName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildFeatureParameterAsync(btLocator.ToString(), featureId, parameterName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build feature parameter for the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="parameterName">Parameter name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> AddParameterToBuildFeatureAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        string parameterName,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddParameterToBuildFeatureAsync(btLocator.ToString(), featureId, parameterName, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the setting of a build feature of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildFeatureSettingAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildFeatureSettingAsync(btLocator.ToString(), featureId, name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a parameter of a build feature of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="featureId">Feature ID.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetBuildFeatureParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string featureId,
        string name,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.SetBuildFeatureParameterAsync(btLocator.ToString(), featureId, name, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all investigations of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Investigations> GetAllInvestigationsOfBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllInvestigationsOfBuildTypeAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Move build type to another project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="targetProjectId">Target project ID.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task MoveBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string targetProjectId,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.MoveBuildTypeAsync(btLocator.ToString(), targetProjectId, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetBuildParametersOfBuildTypeAsync(this ITeamCityClient client,
        string locator,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildParametersOfBuildTypeAsync(locator, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Create a build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> CreateBuildParameterOfBuildTypeAsync(this ITeamCityClient client,
        Property body,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.CreateBuildParameterOfBuildTypeAsync(body, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> UpdateBuildParametersOfBuildTypeAsync(this ITeamCityClient client,
        Properties body,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.UpdateBuildParametersOfBuildTypeAsync(body, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete all build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildParametersOfBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteBuildParametersOfBuildTypeAsync(btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> GetBuildParameterOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildParameterOfBuildTypeAsync(name, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> UpdateBuildParameterOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        Property body,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.UpdateBuildParameterOfBuildTypeAsync(name, body, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildParameterOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteBuildParameterOfBuildTypeAsync(name, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get value of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildParameterValueOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildParameterValueOfBuildTypeAsync(name, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update value of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> UpdateBuildParameterValueOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        string body,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.UpdateBuildParameterValueOfBuildTypeAsync(name, body, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetBuildParametersOfBuildType2Async(this ITeamCityClient client,
        string locator,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildParametersOfBuildType2Async(locator, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Create a build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> CreateBuildParameterOfBuildType2Async(this ITeamCityClient client,
        Property body,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.CreateBuildParameterOfBuildType2Async(body, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> UpdateBuildParametersOfBuildType2Async(this ITeamCityClient client,
        Properties body,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.UpdateBuildParametersOfBuildType2Async(body, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete all build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildParametersOfBuildType2Async(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteBuildParametersOfBuildType2Async(btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> GetBuildParameterOfBuildType2Async(this ITeamCityClient client,
        string name,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildParameterOfBuildType2Async(name, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> UpdateBuildParameterOfBuildType2Async(this ITeamCityClient client,
        string name,
        Property body,
        string fields,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.UpdateBuildParameterOfBuildType2Async(name, body, fields, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildParameterOfBuildType2Async(this ITeamCityClient client,
        string name,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteBuildParameterOfBuildType2Async(name, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get type of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Type> GetBuildParameterTypeOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildParameterTypeOfBuildTypeAsync(name, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update type of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Type> UpdateBuildParameterTypeOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        Type body,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.UpdateBuildParameterTypeOfBuildTypeAsync(name, body, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build parameter specification.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildParameterSpecificationOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildParameterSpecificationOfBuildTypeAsync(name, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build parameter specification.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> UpdateBuildParameterSpecificationOfBuildTypeAsync(this ITeamCityClient client,
        string name,
        string body,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.UpdateBuildParameterSpecificationOfBuildTypeAsync(name, body, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get value of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildParameterValueOfBuildType2Async(this ITeamCityClient client,
        string name,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildParameterValueOfBuildType2Async(name, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update value of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> UpdateBuildParameterValueOfBuildType2Async(this ITeamCityClient client,
        string name,
        string body,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.UpdateBuildParameterValueOfBuildType2Async(name, body, btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the settings file of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildTypeSettingsFileAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildTypeSettingsFileAsync(btLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all snapshot dependencies of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<SnapshotDependencies> GetAllSnapshotDependenciesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllSnapshotDependenciesAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a snapshot dependency to the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<SnapshotDependency> AddSnapshotDependencyToBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        SnapshotDependency body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddSnapshotDependencyToBuildTypeAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all snapshot dependencies of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<SnapshotDependencies> ReplaceAllSnapshotDependenciesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        SnapshotDependencies body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceAllSnapshotDependenciesAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a snapshot dependency of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="snapshotDepLocator">Snapshot dependency locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<SnapshotDependency> GetSnapshotDependencyAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string snapshotDepLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetSnapshotDependencyAsync(btLocator.ToString(), snapshotDepLocator, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a snapshot dependency of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="snapshotDepLocator">Snapshot dependency locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<SnapshotDependency> ReplaceSnapshotDependencyAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string snapshotDepLocator,
        string fields,
        SnapshotDependency body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceSnapshotDependencyAsync(btLocator.ToString(), snapshotDepLocator, fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete a snapshot dependency of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="snapshotDepLocator">Snapshot dependency locator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteSnapshotDependencyAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string snapshotDepLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteSnapshotDependencyAsync(btLocator.ToString(), snapshotDepLocator, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all build steps of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Steps> GetAllBuildStepsAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllBuildStepsAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a build step to the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Step> AddBuildStepToBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        Step body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddBuildStepToBuildTypeAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all build steps of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Steps> ReplaceAllBuildStepsAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        Steps body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceAllBuildStepsAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Step> GetBuildStepAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildStepAsync(btLocator.ToString(), stepId, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Replace a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Step> ReplaceBuildStepAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        string fields,
        Step body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceBuildStepAsync(btLocator.ToString(), stepId, fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildStepAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteBuildStepAsync(btLocator.ToString(), stepId, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all parameters of a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetAllBuildStepParametersAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllBuildStepParametersAsync(btLocator.ToString(), stepId, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a parameter of a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> DeleteBuildStepParametersAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        Properties body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.DeleteBuildStepParametersAsync(btLocator.ToString(), stepId, body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a parameter of a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="parameterName">Parameter name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildStepParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        string parameterName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildStepParameterAsync(btLocator.ToString(), stepId, parameterName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a parameter to a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="parameterName">Parameter name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> AddParameterToBuildStepAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        string parameterName,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddParameterToBuildStepAsync(btLocator.ToString(), stepId, parameterName, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the setting of a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="fieldName">Field name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildStepSettingAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        string fieldName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildStepSettingAsync(btLocator.ToString(), stepId, fieldName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a parameter of a build step of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="stepId">Step ID.</param>
    /// <param name="fieldName">Field name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetBuildStepParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string stepId,
        string fieldName,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.SetBuildStepParameterAsync(btLocator.ToString(), stepId, fieldName, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all build templates of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildTypes> GetAllBuildTemplatesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllBuildTemplatesAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a build template to the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="optimizeSettings">Optimize settings.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildType> AddBuildTemplateAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        BuildType body,
        bool? optimizeSettings,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddBuildTemplateAsync(btLocator.ToString(), body, optimizeSettings, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all templates of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="optimizeSettings">Optimize settings.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildTypes> SetBuildTypeTemplatesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        BuildTypes body,
        bool? optimizeSettings,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.SetBuildTypeTemplatesAsync(btLocator.ToString(), body, optimizeSettings, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Detach all templates from the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="inlineSettings">Inline settings.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveAllTemplatesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        bool? inlineSettings,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.RemoveAllTemplatesAsync(btLocator.ToString(), inlineSettings, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a template of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="templateLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildType> GetBuildTemplateAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        Locators.BuildTypeLocator templateLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);
        ArgumentNullException.ThrowIfNull(templateLocator);

        return await client.GetBuildTemplateAsync(btLocator.ToString(), templateLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Detach a template from the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="templateLocator">BuildTypeLocator.</param>
    /// <param name="inlineSettings">Inline settings.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveTemplateAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        Locators.BuildTypeLocator templateLocator,
        bool? inlineSettings,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);
        ArgumentNullException.ThrowIfNull(templateLocator);

        await client.RemoveTemplateAsync(btLocator.ToString(), templateLocator.ToString(), inlineSettings, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all triggers of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Triggers> GetAllTriggersAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllTriggersAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a trigger to the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Trigger> AddTriggerToBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        Trigger body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddTriggerToBuildTypeAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all triggers of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Triggers> ReplaceAllTriggersAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        Triggers body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceAllTriggersAsync(btLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a trigger of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="triggerLocator">Trigger locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Trigger> GetTriggerAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string triggerLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetTriggerAsync(btLocator.ToString(), triggerLocator, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a trigger of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="triggerLocator">Trigger locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Trigger> ReplaceTriggerAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string triggerLocator,
        string fields,
        Trigger body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceTriggerAsync(btLocator.ToString(), triggerLocator, fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete a trigger of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="triggerLocator">Trigger locator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteTriggerAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string triggerLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        await client.DeleteTriggerAsync(btLocator.ToString(), triggerLocator, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a parameter of a trigger of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="triggerLocator">Trigger locator.</param>
    /// <param name="fieldName">Field name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetTriggerParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string triggerLocator,
        string fieldName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetTriggerParameterAsync(btLocator.ToString(), triggerLocator, fieldName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a parameter of a trigger of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="triggerLocator">Trigger locator.</param>
    /// <param name="fieldName">Field name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetTriggerParameterAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string triggerLocator,
        string fieldName,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.SetTriggerParameterAsync(btLocator.ToString(), triggerLocator, fieldName, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all VCS roots of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootEntries> GetAllVcsRootsOfBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetAllVcsRootsOfBuildTypeAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a VCS root to the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootEntry> AddVcsRootToBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        VcsRootEntry body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.AddVcsRootToBuildTypeAsync(btLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all VCS roots of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootEntries> ReplaceAllVcsRootsAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        VcsRootEntries body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.ReplaceAllVcsRootsAsync(btLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a VCS root of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootEntry> GetVcsRootAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        Locators.VcsRootLocator vcsRootLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.GetVcsRootAsync(btLocator.ToString(), vcsRootLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a VCS root of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootEntry> UpdateBuildTypeVcsRootAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        Locators.VcsRootLocator vcsRootLocator,
        VcsRootEntry body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.UpdateBuildTypeVcsRootAsync(btLocator.ToString(), vcsRootLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove a VCS root of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteVcsRootOfBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        Locators.VcsRootLocator vcsRootLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        await client.DeleteVcsRootOfBuildTypeAsync(btLocator.ToString(), vcsRootLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get checkout rules of a VCS root of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetVcsRootCheckoutRulesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        Locators.VcsRootLocator vcsRootLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.GetVcsRootCheckoutRulesAsync(btLocator.ToString(), vcsRootLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update checkout rules of a VCS root of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> UpdateBuildTypeVcsRootCheckoutRulesAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        Locators.VcsRootLocator vcsRootLocator,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.UpdateBuildTypeVcsRootCheckoutRulesAsync(btLocator.ToString(), vcsRootLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// List all files.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Files> GetFilesListOfBuildTypeAsync(this ITeamCityClient client,
        string basePath,
        string locator,
        string fields,
        Locators.BuildTypeLocator btLocator,
        bool? resolveParameters,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetFilesListOfBuildTypeAsync(basePath, locator, fields, btLocator.ToString(), resolveParameters, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get specific file zipped.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="name">Name.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> GetZippedFileOfBuildTypeAsync(this ITeamCityClient client,
        string path,
        string basePath,
        string locator,
        string name,
        Locators.BuildTypeLocator btLocator,
        bool? resolveParameters,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetZippedFileOfBuildTypeAsync(path, basePath, locator, name, btLocator.ToString(), resolveParameters, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Download specific file.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> DownloadFileOfBuildTypeAsync(this ITeamCityClient client,
        string path,
        Locators.BuildTypeLocator btLocator,
        bool? resolveParameters,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.DownloadFileOfBuildTypeAsync(path, btLocator.ToString(), resolveParameters, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get metadata of specific file.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<File> GetFileMetadataOfBuildTypeAsync(this ITeamCityClient client,
        string path,
        string fields,
        Locators.BuildTypeLocator btLocator,
        bool? resolveParameters,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetFileMetadataOfBuildTypeAsync(path, fields, btLocator.ToString(), resolveParameters, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// List files under this path.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Files> GetFilesListForSubpathOfBuildTypeAsync(this ITeamCityClient client,
        string path,
        string basePath,
        string locator,
        string fields,
        Locators.BuildTypeLocator btLocator,
        bool? resolveParameters,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetFilesListForSubpathOfBuildTypeAsync(path, basePath, locator, fields, btLocator.ToString(), resolveParameters, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all VCS root instances of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootInstances> GetVcsRootInstancesOfBuildTypeAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetVcsRootInstancesOfBuildTypeAsync(btLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildTypeFieldAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.GetBuildTypeFieldAsync(btLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a field of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="btLocator">BuildTypeLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetBuildTypeFieldAsync(this ITeamCityClient client,
        Locators.BuildTypeLocator btLocator,
        string field,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(btLocator);

        return await client.SetBuildTypeFieldAsync(btLocator.ToString(), field, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">BuildLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Build> GetAllBuildsAsync(this ITeamCityClient client,
        Locators.BuildLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Build, Locators.BuildLocator>(
            l => ToAsyncEnumerable(client.GetAllBuildsAsync(l.ToString(), fields, cancellationToken), r => r.Build),
            locator ?? new Locators.BuildLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get the build status of aggregated matching builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetAggregatedBuildStatusAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetAggregatedBuildStatusAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the status icon (in specified format) of aggregated matching builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="suffix">Icon suffix.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task GetAggregatedBuildStatusIconAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string suffix,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.GetAggregatedBuildStatusIconAsync(buildLocator.ToString(), suffix, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get multiple builds matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Builds> GetMultipleBuildsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetMultipleBuildsAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// cancelMultipleBuilds
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<MultipleOperationResult> CancelMultipleAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        BuildCancelRequest body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.CancelMultipleAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete multiple builds matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<MultipleOperationResult> DeleteMultipleBuildsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.DeleteMultipleBuildsAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update comments in multiple matching builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<MultipleOperationResult> SetMultipleBuildCommentsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.SetMultipleBuildCommentsAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete comments of multiple matching builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<MultipleOperationResult> DeleteMultipleBuildCommentsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.DeleteMultipleBuildCommentsAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Pin multiple matching builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<MultipleOperationResult> PinMultipleBuildsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        PinInfo body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.PinMultipleBuildsAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add tags to multiple matching builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<MultipleOperationResult> AddTagsToMultipleBuildsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        Tags body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.AddTagsToMultipleBuildsAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove tags from multiple matching builds.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<MultipleOperationResult> RemoveMultipleBuildTagsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        Tags body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.RemoveMultipleBuildTagsAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Build> GetBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// cancelBuild
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Build> CancelBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        BuildCancelRequest body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.CancelBuildAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete build matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.DeleteBuildAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get artifact dependency changes of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildChanges> GetArtifactDependencyChangesAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetArtifactDependencyChangesAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// List all files.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="logBuildUsage">Log build usage.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Files> GetFilesListOfBuildAsync(this ITeamCityClient client,
        string basePath,
        string locator,
        string fields,
        Locators.BuildLocator buildLocator,
        bool? resolveParameters,
        bool? logBuildUsage,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetFilesListOfBuildAsync(basePath, locator, fields, buildLocator.ToString(), resolveParameters, logBuildUsage, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get specific file zipped.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="name">Name.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="logBuildUsage">Log build usage.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> GetZippedFileOfBuildAsync(this ITeamCityClient client,
        string path,
        string basePath,
        string locator,
        string name,
        Locators.BuildLocator buildLocator,
        bool? resolveParameters,
        bool? logBuildUsage,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetZippedFileOfBuildAsync(path, basePath, locator, name, buildLocator.ToString(), resolveParameters, logBuildUsage, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Download specific file.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="logBuildUsage">Log build usage.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> DownloadFileOfBuildAsync(this ITeamCityClient client,
        string path,
        Locators.BuildLocator buildLocator,
        bool? resolveParameters,
        bool? logBuildUsage,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.DownloadFileOfBuildAsync(path, buildLocator.ToString(), resolveParameters, logBuildUsage, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get metadata of specific file.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="logBuildUsage">Log build usage.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<File> GetFileMetadataOfBuildAsync(this ITeamCityClient client,
        string path,
        string fields,
        Locators.BuildLocator buildLocator,
        bool? resolveParameters,
        bool? logBuildUsage,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetFileMetadataOfBuildAsync(path, fields, buildLocator.ToString(), resolveParameters, logBuildUsage, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// List files under this path.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="resolveParameters">Resolve parameters.</param>
    /// <param name="logBuildUsage">Log build usage.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Files> GetFilesListForSubpathOfBuildAsync(this ITeamCityClient client,
        string path,
        string basePath,
        string locator,
        string fields,
        Locators.BuildLocator buildLocator,
        bool? resolveParameters,
        bool? logBuildUsage,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetFilesListForSubpathOfBuildAsync(path, basePath, locator, fields, buildLocator.ToString(), resolveParameters, logBuildUsage, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the artifacts' directory of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetArtifactsDirectoryAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetArtifactsDirectoryAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove build parameters from the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task ResetBuildFinishPropertiesAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.ResetBuildFinishPropertiesAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Check if the matching build is canceled.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Comment> GetCanceledInfoAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetCanceledInfoAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the comment on the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task SetBuildCommentAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.SetBuildCommentAsync(buildLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove the build comment matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildCommentAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.DeleteBuildCommentAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Marks the running build as finished by passing agent the current time of the build to finish.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetFinishedTimeAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.SetFinishedTimeAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the finish date of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildFinishDateAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildFinishDateAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Marks the running build as finished by passing agent the current time of the build to finish.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetBuildFinishDateAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.SetBuildFinishDateAsync(buildLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Adds a message to the build log. Service messages are accepted.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task AddLogMessageToBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.AddLogMessageToBuildAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the number of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildNumberAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildNumberAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the number of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetBuildNumberAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.SetBuildNumberAsync(buildLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get output parameters published by the build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetBuildOutputParametersOfBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildOutputParametersOfBuildAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the value of a build output parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="propertyName">Property name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildOutputParametersAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string propertyName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildOutputParametersAsync(buildLocator.ToString(), propertyName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Check if the matching build is pinned.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<PinInfo> GetBuildPinInfoAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildPinInfoAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the pin info of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<PinInfo> SetBuildPinInfoAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        PinInfo body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.SetBuildPinInfoAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build problems of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ProblemOccurrences> GetBuildProblemsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildProblemsAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a build problem to the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ProblemOccurrence> AddProblemToBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.AddProblemToBuildAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get related issues of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<IssuesUsages> GetBuildRelatedIssuesAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildRelatedIssuesAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the resolvement status of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="value">Value.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildResolvedAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string value,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildResolvedAsync(buildLocator.ToString(), value, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get actual build parameters of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetBuildActualParametersAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildActualParametersAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the final value that a given parameter had after the build finished.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="propertyName">Property name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildResultingPropertiesAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string propertyName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildResultingPropertiesAsync(buildLocator.ToString(), propertyName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Starts the queued build as an agent-less build and returns the corresponding running build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Build> MarkBuildAsRunningAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.MarkBuildAsRunningAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a source file of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fileName">File name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> GetBuildSourceFileAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fileName,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildSourceFileAsync(buildLocator.ToString(), fileName, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all statistical values of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetBuildStatisticValuesAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildStatisticValuesAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a statistical value of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildStatisticValueAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildStatisticValueAsync(buildLocator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get status of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildStatusAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildStatusAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Change status of the build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task SetBuildStatusAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        BuildStatusUpdate body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.SetBuildStatusAsync(buildLocator.ToString(), fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the status icon (in specified format) of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="suffix">Icon suffix.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task GetBuildStatusIconAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string suffix,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        await client.GetBuildStatusIconAsync(buildLocator.ToString(), suffix, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the build status text of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildStatusTextAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildStatusTextAsync(buildLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the build status of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetBuildStatusTextAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.SetBuildStatusTextAsync(buildLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get tags of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="locator">TagLocator. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Tags> GetBuildTagsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        Locators.TagLocator locator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildTagsAsync(buildLocator.ToString(), locator?.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add tags to the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Tags> AddTagsToBuildAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        Tags body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.AddTagsToBuildAsync(buildLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update tags of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="locator">TagLocator. Can be null.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Tags> SetBuildTagsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        Locators.TagLocator locator,
        Tags body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.SetBuildTagsAsync(buildLocator.ToString(), locator?.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get test occurrences of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<TestOccurrences> GetBuildTestOccurrencesAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildTestOccurrencesAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get VCS labels of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsLabels> GetBuildVcsLabelsAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildVcsLabelsAsync(buildLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a VCS label to the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsLabels> AddBuildVcsLabelAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string locator,
        string fields,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.AddBuildVcsLabelAsync(buildLocator.ToString(), locator, fields, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching build.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="buildLocator">BuildLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildFieldAsync(this ITeamCityClient client,
        Locators.BuildLocator buildLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(buildLocator);

        return await client.GetBuildFieldAsync(buildLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all changes.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ChangeLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Change> GetAllChangesAsync(this ITeamCityClient client,
        Locators.ChangeLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Change, Locators.ChangeLocator>(
            l => ToAsyncEnumerable(client.GetAllChangesAsync(l.ToString(), fields, cancellationToken), r => r.Change),
            locator ?? new Locators.ChangeLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get change matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Change> GetChangeAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeAsync(changeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get attributes of the matching change.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Entries> GetChangeAttributesAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeAttributesAsync(changeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get duplicates of the matching change.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Changes> GetChangeDuplicatesAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeDuplicatesAsync(changeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get first builds of the matching change.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Builds> GetChangeFirstBuildsAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeFirstBuildsAsync(changeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get issues of the matching change.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Issues> GetChangeIssueAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeIssueAsync(changeLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get parent changes of the matching change.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Changes> GetChangeParentChangesAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeParentChangesAsync(changeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get parent revisions of the matching change.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Items> GetChangeParentRevisionsAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeParentRevisionsAsync(changeLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a VCS root instance of the matching change.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootInstance> GetChangeVcsRootAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeVcsRootAsync(changeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching change.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="changeLocator">ChangeLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetChangeFieldAsync(this ITeamCityClient client,
        Locators.ChangeLocator changeLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(changeLocator);

        return await client.GetChangeFieldAsync(changeLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all cloud images.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">CloudImageLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<CloudImage> GetAllCloudImagesAsync(this ITeamCityClient client,
        Locators.CloudImageLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<CloudImage, Locators.CloudImageLocator>(
            l => ToAsyncEnumerable(client.GetAllCloudImagesAsync(l.ToString(), fields, cancellationToken), r => r.CloudImage),
            locator ?? new Locators.CloudImageLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get cloud image matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="imageLocator">CloudImageLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<CloudImage> GetCloudImageAsync(this ITeamCityClient client,
        Locators.CloudImageLocator imageLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(imageLocator);

        return await client.GetCloudImageAsync(imageLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all cloud instances.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">CloudInstanceLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<CloudInstance> GetAllCloudInstancesAsync(this ITeamCityClient client,
        Locators.CloudInstanceLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<CloudInstance, Locators.CloudInstanceLocator>(
            l => ToAsyncEnumerable(client.GetAllCloudInstancesAsync(l.ToString(), fields, cancellationToken), r => r.CloudInstance),
            locator ?? new Locators.CloudInstanceLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get cloud instance matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="instanceLocator">CloudInstanceLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<CloudInstance> GetCloudInstanceAsync(this ITeamCityClient client,
        Locators.CloudInstanceLocator instanceLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(instanceLocator);

        return await client.GetCloudInstanceAsync(instanceLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Stop cloud instance matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="instanceLocator">CloudInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task StopInstanceAsync(this ITeamCityClient client,
        Locators.CloudInstanceLocator instanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(instanceLocator);

        await client.StopInstanceAsync(instanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Terminates existing cloud instance immediately
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="instanceLocator">CloudInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task ForseTerminateInstanceAsync(this ITeamCityClient client,
        Locators.CloudInstanceLocator instanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(instanceLocator);

        await client.ForseTerminateInstanceAsync(instanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Schedules existing cloud instance for termination
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="instanceLocator">CloudInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task TerminateInstanceAsync(this ITeamCityClient client,
        Locators.CloudInstanceLocator instanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(instanceLocator);

        await client.TerminateInstanceAsync(instanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all cloud profiles.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">CloudProfileLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<CloudProfile> GetAllCloudProfilesAsync(this ITeamCityClient client,
        Locators.CloudProfileLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<CloudProfile, Locators.CloudProfileLocator>(
            l => ToAsyncEnumerable(client.GetAllCloudProfilesAsync(l.ToString(), fields, cancellationToken), r => r.CloudProfile),
            locator ?? new Locators.CloudProfileLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get cloud profile matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="profileLocator">CloudProfileLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<CloudProfile> GetCloudProfileAsync(this ITeamCityClient client,
        Locators.CloudProfileLocator profileLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(profileLocator);

        return await client.GetCloudProfileAsync(profileLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all deployment dashboards.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">DeploymentDashboardLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<DeploymentDashboard> GetAllDashboardsAsync(this ITeamCityClient client,
        Locators.DeploymentDashboardLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<DeploymentDashboard, Locators.DeploymentDashboardLocator>(
            l => ToAsyncEnumerable(client.GetAllDashboardsAsync(l.ToString(), fields, cancellationToken), r => r.DeploymentDashboard),
            locator ?? new Locators.DeploymentDashboardLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get the deployment dashboard matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="deploymentDashboardLocator">DeploymentDashboardLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<DeploymentDashboard> GetDashboardAsync(this ITeamCityClient client,
        Locators.DeploymentDashboardLocator deploymentDashboardLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(deploymentDashboardLocator);

        return await client.GetDashboardAsync(deploymentDashboardLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete the deployment dashboard matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="deploymentDashboardLocator">DeploymentDashboardLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteDashboardAsync(this ITeamCityClient client,
        Locators.DeploymentDashboardLocator deploymentDashboardLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(deploymentDashboardLocator);

        await client.DeleteDashboardAsync(deploymentDashboardLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get deployment instances for a given deployment dashboard.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="deploymentDashboardLocator">DeploymentDashboardLocator.</param>
    /// <param name="locator">DeploymentInstanceLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<DeploymentInstance> GetInstancesAsync(this ITeamCityClient client,
        Locators.DeploymentDashboardLocator deploymentDashboardLocator,
        Locators.DeploymentInstanceLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(deploymentDashboardLocator);

        return TeamCityPageExpander.GetAllAsync<DeploymentInstance, Locators.DeploymentInstanceLocator>(
            l => ToAsyncEnumerable(client.GetInstancesAsync(deploymentDashboardLocator.ToString(), l.ToString(), fields, cancellationToken), r => r.DeploymentInstance),
            locator ?? new Locators.DeploymentInstanceLocator(), itemsPerPage);
    }

    /// <summary>
    /// Create a new deployment instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="deploymentDashboardLocator">DeploymentDashboardLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<DeploymentInstance> CreateInstanceAsync(this ITeamCityClient client,
        Locators.DeploymentDashboardLocator deploymentDashboardLocator,
        DeploymentInstance body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(deploymentDashboardLocator);

        return await client.CreateInstanceAsync(deploymentDashboardLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the deployment instance matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="deploymentDashboardLocator">DeploymentDashboardLocator.</param>
    /// <param name="deploymentInstanceLocator">DeploymentInstanceLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<DeploymentInstance> GetInstanceAsync(this ITeamCityClient client,
        Locators.DeploymentDashboardLocator deploymentDashboardLocator,
        Locators.DeploymentInstanceLocator deploymentInstanceLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(deploymentDashboardLocator);
        ArgumentNullException.ThrowIfNull(deploymentInstanceLocator);

        return await client.GetInstanceAsync(deploymentDashboardLocator.ToString(), deploymentInstanceLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Report a new deployment for instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="deploymentDashboardLocator">DeploymentDashboardLocator.</param>
    /// <param name="deploymentInstanceLocator">DeploymentInstanceLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<DeploymentInstance> ReportNewDeploymentForInstanceAsync(this ITeamCityClient client,
        Locators.DeploymentDashboardLocator deploymentDashboardLocator,
        Locators.DeploymentInstanceLocator deploymentInstanceLocator,
        DeploymentStateEntry2 body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(deploymentDashboardLocator);
        ArgumentNullException.ThrowIfNull(deploymentInstanceLocator);

        return await client.ReportNewDeploymentForInstanceAsync(deploymentDashboardLocator.ToString(), deploymentInstanceLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete the deployment instance matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="deploymentDashboardLocator">DeploymentDashboardLocator.</param>
    /// <param name="deploymentInstanceLocator">DeploymentInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteInstanceAsync(this ITeamCityClient client,
        Locators.DeploymentDashboardLocator deploymentDashboardLocator,
        Locators.DeploymentInstanceLocator deploymentInstanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(deploymentDashboardLocator);
        ArgumentNullException.ThrowIfNull(deploymentInstanceLocator);

        await client.DeleteInstanceAsync(deploymentDashboardLocator.ToString(), deploymentInstanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all investigations.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">InvestigationLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Investigation> GetAllInvestigationsAsync(this ITeamCityClient client,
        Locators.InvestigationLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Investigation, Locators.InvestigationLocator>(
            l => ToAsyncEnumerable(client.GetAllInvestigationsAsync(l.ToString(), fields, cancellationToken), r => r.Investigation),
            locator ?? new Locators.InvestigationLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get investigation matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="investigationLocator">InvestigationLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Investigation> GetInvestigationAsync(this ITeamCityClient client,
        Locators.InvestigationLocator investigationLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(investigationLocator);

        return await client.GetInvestigationAsync(investigationLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update investigation matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="investigationLocator">InvestigationLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Investigation> ReplaceInvestigationAsync(this ITeamCityClient client,
        Locators.InvestigationLocator investigationLocator,
        Investigation body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(investigationLocator);

        return await client.ReplaceInvestigationAsync(investigationLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete investigation matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="investigationLocator">InvestigationLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteInvestigationAsync(this ITeamCityClient client,
        Locators.InvestigationLocator investigationLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(investigationLocator);

        await client.DeleteInvestigationAsync(investigationLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all build problem occurrences.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProblemOccurrenceLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<ProblemOccurrence> GetAllBuildProblemOccurrencesAsync(this ITeamCityClient client,
        Locators.ProblemOccurrenceLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<ProblemOccurrence, Locators.ProblemOccurrenceLocator>(
            l => ToAsyncEnumerable(client.GetAllBuildProblemOccurrencesAsync(l.ToString(), fields, cancellationToken), r => r.ProblemOccurrence),
            locator ?? new Locators.ProblemOccurrenceLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get a matching build problem occurrence.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="problemLocator">ProblemOccurrenceLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<ProblemOccurrence> GetBuildProblemOccurrenceAsync(this ITeamCityClient client,
        Locators.ProblemOccurrenceLocator problemLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(problemLocator);

        return await client.GetBuildProblemOccurrenceAsync(problemLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all build problems.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProblemLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Problem> GetAllBuildProblemsAsync(this ITeamCityClient client,
        Locators.ProblemLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Problem, Locators.ProblemLocator>(
            l => ToAsyncEnumerable(client.GetAllBuildProblemsAsync(l.ToString(), fields, cancellationToken), r => r.Problem),
            locator ?? new Locators.ProblemLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get a matching build problem.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="problemLocator">ProblemLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Problem> GetBuildProblemAsync(this ITeamCityClient client,
        Locators.ProblemLocator problemLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(problemLocator);

        return await client.GetBuildProblemAsync(problemLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all projects.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Project> GetAllProjectsAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Project, Locators.ProjectLocator>(
            l => ToAsyncEnumerable(client.GetAllProjectsAsync(l.ToString(), fields, cancellationToken), r => r.Project),
            locator ?? new Locators.ProjectLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get a list of projects that are affected by Load Settings from VCS action.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Projects> GetVersionedSettingsProjectsToLoadAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.GetVersionedSettingsProjectsToLoadAsync(locator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Check for changes in Versioned Settings.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task CheckForVersionedSettingsChangesAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        await client.CheckForVersionedSettingsChangesAsync(locator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Perform Versioned Settings action: Commit current settings to VCS.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task CommitCurrentSettingsAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        await client.CommitCurrentSettingsAsync(locator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get Versioned Settings config.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VersionedSettingsConfig> GetVersionedSettingsConfigAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.GetVersionedSettingsConfigAsync(locator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Set Verseioned Settings config.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VersionedSettingsConfig> SetVersionedSettingsConfigAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        VersionedSettingsConfig body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.SetVersionedSettingsConfigAsync(locator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get Versioned Settings config parameter value.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetVersionedSettingsConfigParameterAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.GetVersionedSettingsConfigParameterAsync(locator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Set Versioned Settings config parameter value.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetVersionedSettingsConfigParameterAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string name,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.SetVersionedSettingsConfigParameterAsync(locator.ToString(), name, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete Versioned Settings config parameter value.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteVersionedSettingsConfigParameterAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        await client.DeleteVersionedSettingsConfigParameterAsync(locator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get Versioned Settings Context Parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VersionedSettingsContextParameters> GetVersionedSettingsContextParametersAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.GetVersionedSettingsContextParametersAsync(locator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Set Versioned Settings Context Parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VersionedSettingsContextParameters> SetVersionedSettingsContextParametersAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        VersionedSettingsContextParameters body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.SetVersionedSettingsContextParametersAsync(locator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Perform Versioned Settings action: Load Setting from VCS.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Projects> LoadSettingsFromVCSAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.LoadSettingsFromVCSAsync(locator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get current status of Versioned Settings.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VersionedSettingsStatus> GetVersionedSettingsStatusAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.GetVersionedSettingsStatusAsync(locator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get Versioned Settings Tokens.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="status">Status.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VersionedSettingsTokens> GetVersionedSettingsTokensAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        string status,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.GetVersionedSettingsTokensAsync(locator.ToString(), status, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add Versioned Settings Tokens.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VersionedSettingsTokens> AddVersionedSettingsTokensAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        VersionedSettingsTokens body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.AddVersionedSettingsTokensAsync(locator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete Versioned Settings Tokens.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VersionedSettingsTokens> DeleteVersionedSettingsTokensAsync(this ITeamCityClient client,
        Locators.ProjectLocator locator,
        VersionedSettingsTokens body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        return await client.DeleteVersionedSettingsTokensAsync(locator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get project matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Project> GetProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetProjectAsync(projectLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete project matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        await client.DeleteProjectAsync(projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get agent pools appointed to the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentPools> GetAgentPoolsProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetAgentPoolsProjectAsync(projectLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Assign the matching project to the agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentPool> AddAgentPoolsProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        AgentPool body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.AddAgentPoolsProjectAsync(projectLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update agent pools apppointed to the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<AgentPools> SetAgentPoolsProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        AgentPools body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.SetAgentPoolsProjectAsync(projectLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Unassign a project from the matching agent pool.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="agentPoolLocator">AgentPoolLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveProjectFromAgentPoolAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        Locators.AgentPoolLocator agentPoolLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);
        ArgumentNullException.ThrowIfNull(agentPoolLocator);

        await client.RemoveProjectFromAgentPoolAsync(projectLocator.ToString(), agentPoolLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all branches of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="locator">BranchLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Branch> GetAllBranchesAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        Locators.BranchLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return TeamCityPageExpander.GetAllAsync<Branch, Locators.BranchLocator>(
            l => ToAsyncEnumerable(client.GetAllBranchesAsync(projectLocator.ToString(), l.ToString(), fields, cancellationToken), r => r.Branch),
            locator ?? new Locators.BranchLocator(), itemsPerPage);
    }

    /// <summary>
    /// Add a build configuration to the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildType> AddBuildTypeAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        NewBuildTypeDescription body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.AddBuildTypeAsync(projectLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the default template of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildType> GetDefaultTemplateAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetDefaultTemplateAsync(projectLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the default template of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildType> SetDefaultTemplateAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        BuildType body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.SetDefaultTemplateAsync(projectLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove the default template from the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveDefaultTemplateAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        await client.RemoveDefaultTemplateAsync(projectLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// getDefaultValueSets
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<TypedValueSets> GetDefaultValueSetsAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetDefaultValueSetsAsync(projectLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// getDeploymentDashboardsInProjet
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<DeploymentDashboards> GetDeploymentDashboardsInProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetDeploymentDashboardsInProjectAsync(projectLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// getDeploymentDashboardInProject
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="dashboardLocator">DeploymentDashboardLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<DeploymentDashboard> GetDeploymentDashboardInProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        Locators.DeploymentDashboardLocator dashboardLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);
        ArgumentNullException.ThrowIfNull(dashboardLocator);

        return await client.GetDeploymentDashboardInProjectAsync(projectLocator.ToString(), dashboardLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all build configurations from the matching project, with custom ordering applied.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildTypes> GetAllBuildTypesOrderedAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetAllBuildTypesOrderedAsync(projectLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update custom ordering of build configurations of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildTypes> SetBuildTypesOrderAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        BuildTypes body,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.SetBuildTypesOrderAsync(projectLocator.ToString(), body, field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all subprojects of the matching project, with custom ordering applied.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Projects> GetAllSubprojectsOrderedAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetAllSubprojectsOrderedAsync(projectLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update custom ordering of subprojects of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Projects> SetSubprojectsOrderAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        Projects body,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.SetSubprojectsOrderAsync(projectLocator.ToString(), body, field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetBuildParametersAsync(this ITeamCityClient client,
        string locator,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetBuildParametersAsync(locator, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Create a build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> CreateBuildParameterAsync(this ITeamCityClient client,
        Property body,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.CreateBuildParameterAsync(body, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> UpdateBuildParametersAsync(this ITeamCityClient client,
        Properties body,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.UpdateBuildParametersAsync(body, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete all build parameters.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildParametersAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        await client.DeleteBuildParametersAsync(projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> GetBuildParameterAsync(this ITeamCityClient client,
        string name,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetBuildParameterAsync(name, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Property> UpdateBuildParameterAsync(this ITeamCityClient client,
        string name,
        Property body,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.UpdateBuildParameterAsync(name, body, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteBuildParameterAsync(this ITeamCityClient client,
        string name,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        await client.DeleteBuildParameterAsync(name, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get type of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Type> GetBuildParameterTypeAsync(this ITeamCityClient client,
        string name,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetBuildParameterTypeAsync(name, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update type of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Type> UpdateBuildParameterTypeAsync(this ITeamCityClient client,
        string name,
        Type body,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.UpdateBuildParameterTypeAsync(name, body, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get build parameter specification.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildParameterSpecificationAsync(this ITeamCityClient client,
        string name,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetBuildParameterSpecificationAsync(name, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update build parameter specification.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> UpdateBuildParameterSpecificationAsync(this ITeamCityClient client,
        string name,
        string body,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.UpdateBuildParameterSpecificationAsync(name, body, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get value of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetBuildParameterValueAsync(this ITeamCityClient client,
        string name,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetBuildParameterValueAsync(name, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update value of build parameter.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> UpdateBuildParameterValueAsync(this ITeamCityClient client,
        string name,
        string body,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.UpdateBuildParameterValueAsync(name, body, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the parent project of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Project> GetProjectParentProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetProjectParentProjectAsync(projectLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the parent project of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Project> SetParentProjectAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        Project body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.SetParentProjectAsync(projectLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all features.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<object> GetFeaturesAsync(this ITeamCityClient client,
        string locator,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetFeaturesAsync(locator, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a feature.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<object> AddFeatureAsync(this ITeamCityClient client,
        ProjectFeature body,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.AddFeatureAsync(body, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all features.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<object> UpdateFeaturesAsync(this ITeamCityClient client,
        ProjectFeatures body,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.UpdateFeaturesAsync(body, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a matching feature.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="featureLocator">Feature locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<object> GetFeatureAsync(this ITeamCityClient client,
        string featureLocator,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetFeatureAsync(featureLocator, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a matching feature.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="featureLocator">Feature locator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<object> UpdateFeatureAsync(this ITeamCityClient client,
        string featureLocator,
        ProjectFeature body,
        string fields,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.UpdateFeatureAsync(featureLocator, body, fields, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete a matching feature.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="featureLocator">Feature locator.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteFeatureAsync(this ITeamCityClient client,
        string featureLocator,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        await client.DeleteFeatureAsync(featureLocator, projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Creates a new [secure token](https://www.jetbrains.com/help/teamcity/storing-project-settings-in-version-control.html#Managing+Tokens) to store the sensitive value passed in the request body. Returns the scrambled value that is the new token name. This operation is available only for users with the EDIT_PROJECT permission (included in the Project Administrator role by default).
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> AddSecureTokenAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.AddSecureTokenAsync(projectLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Returns the value of the given [secure token](https://www.jetbrains.com/help/teamcity/storing-project-settings-in-version-control.html#Managing+Tokens).This operation is available only for users with the CHANGE_SERVER_SETTINGS permission (included only in System Administrator role by default).
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="token">Token.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetSecureValueAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string token,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetSecureValueAsync(projectLocator.ToString(), token, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the settings file of the matching build configuration.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetProjectSettingsFileAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetProjectSettingsFileAsync(projectLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all templates of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildTypes> GetProjectTemplatesAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetProjectTemplatesAsync(projectLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a build configuration template to the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<BuildType> AddTemplateAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        NewBuildTypeDescription body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.AddTemplateAsync(projectLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetProjectFieldAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.GetProjectFieldAsync(projectLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a field of the matching project.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="projectLocator">ProjectLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetProjectFieldAsync(this ITeamCityClient client,
        Locators.ProjectLocator projectLocator,
        string field,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(projectLocator);

        return await client.SetProjectFieldAsync(projectLocator.ToString(), field, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all TeamCity nodes.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">TeamCityNodeLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Node> GetAllNodesAsync(this ITeamCityClient client,
        Locators.TeamCityNodeLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Node, Locators.TeamCityNodeLocator>(
            l => ToAsyncEnumerable(client.GetAllNodesAsync(l.ToString(), fields, cancellationToken), r => r.Node),
            locator ?? new Locators.TeamCityNodeLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get a node matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="nodeLocator">TeamCityNodeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Node> GetNodeAsync(this ITeamCityClient client,
        Locators.TeamCityNodeLocator nodeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(nodeLocator);

        return await client.GetNodeAsync(nodeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all effective responsibilities for a node matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="nodeLocator">TeamCityNodeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<DisabledResponsibilities> GetDisabledResponsibilitiesAsync(this ITeamCityClient client,
        Locators.TeamCityNodeLocator nodeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(nodeLocator);

        return await client.GetDisabledResponsibilitiesAsync(nodeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all effective responsibilities for a node matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="nodeLocator">TeamCityNodeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<EffectiveResponsibilities> GetEffectiveResponsibilitiesAsync(this ITeamCityClient client,
        Locators.TeamCityNodeLocator nodeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(nodeLocator);

        return await client.GetEffectiveResponsibilitiesAsync(nodeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all enabled responsibilities for a node matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="nodeLocator">TeamCityNodeLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<EnabledResponsibilities> GetEnabledResponsibilitiesAsync(this ITeamCityClient client,
        Locators.TeamCityNodeLocator nodeLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(nodeLocator);

        return await client.GetEnabledResponsibilitiesAsync(nodeLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Enables or disables responsibility for a node.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="nodeLocator">TeamCityNodeLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<EnabledResponsibilities> ChangeNodeResponsibilityAsync(this ITeamCityClient client,
        Locators.TeamCityNodeLocator nodeLocator,
        string name,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(nodeLocator);

        return await client.ChangeNodeResponsibilityAsync(nodeLocator.ToString(), name, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all test occurrences.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">TestOccurrenceLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<TestOccurrence> GetAllTestOccurrencesAsync(this ITeamCityClient client,
        Locators.TestOccurrenceLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<TestOccurrence, Locators.TestOccurrenceLocator>(
            l => ToAsyncEnumerable(client.GetAllTestOccurrencesAsync(l.ToString(), fields, cancellationToken), r => r.TestOccurrence),
            locator ?? new Locators.TestOccurrenceLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get a matching test occurrence.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="testLocator">TestOccurrenceLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<TestOccurrence> GetTestOccurrenceAsync(this ITeamCityClient client,
        Locators.TestOccurrenceLocator testLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(testLocator);

        return await client.GetTestOccurrenceAsync(testLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all tests.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">TestLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<Test> GetTestsAsync(this ITeamCityClient client,
        Locators.TestLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<Test, Locators.TestLocator>(
            l => ToAsyncEnumerable(client.GetTestsAsync(l.ToString(), fields, cancellationToken), r => r.Test),
            locator ?? new Locators.TestLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get a matching test.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="testLocator">TestLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Test> GetTestAsync(this ITeamCityClient client,
        Locators.TestLocator testLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(testLocator);

        return await client.GetTestAsync(testLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get user group matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Group> GetUserGroupOfGroupAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.GetUserGroupOfGroupAsync(groupLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete user group matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteGroupAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        await client.DeleteGroupAsync(groupLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get parent groups of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Groups> GetGroupParentGroupsAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.GetGroupParentGroupsAsync(groupLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update parent groups of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Groups> SetGroupParentGroupsAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        Groups body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.SetGroupParentGroupsAsync(groupLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get properties of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetGroupPropertiesAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.GetGroupPropertiesAsync(groupLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a property of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetGroupPropertyAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.GetGroupPropertyAsync(groupLocator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a property of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetGroupPropertyAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string name,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.SetGroupPropertyAsync(groupLocator.ToString(), name, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove a property of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveGroupPropertyAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        await client.RemoveGroupPropertyAsync(groupLocator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all roles of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignments> GetGroupRolesAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.GetGroupRolesAsync(groupLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a role to the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignment> AddRoleToGroupAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        RoleAssignment body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.AddRoleToGroupAsync(groupLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update roles of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignments> SetGroupRolesAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        RoleAssignments body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.SetGroupRolesAsync(groupLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a role with the specific scope of the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="roleId">Role ID.</param>
    /// <param name="scope">Scope.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignment> GetGroupRoleAtScopeAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string roleId,
        string scope,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.GetGroupRoleAtScopeAsync(groupLocator.ToString(), roleId, scope, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a role with the specific scope to the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="roleId">Role ID.</param>
    /// <param name="scope">Scope.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignment> AddRoleAtScopeToGroupAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string roleId,
        string scope,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.AddRoleAtScopeToGroupAsync(groupLocator.ToString(), roleId, scope, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove a role with the specific scope from the matching user group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="roleId">Role ID.</param>
    /// <param name="scope">Scope.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveRoleAtScopeFromGroupAsync(this ITeamCityClient client,
        Locators.UserGroupLocator groupLocator,
        string roleId,
        string scope,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(groupLocator);

        await client.RemoveRoleAtScopeFromGroupAsync(groupLocator.ToString(), roleId, scope, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">UserLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<User> GetAllUsersAsync(this ITeamCityClient client,
        Locators.UserLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<User, Locators.UserLocator>(
            l => ToAsyncEnumerable(client.GetAllUsersAsync(l.ToString(), fields, cancellationToken), r => r.User),
            locator ?? new Locators.UserLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get user matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<User> GetUserAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetUserAsync(userLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update user matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<User> ReplaceUserAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        User body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.ReplaceUserAsync(userLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete user matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteUserAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.DeleteUserAsync(userLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove the RememberMe data of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveUserRememberMeAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.RemoveUserRememberMeAsync(userLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all groups of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Groups> GetAllUserGroupsAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetAllUserGroupsAsync(userLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update groups of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Groups> SetUserGroupsAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        Groups body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.SetUserGroupsAsync(userLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a user group of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Group> GetUserGroupAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        Locators.UserGroupLocator groupLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);
        ArgumentNullException.ThrowIfNull(groupLocator);

        return await client.GetUserGroupAsync(userLocator.ToString(), groupLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove the matching user from the specific group.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="groupLocator">UserGroupLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveUserFromGroupAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        Locators.UserGroupLocator groupLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);
        ArgumentNullException.ThrowIfNull(groupLocator);

        await client.RemoveUserFromGroupAsync(userLocator.ToString(), groupLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Terminate all current sessions of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task LogoutUserAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.LogoutUserAsync(userLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all permissions effective for the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<PermissionAssignments> GetUserPermissionsAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string locator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetUserPermissionsAsync(userLocator.ToString(), locator, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all properties of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetUserPropertiesAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetUserPropertiesAsync(userLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a property of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetUserPropertyAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetUserPropertyAsync(userLocator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a property of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetUserPropertyAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string name,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.SetUserPropertyAsync(userLocator.ToString(), name, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove a property of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveUserPropertyAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.RemoveUserPropertyAsync(userLocator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all user roles of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignments> GetAllUserRolesAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetAllUserRolesAsync(userLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a role to the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignment> AddRoleToUserAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        RoleAssignment body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.AddRoleToUserAsync(userLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update user roles of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignments> SetUserRolesAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        RoleAssignments body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.SetUserRolesAsync(userLocator.ToString(), body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a user role with the specific scope from the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="roleId">Role ID.</param>
    /// <param name="scope">Scope.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignment> GetUserRolesAtScopeAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string roleId,
        string scope,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetUserRolesAtScopeAsync(userLocator.ToString(), roleId, scope, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Add a role with the specific scope to the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="roleId">Role ID.</param>
    /// <param name="scope">Scope.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<RoleAssignment> AddRoleToUserAtScopeAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string roleId,
        string scope,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.AddRoleToUserAtScopeAsync(userLocator.ToString(), roleId, scope, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove a role with the specific scope from the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="roleId">Role ID.</param>
    /// <param name="scope">Scope.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RemoveUserRoleAtScopeAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string roleId,
        string scope,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.RemoveUserRoleAtScopeAsync(userLocator.ToString(), roleId, scope, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all authentication tokens of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Tokens> GetUserTokensAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetUserTokensAsync(userLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Create a new authentication token for the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="body">Request body.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Token> AddUserTokenAsync(this ITeamCityClient client,
        Token body,
        Locators.UserLocator userLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.AddUserTokenAsync(body, userLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove an authentication token from the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteUserTokenAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.DeleteUserTokenAsync(userLocator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetUserFieldAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.GetUserFieldAsync(userLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a field of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetUserFieldAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string field,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        return await client.SetUserFieldAsync(userLocator.ToString(), field, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove a property of the matching user.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="userLocator">UserLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteUserFieldAsync(this ITeamCityClient client,
        Locators.UserLocator userLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(userLocator);

        await client.DeleteUserFieldAsync(userLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all VCS root instances.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">VcsRootInstanceLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<VcsRootInstance> GetAllVcsRootInstancesAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<VcsRootInstance, Locators.VcsRootInstanceLocator>(
            l => ToAsyncEnumerable(client.GetAllVcsRootInstancesAsync(l.ToString(), fields, cancellationToken), r => r.VcsRootInstance),
            locator ?? new Locators.VcsRootInstanceLocator(), itemsPerPage);
    }

    /// <summary>
    /// Check for the pending changes for all VCS root instances.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">VcsRootInstanceLocator. Can be null.</param>
    /// <param name="requestor">Requestor.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootInstances> RequestPendingChangesCheckAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator locator,
        string requestor,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return await client.RequestPendingChangesCheckAsync(locator?.ToString(), requestor, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Send the commit hook notification.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">VcsRootInstanceLocator. Can be null.</param>
    /// <param name="okOnNothingFound">Return OK when nothing was found.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task TriggerCommitHookNotificationAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator locator,
        bool? okOnNothingFound,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        await client.TriggerCommitHookNotificationAsync(locator?.ToString(), okOnNothingFound, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get VCS root instance matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootInstance> GetVcsRootInstanceAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetVcsRootInstanceAsync(vcsRootInstanceLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// List all files.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Files> GetFilesListAsync(this ITeamCityClient client,
        string basePath,
        string locator,
        string fields,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetFilesListAsync(basePath, locator, fields, vcsRootInstanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get specific file zipped.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="name">Name.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> GetZippedFileAsync(this ITeamCityClient client,
        string path,
        string basePath,
        string locator,
        string name,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetZippedFileAsync(path, basePath, locator, name, vcsRootInstanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Download specific file.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<FileResponse> DownloadFileAsync(this ITeamCityClient client,
        string path,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.DownloadFileAsync(path, vcsRootInstanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get metadata of specific file.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<File> GetFileMetadataAsync(this ITeamCityClient client,
        string path,
        string fields,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetFileMetadataAsync(path, fields, vcsRootInstanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// List files under this path.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="path">File path.</param>
    /// <param name="basePath">Base path.</param>
    /// <param name="locator">Locator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Files> GetFilesListForSubpathAsync(this ITeamCityClient client,
        string path,
        string basePath,
        string locator,
        string fields,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetFilesListForSubpathAsync(path, basePath, locator, fields, vcsRootInstanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all properties of the matching VCS root instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetVcsRootInstancePropertiesAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetVcsRootInstancePropertiesAsync(vcsRootInstanceLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the repository state of the matching VCS root instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Entries> GetVcsRootInstanceRepositoryStateAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetVcsRootInstanceRepositoryStateAsync(vcsRootInstanceLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update the repository state of the matching VCS root instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Entries> SetVcsRootInstanceRepositoryStateAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        Entries body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.SetVcsRootInstanceRepositoryStateAsync(vcsRootInstanceLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete the last repository state of the matching VCS root instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteVcsRootInstanceRepositoryStateAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        await client.DeleteVcsRootInstanceRepositoryStateAsync(vcsRootInstanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the creation date of the matching VCS root instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetVcsRootInstanceCreationDateAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetVcsRootInstanceCreationDateAsync(vcsRootInstanceLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching VCS root instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetVcsRootInstanceFieldAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.GetVcsRootInstanceFieldAsync(vcsRootInstanceLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching VCS root instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetVcsRootInstanceFieldAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        string field,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        return await client.SetVcsRootInstanceFieldAsync(vcsRootInstanceLocator.ToString(), field, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove a field of the matching VCS root instance.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootInstanceLocator">VcsRootInstanceLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteVcsRootInstanceFieldAsync(this ITeamCityClient client,
        Locators.VcsRootInstanceLocator vcsRootInstanceLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootInstanceLocator);

        await client.DeleteVcsRootInstanceFieldAsync(vcsRootInstanceLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all VCS roots.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="locator">VcsRootLocator used as a base of the paging request. Can be null.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="itemsPerPage">Number of items requested in a single page.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Async enumerable of all items from all pages.</returns>
    public static IAsyncEnumerable<VcsRoot> GetAllVcsRootsAsync(this ITeamCityClient client,
        Locators.VcsRootLocator locator,
        string fields,
        int itemsPerPage = 100,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        return TeamCityPageExpander.GetAllAsync<VcsRoot, Locators.VcsRootLocator>(
            l => ToAsyncEnumerable(client.GetAllVcsRootsAsync(l.ToString(), fields, cancellationToken), r => r.VcsRoot),
            locator ?? new Locators.VcsRootLocator(), itemsPerPage);
    }

    /// <summary>
    /// Get root endpoints.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRoot> GetRootEndpointsAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.GetRootEndpointsAsync(vcsRootLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Remove VCS root matching the locator.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteVcsRootAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        await client.DeleteVcsRootAsync(vcsRootLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all VCS root instances of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<VcsRootInstances> GetVcsRootInstancesAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.GetVcsRootInstancesAsync(vcsRootLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get all properties of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> GetAllVcsRootPropertiesAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.GetAllVcsRootPropertiesAsync(vcsRootLocator.ToString(), fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update all properties of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="body">Request body.</param>
    /// <param name="fields">Comma-separated list of fields to include in the response.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<Properties> SetVcsRootPropertiesAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        Properties body,
        string fields,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.SetVcsRootPropertiesAsync(vcsRootLocator.ToString(), body, fields, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete all properties of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteAllVcsRootPropertiesAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        await client.DeleteAllVcsRootPropertiesAsync(vcsRootLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a property on the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetVcsRootPropertyAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.GetVcsRootPropertyAsync(vcsRootLocator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a property of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetVcsRootPropertyAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        string name,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.SetVcsRootPropertyAsync(vcsRootLocator.ToString(), name, body, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Delete a property of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="name">Name.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task DeleteVcsRootPropertyAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        string name,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        await client.DeleteVcsRootPropertyAsync(vcsRootLocator.ToString(), name, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get the settings file of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetVcsRootSettingsFileAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.GetVcsRootSettingsFileAsync(vcsRootLocator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get a field of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> GetVcsRootFieldAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        string field,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.GetVcsRootFieldAsync(vcsRootLocator.ToString(), field, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Update a field of the matching VCS root.
    /// </summary>
    /// <param name="client">TeamCity client.</param>
    /// <param name="vcsRootLocator">VcsRootLocator.</param>
    /// <param name="field">Name of the field.</param>
    /// <param name="body">Request body.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task<string> SetVcsRootFieldAsync(this ITeamCityClient client,
        Locators.VcsRootLocator vcsRootLocator,
        string field,
        string body,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(vcsRootLocator);

        return await client.SetVcsRootFieldAsync(vcsRootLocator.ToString(), field, body, cancellationToken)
            .ConfigureAwait(false);
    }

    private static async IAsyncEnumerable<TItem> ToAsyncEnumerable<TCollection, TItem>(Task<TCollection> request,
        Func<TCollection, IEnumerable<TItem>> itemsSelector)
    {
        var collection = await request.ConfigureAwait(false);
        var items = collection == null ? null : itemsSelector(collection);

        if (items == null)
        {
            yield break;
        }

        foreach (var item in items)
        {
            yield return item;
        }
    }
}
