---
kind: method
id: M:Autodesk.Revit.DB.ElementIsCurveDrivenFilter.#ctor(System.Boolean)
source: html/e772c48c-d4b6-1e78-38e1-02e1c8a3a177.htm
---
# Autodesk.Revit.DB.ElementIsCurveDrivenFilter.#ctor Method

Constructs a new instance of a filter to match only curve driven elements, with the option to match all elements which are not curve driven elements.

## Syntax (C#)
```csharp
public ElementIsCurveDrivenFilter(
	bool inverted
)
```

## Parameters
- **inverted** (`System.Boolean`) - True if the filter should match all elements which are not curve driven elements.

## Remarks
The term "curve driven" indicates that the element's Location property is a LocationCurve.
 Example elements found by this filter include walls, beams, and curve elements.

