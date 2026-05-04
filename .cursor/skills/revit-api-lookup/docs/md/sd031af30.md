---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.SetMeasurementNames(System.Collections.Generic.IList{System.String})
source: html/b1788e10-5a95-d180-0569-011e6c3fecdd.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.SetMeasurementNames Method

Sets Names for all measurements

## Syntax (C#)
```csharp
public void SetMeasurementNames(
	IList<string> measurementNames
)
```

## Parameters
- **measurementNames** (`System.Collections.Generic.IList < String >`) - Array of measurement names. All names in the array must be unique.
 The lengths of the array must be equal to the number of measurements set during creation of SpatialFieldManager.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - measurementNames contains duplicate names or its lengths is not equal to the number of measurements set during creation of SpatialFieldManager
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

