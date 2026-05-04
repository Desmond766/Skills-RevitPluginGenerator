---
kind: method
id: M:Autodesk.Revit.DB.ValueAtPointBase.SetFlags(System.Int32,System.Int32)
source: html/6d1e3b3e-bfce-3a5b-a31e-55ba6c408635.htm
---
# Autodesk.Revit.DB.ValueAtPointBase.SetFlags Method

Sets the flags associated to a given measurement.

## Syntax (C#)
```csharp
public void SetFlags(
	int flags,
	int measurement
)
```

## Parameters
- **flags** (`System.Int32`) - The value of the flags to set.
 Flags values are defined in the enumerated class ValueAtPointFlags and are combined into the int value.
- **measurement** (`System.Int32`) - Measurement for which to set flags.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for measurement is negative.

