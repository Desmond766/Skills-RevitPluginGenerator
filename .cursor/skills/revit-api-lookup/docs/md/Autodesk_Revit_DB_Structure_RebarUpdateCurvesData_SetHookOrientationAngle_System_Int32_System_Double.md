---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.SetHookOrientationAngle(System.Int32,System.Double)
source: html/182e024d-55e6-24e7-4125-a1288a2cb7a1.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.SetHookOrientationAngle Method

Set the hook orientation angle at end. This information is set to the rebar after the API execution is finished successfully.

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

