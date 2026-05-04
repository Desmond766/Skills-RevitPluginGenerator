---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.CanSplitStraight(Autodesk.Revit.DB.XYZ)
source: html/9c9f65ce-8f20-85ea-4c7e-5a2a19762188.htm
---
# Autodesk.Revit.DB.FabricationPart.CanSplitStraight Method

Validates if the straight can be split into two at the passed in point.

## Syntax (C#)
```csharp
public bool CanSplitStraight(
	XYZ position
)
```

## Parameters
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to split in the straight.

## Returns
Returns true if valid otherwise false if the straight cannot be split.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

