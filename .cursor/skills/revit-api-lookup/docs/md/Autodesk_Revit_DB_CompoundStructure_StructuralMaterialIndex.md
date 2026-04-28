---
kind: property
id: P:Autodesk.Revit.DB.CompoundStructure.StructuralMaterialIndex
source: html/cf4d771e-6ed2-ec6a-d32d-647fb5b649b3.htm
---
# Autodesk.Revit.DB.CompoundStructure.StructuralMaterialIndex Property

Indicates the layer whose material defines the structural properties of the type for the purposes of analysis.

## Syntax (C#)
```csharp
public int StructuralMaterialIndex { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The specified layer cannot define the structural material properties of the type.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The layer index is invalid.

