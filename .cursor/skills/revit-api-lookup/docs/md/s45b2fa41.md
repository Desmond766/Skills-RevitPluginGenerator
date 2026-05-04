---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.IsCoverOffsetValid(System.Double)
source: html/55e266df-8cb2-0f2c-4fab-492089461196.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.IsCoverOffsetValid Method

Identifies if the specified value is valid for use as a cover offset.

## Syntax (C#)
```csharp
public bool IsCoverOffsetValid(
	double coverOffset
)
```

## Parameters
- **coverOffset** (`System.Double`) - The cover offset value.

## Returns
True if the value is valid, false if the value is invalid.

## Remarks
The cover offset must be less than or equal to the host thickness.

