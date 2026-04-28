---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.LabelDimension(Autodesk.Revit.DB.ElementId)
source: html/99bc1f7d-82b8-7dc1-9919-e73834bb565c.htm
---
# Autodesk.Revit.DB.GlobalParameter.LabelDimension Method

Labels a dimension with this global parameter.

## Syntax (C#)
```csharp
public void LabelDimension(
	ElementId dimensionId
)
```

## Parameters
- **dimensionId** (`Autodesk.Revit.DB.ElementId`) - Id of a dimension element.

## Remarks
When a dimension is labeled by a global parameters, then its value is either
 controlled by the parameter (non-reporting), or drives the value of the
 parameter (reporting). It is important to note that a reporting parameter
 can label at most one dimension object - meaning, a parameter can be driven
 by one dimension only. If the dimension has several segments and is labeled by a non-reprting parameter,
 the value of each segment will be driven by this parameter. Multi-segmented dimensions
 cannot be labeled by reporting parameters. If the dimension is already labeled by another global parameter,
 labeling it again will automatically detach it from that parameter. Presently, not just any kind of dimensions may be labeled by a global parameter.
 Typically only single Linear and Angular dimensions can be labeled,
 but there are other restrictions in effect too. Also, for the value of the parameter
 and dimension labeled by it depend on each other, the data type of the global parameters
 must be either Length or Angle , since those are the only units a dimension
 can represent. Refer to the [!:CanLabelDimension(Autodesk::Revit::DB::ElementId)] 
 method to find out whether a particular dimension element may be labeled or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Given element Id is not of a valid dimension element.
 -or-
 Dimension with the Id of dimensionId cannot be labeled by this global parameter.
 Possible causes include the dimension cannot be labeled at all, or it is a dimension
 of other than Linear or Angular type, or the Dimension object does not have the
 appropriate labeling parameter, or the dimension has more than one segment and the parameter
 is reporting.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

