---
kind: method
id: M:Autodesk.Revit.DB.ValueAtPointBase.GetFlags(System.Int32)
source: html/140ca529-26a6-4a19-f5d9-9fe199aa89a8.htm
---
# Autodesk.Revit.DB.ValueAtPointBase.GetFlags Method

Returns flags for the given measurement.

## Syntax (C#)
```csharp
public int GetFlags(
	int measurement
)
```

## Parameters
- **measurement** (`System.Int32`) - Measurement number for which flags are returned.

## Returns
Flags value for the measurement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for measurement is negative.

