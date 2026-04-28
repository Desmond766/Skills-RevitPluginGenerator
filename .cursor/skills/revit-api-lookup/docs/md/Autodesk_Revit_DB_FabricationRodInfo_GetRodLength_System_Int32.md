---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.GetRodLength(System.Int32)
source: html/ec9de605-8993-9845-37b2-1c302122849c.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.GetRodLength Method

Get the current rod length. If the rod is the length will include structural extension.

## Syntax (C#)
```csharp
public double GetRodLength(
	int rodIndex
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The rod index.

## Returns
Returns rod length of hanger for specified end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.

