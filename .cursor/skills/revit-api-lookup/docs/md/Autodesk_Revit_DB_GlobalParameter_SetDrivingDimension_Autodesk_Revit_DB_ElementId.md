---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.SetDrivingDimension(Autodesk.Revit.DB.ElementId)
source: html/017b2d21-0ed9-fc04-dd7c-19d78214859d.htm
---
# Autodesk.Revit.DB.GlobalParameter.SetDrivingDimension Method

Set a dimension to drive the value of this parameter.

## Syntax (C#)
```csharp
public void SetDrivingDimension(
	ElementId dimensionId
)
```

## Parameters
- **dimensionId** (`Autodesk.Revit.DB.ElementId`) - Id of a dimension element.

## Remarks
This method is a combined action of two steps: a) Making the parameter reporting if
 it is not yet, and b) Labeling the given dimension with it. Because of that, the
 parameter must be eligible for reporting - i.e must be of certain types, and must
 not be used to label more than one dimensions yet. In case this parameter is already driven by another dimension, the other
 dimension will be unlabeled first before the given one is labeled. It is because
 a reporting parameter can only label one dimension at a time (i.e. it can be
 driven by one dimension only.)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Given element Id is not of a valid dimension element.
 -or-
 Dimension with the Id of dimensionId cannot be labeled by this global parameter.
 Possible causes include the dimension cannot be labeled at all, or it is a dimension
 of other than Linear or Angular type, or the Dimension object does not have the
 appropriate labeling parameter, or the dimension has more than one segment and the parameter
 is reporting.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This is a formula-driven parameter. As such it does not allow the current operation.
 -or-
 This non-reporting global parameter has already labeled other dimension segments (more then 1).
 It cannot, therefore, be made reporting and dimension-driven before un-labeling all
 the dependent dimensions first.

