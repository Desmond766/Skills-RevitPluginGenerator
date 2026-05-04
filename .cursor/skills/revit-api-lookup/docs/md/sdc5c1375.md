---
kind: method
id: M:Autodesk.Revit.DB.Sketch.GetAllElements
source: html/2c93758e-684c-5f84-9206-f04e5ceb15d5.htm
---
# Autodesk.Revit.DB.Sketch.GetAllElements Method

Returns all elements which belong to the sketch.

## Syntax (C#)
```csharp
public IList<ElementId> GetAllElements()
```

## Returns
Returns ids of elements which belong to that sketch.

## Remarks
Following elements can belong to a sketch:
 ModelCurve ,
 ReferencePlane ,
 Dimension .
 To get matching between Curve from Profile and ModelCurve , use [!:Autodesk::Revit::DB::Curve::Reference::ElementId] .

