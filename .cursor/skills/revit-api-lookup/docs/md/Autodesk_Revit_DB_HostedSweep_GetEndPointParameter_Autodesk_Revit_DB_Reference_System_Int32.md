---
kind: method
id: M:Autodesk.Revit.DB.HostedSweep.GetEndPointParameter(Autodesk.Revit.DB.Reference,System.Int32)
source: html/9d932372-7418-6e37-6764-0cc0994959df.htm
---
# Autodesk.Revit.DB.HostedSweep.GetEndPointParameter Method

Retrieve segment's start point or end point parameter.

## Syntax (C#)
```csharp
public double GetEndPointParameter(
	Reference targetRef,
	int endIdx
)
```

## Parameters
- **targetRef** (`Autodesk.Revit.DB.Reference`) - Segment's reference whose parameter want to be get.
- **endIdx** (`System.Int32`) - Start point (=0) or end point (=1).

## Returns
Start point or end point parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration fails.

