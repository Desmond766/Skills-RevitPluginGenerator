---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.ConcreteCompression
source: html/474fa66e-c608-fd65-07bc-567e2b006249.htm
---
# Autodesk.Revit.DB.StructuralAsset.ConcreteCompression Property

The compression strength of concrete-based assets.

## Syntax (C#)
```csharp
public double ConcreteCompression { get; set; }
```

## Remarks
Applies to concrete-based structural assets.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be concrete to set this property.

