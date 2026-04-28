---
kind: method
id: M:Autodesk.Revit.DB.ExtrusionAnalyzer.CalculateFaceAlignment
source: html/7e51ca19-05ec-82e1-905d-df564b15a7d8.htm
---
# Autodesk.Revit.DB.ExtrusionAnalyzer.CalculateFaceAlignment Method

Calculates the alignment status of each face of the solid.

## Syntax (C#)
```csharp
public IDictionary<Face, ExtrusionAnalyzerFaceAlignment> CalculateFaceAlignment()
```

## Returns
Maps each face of the solid to its alignment status.

## Remarks
You can obtain the element which produced the non-aligned face by passing
 the face to Element.GetGeneratingElementIds().

