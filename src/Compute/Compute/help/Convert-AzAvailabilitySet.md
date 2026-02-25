---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/convert-azavailabilityset
schema: 2.0.0
---

# Convert-AzAvailabilitySet

## SYNOPSIS
Converts an Availability Set to a new Flexible Virtual Machine Scale Set (VMSS) without triggering downtime on the Virtual Machines.

## SYNTAX

```
Convert-AzAvailabilitySet [-ResourceGroupName] <String> [-Name] <String>
 [-VirtualMachineScaleSetName <String>] [-AsJob] [-NoWait] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Convert-AzAvailabilitySet** cmdlet creates a new Flexible Virtual Machine Scale Set (VMSS) and migrates all Virtual Machines in the Availability Set to it. This operation does not trigger a downtime on the Virtual Machines.

## EXAMPLES

### Example 1: Convert an Availability Set to a new VMSS
```powershell
Convert-AzAvailabilitySet -ResourceGroupName "MyResourceGroup" -Name "MyAvailabilitySet" -VirtualMachineScaleSetName "MyScaleSet"
```

This command converts the availability set named MyAvailabilitySet in the resource group MyResourceGroup to a new Flexible Virtual Machine Scale Set named MyScaleSet.

### Example 2: Convert an Availability Set to a VMSS with an auto-generated name
```powershell
Convert-AzAvailabilitySet -ResourceGroupName "MyResourceGroup" -Name "MyAvailabilitySet"
```

This command converts the availability set named MyAvailabilitySet to a new Flexible Virtual Machine Scale Set with an auto-generated name.

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

### -NoWait
Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.

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

### -VirtualMachineScaleSetName
The name of the new Virtual Machine Scale Set to create and migrate the Availability Set Virtual Machines into.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

[Start-AzAvailabilitySetMigration](./Start-AzAvailabilitySetMigration.md)

[Stop-AzAvailabilitySetMigration](./Stop-AzAvailabilitySetMigration.md)

[Test-AzAvailabilitySetMigration](./Test-AzAvailabilitySetMigration.md)

[Move-AzVM](./Move-AzVM.md)
