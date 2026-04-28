---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.UndersideSurfaceStyle
source: html/4ac85f7d-ec42-335a-8bfb-ae2389fb1c28.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.UndersideSurfaceStyle Property

The underside surface style of the stairs run, only available for monolithic stairs run.

## Syntax (C#)
```csharp
public StairsUndersideSurfaceStyle UndersideSurfaceStyle { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs run type is not a monolithic type so the data being set is not applicable.

