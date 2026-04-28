---
kind: type
id: T:Autodesk.Revit.DB.ElementIsCurveDrivenFilter
source: html/f4538d9d-e681-d486-f466-0a3de13bf2cc.htm
---
# Autodesk.Revit.DB.ElementIsCurveDrivenFilter

A filter used to match elements which are curve driven.

## Syntax (C#)
```csharp
public class ElementIsCurveDrivenFilter : ElementQuickFilter
```

## Remarks
The term "curve driven" indicates that the element's Location property is a LocationCurve.
 Example elements found by this filter include walls, beams, and curve elements.
This filter is a quick filter.
 Quick filters operate only on the ElementRecord, a low-memory class which has
 a limited interface to read element properties. Elements which are rejected
 by a quick filter will not be expanded in memory.

