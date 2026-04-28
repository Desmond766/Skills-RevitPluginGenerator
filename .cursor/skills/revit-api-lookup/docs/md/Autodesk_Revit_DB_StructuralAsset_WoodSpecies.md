---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.WoodSpecies
source: html/6c67ca9f-6d14-d071-626c-77e164dbb92f.htm
---
# Autodesk.Revit.DB.StructuralAsset.WoodSpecies Property

The species of wood used in a wood-based asset.

## Syntax (C#)
```csharp
public string WoodSpecies { get; set; }
```

## Remarks
Applies to wood-based structural assets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be wood to set this property.

