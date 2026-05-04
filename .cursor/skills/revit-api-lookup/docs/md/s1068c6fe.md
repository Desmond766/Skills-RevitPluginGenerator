---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.ThermalExpansionCoefficient
source: html/b1da0166-52ca-209c-4a21-76bdce82ff4e.htm
---
# Autodesk.Revit.DB.StructuralAsset.ThermalExpansionCoefficient Property

The thermal expansion coefficient of the asset.

## Syntax (C#)
```csharp
public XYZ ThermalExpansionCoefficient { get; set; }
```

## Remarks
This property cannot be used to set the thermal expansion coefficient for wood-based and isotropic materials.
 For such assets, use setThermalExpansionCoefficient instead.
 The value is in inverse Kelvin (1/K).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type is wood.
 -or-
 When setting this property: the behavior is isotropic.

