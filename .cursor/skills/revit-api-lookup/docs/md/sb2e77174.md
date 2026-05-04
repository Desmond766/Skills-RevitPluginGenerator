---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.GetDefaultHookOrientation(System.Int32)
source: html/2a97de53-42d6-cf64-f998-73ad9b79fcf0.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.GetDefaultHookOrientation Method

Get the hook orientation.

## Syntax (C#)
```csharp
public RebarHookOrientation GetDefaultHookOrientation(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - 0 for the starting hook, 1 for the ending hook.

## Remarks
Replaces the method GetHookOrientation() from prior releases.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index must be 0 or 1.

