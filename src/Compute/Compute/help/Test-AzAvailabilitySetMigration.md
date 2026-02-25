---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/test-azavailabilitysetmigration
schema: 2.0.0
---

# Test-AzAvailabilitySetMigration

## SYNOPSIS
Validates that the Virtual Machines in an Availability Set can be migrated to a Flexible Virtual Machine Scale Set (VMSS).

## SYNTAX

```
Test-AzAvailabilitySetMigration [-ResourceGroupName] <String> [-Name] <String>
 -VirtualMachineScaleSetId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Test-AzAvailabilitySetMigration** cmdlet validates that the Virtual Machines in the specified Availability Set can be migrated to the provided Flexible Virtual Machine Scale Set (VMSS).

## EXAMPLES

### Example 1: Validate migration of an Availability Set to an existing VMSS
```powershell
Test-AzAvailabilitySetMigration -ResourceGroupName "MyResourceGroup" -Name "MyAvailabilitySet" -VirtualMachineScaleSetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachineScaleSets/MyFlexibleVMSS"
```

This command validates whether the virtual machines in the availability set named MyAvailabilitySet can be migrated to the Flexible VMSS identified by the given resource ID.

## PARAMETERS

### -AsJob
Run cmdlet in the background and return a Job to track progress.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The availability set name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AvailabilitySetName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualMachineScaleSetId
The resource ID of the Flexible Virtual Machine Scale Set to migrate the Availability Set Virtual Machines to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSComputeLongRunningOperation

### Microsoft.Azure.Commands.Compute.Models.PSAzureOperationResponse

## NOTES

## RELATED LINKS

[Convert-AzAvailabilitySet](./Convert-AzAvailabilitySet.md)

[Start-AzAvailabilitySetMigration](./Start-AzAvailabilitySetMigration.md)

[Stop-AzAvailabilitySetMigration](./Stop-AzAvailabilitySetMigration.md)

[Move-AzVM](./Move-AzVM.md)
