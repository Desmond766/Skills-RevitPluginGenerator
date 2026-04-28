---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewPointRelativeToPoint(Autodesk.Revit.DB.Reference)
source: html/11a52fd7-02f7-2293-2520-8e716850c908.htm
---
# Autodesk.Revit.Creation.Application.NewPointRelativeToPoint Method

Create a PointRelativeToPoint object, which is used to define 
the placement of a ReferencePoint relative to a host point.

## Syntax (C#)
```csharp
public PointRelativeToPoint NewPointRelativeToPoint(
	Reference hostPointReference
)
```

## Parameters
- **hostPointReference** (`Autodesk.Revit.DB.Reference`) - The reference of the host point.

## Returns
If creation is successful then a new PointRelativeToPoint object is returned,
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument hostPointReference is Nothing nullptr a null reference ( Nothing in Visual Basic) .

