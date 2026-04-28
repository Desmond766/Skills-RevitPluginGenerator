---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.RiserToTreadConnect
source: html/38e441dd-7c1d-4c60-ab69-4a5f936f177c.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.RiserToTreadConnect Property

The connection of the riser to tread in relation to each other.

## Syntax (C#)
```csharp
public RiserToTreadConnectionOption RiserToTreadConnect { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The run type has no riser so the data being set is not applicable.

