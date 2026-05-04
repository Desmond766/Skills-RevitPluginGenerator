---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ConduitSizes.Contains(System.Double)
source: html/f9be6af8-7ec2-d275-2bab-69c860e68316.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizes.Contains Method

Checks whether a conduit size with the nominal diameter exists.

## Syntax (C#)
```csharp
public bool Contains(
	double nominalDiameter
)
```

## Parameters
- **nominalDiameter** (`System.Double`) - Nominal diameter.

## Returns
True if a conduit size with the nominal diameter exists.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for nominalDiameter must be greater than 0 and no more than 30000 feet.

