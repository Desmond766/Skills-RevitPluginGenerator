---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetHookOrientationAngle(System.Int32)
source: html/65b56092-69cf-d374-8e0f-689c91c53586.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetHookOrientationAngle Method

Get the hook orientation angle at end.

## Syntax (C#)
```csharp
public double GetHookOrientationAngle(
	int end
)
```

## Parameters
- **end** (`System.Int32`) - The end of bar. Should be 0 for start or 1 for end.

## Returns
The hook orientation angle at end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Invalid end.

