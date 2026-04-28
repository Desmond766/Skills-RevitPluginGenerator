---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.SetBarTypeDiameters(Autodesk.Revit.DB.BarTypeDiameterOptions)
source: html/cb45e0d8-18dc-2376-5952-9226ec8a0ca5.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.SetBarTypeDiameters Method

Sets all input diameters from diametersOptions in current RebarBarType.

## Syntax (C#)
```csharp
public void SetBarTypeDiameters(
	BarTypeDiameterOptions diametersOptions
)
```

## Parameters
- **diametersOptions** (`Autodesk.Revit.DB.BarTypeDiameterOptions`) - The input diameters are validated as follows :
 barModelDiameter and barNominalDiameter are both positive and no more than the smallest value of 1.0 and the input bend diameters.
 Each bend diameter is smaller than 99.0 and bigger than barDiameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the diameters ranges in diametersOptions are not acceptable.

