---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetHookOrientationAngle(System.Int32,System.Double)
source: html/1bd55100-b071-0a46-c349-65cf46eb417f.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetHookOrientationAngle Method

Set the hook orientation angle at end. Will throw exception if the rebar has valid constraints.

## Syntax (C#)
```csharp
public void SetHookOrientationAngle(
	int end,
	double angle
)
```

## Parameters
- **end** (`System.Int32`) - The end of bar. Should be 0 for start or 1 for end.
- **angle** (`System.Double`) - The hook orientation angle at end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Invalid end.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor Rebar is constrained.

