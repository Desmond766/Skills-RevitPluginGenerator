---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.GetHookRotationAngle(System.Int32)
source: html/76a3c46d-031e-37c6-d8c2-3342a60d8bc5.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.GetHookRotationAngle Method

Gets the out of plane hook rotation angle at the specified end.

## Syntax (C#)
```csharp
public double GetHookRotationAngle(
	int iEnd
)
```

## Parameters
- **iEnd** (`System.Int32`) - 0 for the start , 1 for the end.

## Returns
Returns the out of plane hook rotation angle at the specified end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - iEnd must be 0 or 1.

