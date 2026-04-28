---
kind: method
id: M:Autodesk.Revit.DB.RoutingCondition.#ctor(System.Double)
source: html/78600567-3eac-43e6-3ef0-bede6352ed80.htm
---
# Autodesk.Revit.DB.RoutingCondition.#ctor Method

Creates a new RoutingCondition.

## Syntax (C#)
```csharp
public RoutingCondition(
	double diameter
)
```

## Parameters
- **diameter** (`System.Double`) - The diameter of a routing segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for diameter must be greater than 0 and no more than 30000 feet.

