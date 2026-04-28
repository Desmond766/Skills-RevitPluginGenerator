---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.RiserProfile
source: html/f9c01688-2700-8144-47f3-a41896ca071a.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.RiserProfile Property

The id of the profile of the risers.

## Syntax (C#)
```csharp
public ElementId RiserProfile { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The profile is neither a valid element id nor invalidElementId.
 -or-
 When setting this property: The profile is not a valid riser profile symbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The run type has no riser so the data being set is not applicable.

