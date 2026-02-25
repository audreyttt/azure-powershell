// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilitySetMigration")]
    [OutputType(typeof(PSComputeLongRunningOperation), typeof(PSAzureOperationResponse))]
    public class TestAzureAvailabilitySetMigrationCommand : AvailabilitySetBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("AvailabilitySetName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The availability set name.")]
        [ResourceNameCompleter("Microsoft.Compute/availabilitySets", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource ID of the Flexible Virtual Machine Scale Set to migrate the Availability Set Virtual Machines to.")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineScaleSetId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                var vmssRef = new SubResource(this.VirtualMachineScaleSetId);

                var op = this.AvailabilitySetClient.ValidateMigrationToVirtualMachineScaleSetWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.Name,
                    vmssRef).GetAwaiter().GetResult();
                var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                result.StartTime = this.StartTime;
                result.EndTime = DateTime.Now;
                WriteObject(result);
            });
        }
    }
}
