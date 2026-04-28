---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.GetWireCenterlines(Autodesk.Revit.DB.Structure.WireDistributionDirection)
source: html/bf8d60d3-0fe5-0561-4034-7ae3fcb2482d.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.GetWireCenterlines Method

Gets a list of curves representing the wires centerlines of the Fabric Sheet.

## Syntax (C#)
```csharp
public IList<Curve> GetWireCenterlines(
	WireDistributionDirection wireDirection
)
```

## Parameters
- **wireDirection** (`Autodesk.Revit.DB.Structure.WireDistributionDirection`) - The direction of wire distribution in the Fabric Sheet.

## Returns
The centerline curves.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

