---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.MetalThermallyTreated
source: html/f04ced55-81da-7051-80bc-6a1c30a15c7a.htm
---
# Autodesk.Revit.DB.StructuralAsset.MetalThermallyTreated Property

Flag indicating whether the asset describes a material that is thermally treated or not.

## Syntax (C#)
```csharp
public bool MetalThermallyTreated { get; set; }
```

## Remarks
Applies to Metal-based structural assets.

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be Metal to set this property.

