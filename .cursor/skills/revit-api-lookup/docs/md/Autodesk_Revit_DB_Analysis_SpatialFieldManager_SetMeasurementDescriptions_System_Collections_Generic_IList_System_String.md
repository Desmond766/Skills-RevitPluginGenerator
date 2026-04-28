---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.SetMeasurementDescriptions(System.Collections.Generic.IList{System.String})
source: html/3d018bf9-651c-7d7f-38b0-6a37f95a9124.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.SetMeasurementDescriptions Method

Sets Descriptions for all measurements

## Syntax (C#)
```csharp
public void SetMeasurementDescriptions(
	IList<string> measurementDescriptions
)
```

## Parameters
- **measurementDescriptions** (`System.Collections.Generic.IList < String >`) - Array of measurement descriptions.
 The lengths of the array must be equal to the number of measurements set during creation of SpatialFieldManager.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - measurementDescriptions lengths is not equal to the number of measurements set during creation of SpatialFieldManager
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

