---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.StructuralDepth
source: html/796c6515-9e91-e455-d0e8-91b15241074c.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.StructuralDepth Property

The structural depth of the stairs run, only available for monolithic stairs run.

## Syntax (C#)
```csharp
public double StructuralDepth { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for structuralDepth must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs run type is not a monolithic type so the data being set is not applicable.

