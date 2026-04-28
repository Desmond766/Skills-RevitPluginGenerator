---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheetType.GetWireItem(System.Int32,Autodesk.Revit.DB.Structure.WireDistributionDirection)
source: html/2cceb1d7-9370-8e64-c2eb-80d8e4083e4b.htm
---
# Autodesk.Revit.DB.Structure.FabricSheetType.GetWireItem Method

Gets the Wire stored in the FabricSheetType at the associated index.

## Syntax (C#)
```csharp
public FabricWireItem GetWireItem(
	int wireIndex,
	WireDistributionDirection direction
)
```

## Parameters
- **wireIndex** (`System.Int32`) - Item index in the Fabric Sheet
- **direction** (`Autodesk.Revit.DB.Structure.WireDistributionDirection`) - Wire distribution direction of the inquired item

## Returns
Fabric wire Item

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The item index is either less than 0 or greater than or equal to number of items in this FabricSheetType.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Fabric Sheet is not Custom

