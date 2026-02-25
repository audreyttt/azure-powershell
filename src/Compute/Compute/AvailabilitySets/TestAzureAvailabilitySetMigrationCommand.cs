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
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilitySetMigration", DefaultParameterSetName = ResourceGroupNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSComputeLongRunningOperation), typeof(PSAzureOperationResponse))]
    public class TestAzureAvailabilitySetMigrationCommand : AvailabilitySetBaseCmdlet
    {
        protected const string ResourceGroupNameParameterSet = "ResourceGroupNameParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("AvailabilitySetName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = ResourceGroupNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The availability set name.")]
        [ResourceNameCompleter("Microsoft.Compute/availabilitySets", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The availability set object.")]
        [ValidateNotNullOrEmpty]
        public PSAvailabilitySet InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ParameterSetName = ResourceGroupNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource ID of the Flexible Virtual Machine Scale Set to validate migration to.")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource ID of the Flexible Virtual Machine Scale Set to validate migration to.")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineScaleSetFlexibleId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(Name, "Validate Availability Set Migration to Virtual Machine Scale Set"))
            {
                ExecuteClientAction(() =>
                {
                    var vmssReference = new SubResource(this.VirtualMachineScaleSetFlexibleId);

                    var op = this.AvailabilitySetClient.ValidateMigrationToVirtualMachineScaleSetWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.Name,
                        vmssReference).GetAwaiter().GetResult();
                    var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                    result.StartTime = this.StartTime;
                    result.EndTime = DateTime.Now;
                    WriteObject(result);
                });
            }
        }
    }
}
