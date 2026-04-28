---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SetDimensionValue(Autodesk.Revit.DB.FabricationDimensionDefinition,System.Double)
source: html/4924d75b-4376-d2f6-9e53-0a6db3c023a8.htm
---
# Autodesk.Revit.DB.FabricationPart.SetDimensionValue Method

Sets the fabrication dimension value. The value is in Revit internal units.

## Syntax (C#)
```csharp
public void SetDimensionValue(
	FabricationDimensionDefinition dim,
	double newValue
)
```

## Parameters
- **dim** (`Autodesk.Revit.DB.FabricationDimensionDefinition`) - The fabrication dimension.
- **newValue** (`System.Double`) - The dimension value.

## Remarks
Multiple dimensions may need to be set in order to reach the desired outcome.
 The document must be regenerated before the fabrication part can be used.
 Check ValidationStatus after regeneration to see if the part is valid for fabrication.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fabrication dimension is unable to be modified because it is locked or from a product list.
 -or-
 the fabrication dimension is unable to be modified because it will affect the geometry of a connected end.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - the fabrication dimension is unable to be modified because the fabrication part is connected to more than one object.
 -or-
 the fabrication dimension cannot be set to the value: newValue.

