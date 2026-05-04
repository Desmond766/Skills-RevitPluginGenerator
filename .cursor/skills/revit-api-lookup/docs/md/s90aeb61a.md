---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CableTray.IsValidRungSpace(System.Double)
zh: 桥架、线槽
source: html/88b77d6f-cb23-83fd-72c9-86c3bc39e872.htm
---
# Autodesk.Revit.DB.Electrical.CableTray.IsValidRungSpace Method

**中文**: 桥架、线槽

Identifies if the input rung space is valid.

## Syntax (C#)
```csharp
public bool IsValidRungSpace(
	double rungSpace
)
```

## Parameters
- **rungSpace** (`System.Double`) - The rung space to check.

## Returns
True if the value is acceptable, false otherwise.

## Remarks
rung space should be at least equal to or larger than rang width which is 1 inch.

