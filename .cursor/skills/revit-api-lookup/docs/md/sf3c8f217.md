---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetHookRotationAngle(System.Int32)
zh: 钢筋、配筋
source: html/0217f682-0c09-2b77-02d4-89c494a11cc9.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetHookRotationAngle Method

**中文**: 钢筋、配筋

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

