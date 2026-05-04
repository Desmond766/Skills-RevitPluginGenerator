---
kind: method
id: M:Autodesk.Revit.DB.Electrical.TemperatureRatingType.AddWireSize(System.String,System.Int64,System.Double)
source: html/21783809-813d-46fa-b237-e516e06517c2.htm
---
# Autodesk.Revit.DB.Electrical.TemperatureRatingType.AddWireSize Method

Add a new kind of wire size type into this temperature rating type.

## Syntax (C#)
```csharp
public WireSize AddWireSize(
	string size,
	long ampacity,
	double diameter
)
```

## Parameters
- **size** (`System.String`) - Size of wire size.
- **ampacity** (`System.Int64`) - Ampacity of wire size to be added.
- **diameter** (`System.Double`) - Diameter of wire size to be added.

## Returns
Constructed wire size type.

