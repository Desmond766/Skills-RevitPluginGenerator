---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.NosingProfile
source: html/5f4c8bb3-da54-fb00-387a-2e7c13800840.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.NosingProfile Property

The id of the nosing profile of the treads.

## Syntax (C#)
```csharp
public ElementId NosingProfile { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The profile is neither a valid element id nor invalidElementId.
 -or-
 When setting this property: The profile is not a valid nosing profile symbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The run type has no tread so the data being set is not applicable.

