---
kind: method
id: M:Autodesk.Revit.DB.ValueAtPointBase.SetFlags(System.Collections.Generic.IList{System.Int32})
source: html/91abfaff-2abe-225d-ab00-f8b301b81392.htm
---
# Autodesk.Revit.DB.ValueAtPointBase.SetFlags Method

Independently sets the flags associated to all measurements.

## Syntax (C#)
```csharp
public void SetFlags(
	IList<int> flags
)
```

## Parameters
- **flags** (`System.Collections.Generic.IList < Int32 >`) - An array of flags values. Each member corresponds to a measurement.
 Flags values are defined in the enumerated class ValueAtPointFlags and are combined into the int value.
 Number of measurements is set at creation of SpatialFieldManager in method createSpatialFieldManager.

## Remarks
If you set the array of flags to only contain one value, this flags value will apply to all measurements

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

