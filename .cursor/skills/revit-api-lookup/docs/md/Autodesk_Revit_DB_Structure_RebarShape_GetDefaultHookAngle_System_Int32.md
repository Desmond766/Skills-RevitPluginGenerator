---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.GetDefaultHookAngle(System.Int32)
source: html/89fe9654-9f1c-6ba8-d87c-1b38b63feb31.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.GetDefaultHookAngle Method

Get the hook angle, expressed as an integral number of degrees (common values are 0, 90, 135, and 180).

## Syntax (C#)
```csharp
public int GetDefaultHookAngle(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - 0 for the starting hook, 1 for the ending hook.

## Remarks
Replaces the method GetHookAngle() from prior releases.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index must be 0 or 1.

