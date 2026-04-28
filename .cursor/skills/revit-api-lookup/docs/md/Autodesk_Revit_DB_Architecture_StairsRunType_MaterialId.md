---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.MaterialId
source: html/f8b6de5f-2765-ad23-a271-ce65005b79e0.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.MaterialId Property

The material of the stairs run, only available for monolithic stairs run.

## Syntax (C#)
```csharp
public ElementId MaterialId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The materialId is not a valid material element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs run type is not a monolithic type so the data being set is not applicable.

