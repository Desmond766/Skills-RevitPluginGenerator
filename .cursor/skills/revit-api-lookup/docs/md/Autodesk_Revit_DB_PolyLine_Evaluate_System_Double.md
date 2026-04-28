---
kind: method
id: M:Autodesk.Revit.DB.PolyLine.Evaluate(System.Double)
zh: 多段线、折线
source: html/8c0e38d6-e1cc-9212-7041-c2bc73b51095.htm
---
# Autodesk.Revit.DB.PolyLine.Evaluate Method

**中文**: 多段线、折线

Evaluates a parameter on the polyline.

## Syntax (C#)
```csharp
public XYZ Evaluate(
	double param
)
```

## Parameters
- **param** (`System.Double`) - The parameter to be evaluated. It is expected to be in [0,1] interval mapped to the bounds of the whole polyline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the param value is not between 0.0 and 1.0.

