// See the LICENSE.TXT file in the project root for full license information.

using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    // https://docs.microsoft.com/azure/governance/policy/concepts/definition-structure#metadata
    public record AssignmentMetadata : IUtf8JsonSerializable
    {
        public AssignmentMetadata(string assignedBy, string createdBy, bool createdOn, string updatedBy, string updatedOn, params KeyValuePair<string, string>[] parameterScopes)
        {
            this.AssignedBy = assignedBy;
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.UpdatedBy = updatedBy;
            this.UpdatedOn = updatedOn;
            this.ParameterScopes = parameterScopes;
        }

        /// <summary>
        /// Gets the friendly name of the security principal that created the assignment.
        /// </summary>
        public string AssignedBy { get; }

        /// <summary>
        /// Gets the GUID of the security principal that created the assignment.
        /// </summary>
        public string CreatedBy { get; }

        /// <summary>
        ///  Gets a value indicating whether the Universal ISO 8601 DateTime format of the assignment creation time.
        /// </summary>
        public bool CreatedOn { get; }

        /// <summary>
        ///  Gets the friendly name of the security principal that updated the assignment, if any.
        /// </summary>
        public string UpdatedBy { get; }

        /// <summary>
        /// Gets the Universal ISO 8601 DateTime format of the assignment update time, if any.
        /// </summary>
        public string UpdatedOn { get; }

        /// <summary>
        /// Gets a collection of key-value pairs where the key matches a <see href="https://docs.microsoft.com/azure/governance/policy/concepts/definition-structure#strongtype">strongType</see> configured parameter name and the value defines the resource scope used in Portal to provide the list of available resources by matching strongType. Portal sets this value if the scope is different than the assignment scope. If set, an edit of the policy assignment in Portal automatically sets the scope for the parameter to this value. However, the scope isn't locked to the value and it can be changed to another scope.
        /// </summary>
        /// <example>
        /// The following example of <c>parameterScopes</c> is for a strongType parameter named backupPolicyId that sets a scope for resource selection when the assignment is edited in the Portal.
        /// <code>
        /// "metadata": {
        ///    "parameterScopes": {
        ///        "backupPolicyId": "/subscriptions/{SubscriptionID}/resourcegroups/{ResourceGroupName}"
        ///    }
        /// }
        /// </code>
        /// </example>
        public IEnumerable<KeyValuePair<string, string>> ParameterScopes { get; }

        public void Write(Utf8JsonWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
