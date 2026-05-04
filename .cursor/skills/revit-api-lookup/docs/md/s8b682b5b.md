---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.CreateSpatialFieldManager(Autodesk.Revit.DB.View,System.Int32)
source: html/58b9c9f7-db28-6dee-8ca4-5d1ca96b70d5.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.CreateSpatialFieldManager Method

Factory method - creates manager object for the given view

## Syntax (C#)
```csharp
public static SpatialFieldManager CreateSpatialFieldManager(
	View view,
	int numberOfMeasurements
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - View for which manager object is created or retrieved
- **numberOfMeasurements** (`System.Int32`) - Total number of measurements in the calculated results.
 This number defines the length of value arrays in ValueAtPoint objects

## Returns
Manager object for the view passed in the argument

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - numberOfMeasurements is less than one
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View is not allowed to display analysis results or a manager object for this view already exists

