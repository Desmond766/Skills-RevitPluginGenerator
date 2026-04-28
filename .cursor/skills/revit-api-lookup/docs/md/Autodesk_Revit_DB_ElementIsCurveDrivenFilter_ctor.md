---
kind: method
id: M:Autodesk.Revit.DB.ElementIsCurveDrivenFilter.#ctor
source: html/cdfd2844-094c-cf6b-8303-3f34a125668f.htm
---
# Autodesk.Revit.DB.ElementIsCurveDrivenFilter.#ctor Method

Constructs a new instance of a filter to match only curve driven elements.

## Syntax (C#)
```csharp
public ElementIsCurveDrivenFilter()
```

## Remarks
The term "curve driven" indicates that the element's Location property is a LocationCurve.
 Example elements found by this filter include walls, beams, and curve elements.

