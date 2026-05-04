---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.CanLabelDimension(Autodesk.Revit.DB.ElementId)
source: html/be059016-a7dc-6995-0f11-f56f59555183.htm
---
# Autodesk.Revit.DB.GlobalParameter.CanLabelDimension Method

Tests whether a dimension can be labeled by the global parameter.

## Syntax (C#)
```csharp
public bool CanLabelDimension(
	ElementId dimensionId
)
```

## Parameters
- **dimensionId** (`Autodesk.Revit.DB.ElementId`) - Id of a dimension element.

## Returns
True of the input dimension can be labeled by this global parameter; False oterwise.

## Remarks
Possible causes include a dimension that cannot be labeled at all, or it is
 of other than Linear or Angular type, or does not have the appropriate labeling
 parameter. Another reason for this method returning False is that the data type of this
 global parameter is not suitable for labeling (i.e. it contains neither Length nor Angle value),
 or the parameter is reporting and the dimension has more than one segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

