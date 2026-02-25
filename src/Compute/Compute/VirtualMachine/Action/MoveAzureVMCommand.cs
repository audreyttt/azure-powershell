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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Move", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupNameParameterSet)]
    [OutputType(typeof(PSComputeLongRunningOperation), typeof(PSAzureOperationResponse))]
    public class MoveAzureVMCommand : VirtualMachineActionBaseCmdlet
    {
        [Alias("VMName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ParameterSetName = ResourceGroupNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target availability zone of the Virtual Machine migration to Flexible Virtual Machine Scale Set (VMSS).")]
        [ValidateNotNullOrEmpty]
        public string TargetZone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target compute fault domain of the Virtual Machine migration to Flexible Virtual Machine Scale Set (VMSS).")]
        public int? TargetFaultDomain { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target Virtual Machine size for the Virtual Machine migration to Flexible Virtual Machine Scale Set (VMSS).")]
        [ValidateNotNullOrEmpty]
        public string TargetVMSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.")]
        public SwitchParameter NoWait { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(Name, "Move"))
            {
                base.ExecuteCmdlet();
                ExecuteClientAction(() =>
                {
                    if (ParameterSetName.Equals(IdParameterSet) && string.IsNullOrEmpty(Name))
                    {
                        ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                        this.ResourceGroupName = parsedId.ResourceGroupName;
                        this.Name = parsedId.ResourceName;
                    }

                    var migrateParams = new MigrateVMToVirtualMachineScaleSetInput();

                    if (this.IsParameterBound(c => c.TargetZone))
                    {
                        migrateParams.TargetZone = this.TargetZone;
                    }

                    if (this.IsParameterBound(c => c.TargetFaultDomain))
                    {
                        migrateParams.TargetFaultDomain = this.TargetFaultDomain;
                    }

                    if (this.IsParameterBound(c => c.TargetVMSize))
                    {
                        migrateParams.TargetVMSize = this.TargetVMSize;
                    }

                    if (NoWait.IsPresent)
                    {
                        var op = this.VirtualMachineClient.BeginMigrateToVMScaleSetWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name,
                            migrateParams).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                    else
                    {
                        var op = this.VirtualMachineClient.MigrateToVMScaleSetWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.Name,
                            migrateParams).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                        result.StartTime = this.StartTime;
                        result.EndTime = DateTime.Now;
                        WriteObject(result);
                    }
                });
            }
        }
    }
}
