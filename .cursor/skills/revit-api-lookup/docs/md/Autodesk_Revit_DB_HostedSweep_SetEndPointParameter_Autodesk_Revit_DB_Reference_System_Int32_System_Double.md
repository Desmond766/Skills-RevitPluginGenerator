---
kind: method
id: M:Autodesk.Revit.DB.HostedSweep.SetEndPointParameter(Autodesk.Revit.DB.Reference,System.Int32,System.Double)
source: html/de365ff6-a402-a803-43de-c9efc847fccd.htm
---
# Autodesk.Revit.DB.HostedSweep.SetEndPointParameter Method

Set segment's start point or end point parameter.

## Syntax (C#)
```csharp
public bool SetEndPointParameter(
	Reference targetRef,
	int endIdx,
	double param
)
```

## Parameters
- **targetRef** (`Autodesk.Revit.DB.Reference`) - Segment's reference whose parameter want to be set.
- **endIdx** (`System.Int32`) - Start point (=0) or end point (=1).
- **param** (`System.Double`) - Value of parameter.

## Returns
true if operation success.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration fails.

