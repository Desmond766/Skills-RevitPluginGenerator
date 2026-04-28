---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SetCalculatedDimensionValue(Autodesk.Revit.DB.FabricationDimensionDefinition,System.String)
source: html/1d49fae0-16e2-6ad2-6c3a-5f3d62cab22d.htm
---
# Autodesk.Revit.DB.FabricationPart.SetCalculatedDimensionValue Method

Sets the calculated dimension value.

## Syntax (C#)
```csharp
public void SetCalculatedDimensionValue(
	FabricationDimensionDefinition dim,
	string value
)
```

## Parameters
- **dim** (`Autodesk.Revit.DB.FabricationDimensionDefinition`) - The fabrication dimension.
- **value** (`System.String`) - The calculated dimension value.

## Remarks
Multiple dimensions may need to be set in order to reach the desired outcome.
 The document must be regenerated before the fabrication part can be used.
 Check ValidationStatus after regeneration to see if the part is valid for fabrication.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - value is not a valid calculated fabrication dimension value.
 -or-
 fabrication dimension is unable to be modified because it is locked or from a product list.
 -or-
 the fabrication dimension is unable to be modified because it will affect the geometry of a connected end.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - the fabrication dimension is unable to be modified because the fabrication part is connected to more than one object.
 -or-
 the fabrication dimension cannot be set to the option: value.

