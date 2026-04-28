---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctLiningType.IsValidRoughness(System.Double)
source: html/6e7b8ac7-1555-4cde-1cfe-8b4ae9e0b232.htm
---
# Autodesk.Revit.DB.Mechanical.DuctLiningType.IsValidRoughness Method

Identifies if the input roughness is valid.

## Syntax (C#)
```csharp
public bool IsValidRoughness(
	double roughness
)
```

## Parameters
- **roughness** (`System.Double`) - The roughness to check.

## Returns
True if the value is acceptable, false otherwise.

## Remarks
Roughness should be at least equal to or larger than 0.

