---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/move-azvm
schema: 2.0.0
---

# Move-AzVM

## SYNOPSIS
Migrates a Virtual Machine to a Flexible Virtual Machine Scale Set (VMSS). This triggers a downtime on the Virtual Machine.

## SYNTAX

### ResourceGroupNameParameterSetName (Default)
```
Move-AzVM [-ResourceGroupName] <String> [-Name] <String> [-TargetZone <String>]
 [-TargetFaultDomain <Int32>] [-TargetVMSize <String>] [-AsJob] [-NoWait]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### IdParameterSetName
```
Move-AzVM [-Id] <String> [-TargetZone <String>] [-TargetFaultDomain <Int32>] [-TargetVMSize <String>]
 [-AsJob] [-NoWait] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Move-AzVM** cmdlet migrates a Virtual Machine to a Flexible Virtual Machine Scale Set (VMSS). This operation triggers a downtime on the Virtual Machine. This cmdlet is used as part of the Availability Set to VMSS migration workflow, after running **Start-AzAvailabilitySetMigration**.

## EXAMPLES

### Example 1: Migrate a VM to a VMSS with a specific zone and fault domain
```powershell
Move-AzVM -ResourceGroupName "MyResourceGroup" -Name "VM1" -TargetZone "1" -TargetFaultDomain 0 -TargetVMSize "Standard_DS2_v2"
```

This command migrates the virtual machine named VM1 in the resource group MyResourceGroup to a Flexible VMSS, placing it in zone 1, fault domain 0, and resizing it to Standard_DS2_v2.

### Example 2: Migrate a VM using its resource ID
```powershell
Move-AzVM -Id "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/VM1" -TargetZone "2"
```

This command migrates the virtual machine identified by the given resource ID to a Flexible VMSS in zone 2.

### Example 3: Migrate a VM without specifying target placement
```powershell
Move-AzVM -ResourceGroupName "MyResourceGroup" -Name "VM1"
```

This command migrates the virtual machine named VM1 to the associated Flexible VMSS without specifying a target zone, fault domain, or VM size.

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

### -Id
The ID of the virtual machine.

```yaml
Type: System.String
Parameter Sets: IdParameterSetName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The virtual machine name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupNameParameterSetName
Aliases: VMName

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
Parameter Sets: ResourceGroupNameParameterSetName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetFaultDomain
The target compute fault domain of the Virtual Machine migration to Flexible Virtual Machine Scale Set (VMSS).

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetVMSize
The target Virtual Machine size for the Virtual Machine migration to Flexible Virtual Machine Scale Set (VMSS).

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

### -TargetZone
The target availability zone of the Virtual Machine migration to Flexible Virtual Machine Scale Set (VMSS).

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

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSComputeLongRunningOperation

### Microsoft.Azure.Commands.Compute.Models.PSAzureOperationResponse

## NOTES

## RELATED LINKS

[Convert-AzAvailabilitySet](./Convert-AzAvailabilitySet.md)

[Start-AzAvailabilitySetMigration](./Start-AzAvailabilitySetMigration.md)

[Stop-AzAvailabilitySetMigration](./Stop-AzAvailabilitySetMigration.md)

[Test-AzAvailabilitySetMigration](./Test-AzAvailabilitySetMigration.md)
