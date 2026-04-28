---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsValidSampleHeight(System.Double)
source: html/28d6814a-099a-1f81-0bd1-90505a7a5fdf.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsValidSampleHeight Method

Is the specified height a valid sample height for this compound structure?

## Syntax (C#)
```csharp
public bool IsValidSampleHeight(
	double height
)
```

## Parameters
- **height** (`System.Double`)

## Remarks
The sample height cannot be less than the value of MinimumSampleHeight.

