---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricArea.IsCoverOffsetValid(System.Double)
source: html/81963ad4-c71e-481d-3b62-d7942bcaaab3.htm
---
# Autodesk.Revit.DB.Structure.FabricArea.IsCoverOffsetValid Method

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

