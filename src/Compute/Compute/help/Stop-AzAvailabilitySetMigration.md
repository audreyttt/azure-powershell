---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/stop-azavailabilitysetmigration
schema: 2.0.0
---

# Stop-AzAvailabilitySetMigration

## SYNOPSIS
Cancels an ongoing migration of an Availability Set to a Flexible Virtual Machine Scale Set (VMSS).

## SYNTAX

```
Stop-AzAvailabilitySetMigration [-ResourceGroupName] <String> [-Name] <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzAvailabilitySetMigration** cmdlet cancels an ongoing migration operation on an Availability Set that was started using **Start-AzAvailabilitySetMigration**.

## EXAMPLES

### Example 1: Cancel an ongoing Availability Set migration
```powershell
Stop-AzAvailabilitySetMigration -ResourceGroupName "MyResourceGroup" -Name "MyAvailabilitySet"
```

This command cancels the ongoing migration of the availability set named MyAvailabilitySet in the resource group MyResourceGroup.

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

[Convert-AzAvailabilitySet](./Convert-AzAvailabilitySet.md)

[Start-AzAvailabilitySetMigration](./Start-AzAvailabilitySetMigration.md)

[Test-AzAvailabilitySetMigration](./Test-AzAvailabilitySetMigration.md)

[Move-AzVM](./Move-AzVM.md)
