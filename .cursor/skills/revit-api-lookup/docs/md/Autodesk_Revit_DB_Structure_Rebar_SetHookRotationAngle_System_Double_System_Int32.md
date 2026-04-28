---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetHookRotationAngle(System.Double,System.Int32)
zh: 钢筋、配筋
source: html/399efb81-f360-4e7b-bbc3-938325f0baba.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetHookRotationAngle Method

**中文**: 钢筋、配筋

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

