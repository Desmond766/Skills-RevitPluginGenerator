---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.SetHookRotationAngle(System.Double,System.Int32)
source: html/b30a6f55-b672-e942-7c1f-ab3d9b27dd4e.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.SetHookRotationAngle Method

Sets the out of plane hook rotation angle at the specified end.

## Syntax (C#)
```csharp
public void SetHookRotationAngle(
	double hookRotationAngle,
	int iEnd
)
```

## Parameters
- **hookRotationAngle** (`System.Double`) - The out of plane hook rotation angle at the specified end.
- **iEnd** (`System.Int32`) - 0 for the start , 1 for the end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - iEnd must be 0 or 1.

