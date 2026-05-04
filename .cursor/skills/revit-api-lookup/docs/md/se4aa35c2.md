---
kind: method
id: M:Autodesk.Revit.DB.ValueAtPointBase.ClearFlagsAt(System.Int32)
source: html/031eb89d-71e5-f986-cf5b-e586f8d11f67.htm
---
# Autodesk.Revit.DB.ValueAtPointBase.ClearFlagsAt Method

Sets flags for the given measurement to ValueAtPointFlags::None.

## Syntax (C#)
```csharp
public void ClearFlagsAt(
	int measurement
)
```

## Parameters
- **measurement** (`System.Int32`) - Measurement for which to clear flags.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for measurement is negative.

