---
kind: method
id: M:Autodesk.Revit.DB.XYZ.IsWithinLengthLimits(Autodesk.Revit.DB.XYZ)
zh: 点
source: html/ac2171af-4250-8a30-faa7-4d7030d29a03.htm
---
# Autodesk.Revit.DB.XYZ.IsWithinLengthLimits Method

**中文**: 点

Validates that the input point is within Revit design limits.

## Syntax (C#)
```csharp
public static bool IsWithinLengthLimits(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to test.

## Returns
True if the input point is within Revit design limits, false otherwise.

## Remarks
Used to validate input for geometry construction methods.

