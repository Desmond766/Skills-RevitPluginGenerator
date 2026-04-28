---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetHookOrientationAngle(System.Int32)
source: html/50bd6278-bbb7-7b6c-029d-e34f7b42ddb9.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetHookOrientationAngle Method

Get the hook orientation angle at end that is currently in the rebar.

## Syntax (C#)
```csharp
public double GetHookOrientationAngle(
	int end
)
```

## Parameters
- **end** (`System.Int32`) - The end of bar. Should be 0 for start or 1 for end.

## Returns
The hook orientation angle at end that is currently in the rebar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Invalid end.

