---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.AdjustEndLength(Autodesk.Revit.DB.Connector,System.Double,System.Boolean)
source: html/b66110ff-2f64-757f-5d4f-9b3afcd8f9bb.htm
---
# Autodesk.Revit.DB.FabricationPart.AdjustEndLength Method

Adjusts the length for the specified connector.

## Syntax (C#)
```csharp
public double AdjustEndLength(
	Connector connector,
	double lengthToAdjust,
	bool totalLengthOnly
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - # The connector of the fabrication part to adjust length.
- **lengthToAdjust** (`System.Double`) - The length to adjust.
- **totalLengthOnly** (`System.Boolean`) - True if adjust the total length only when adjust length.

## Returns
The adjusted length.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The end of the fabrication part of the connector can not be adjusted.
 -or-
 Connector is connected.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

