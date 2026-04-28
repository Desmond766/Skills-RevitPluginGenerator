---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRunType.TreadProfile
source: html/9d40bd4c-480a-3cf6-6b48-f81dfd2e7ad9.htm
---
# Autodesk.Revit.DB.Architecture.StairsRunType.TreadProfile Property

The id of the profile of the treads.

## Syntax (C#)
```csharp
public ElementId TreadProfile { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The profile is neither a valid element id nor invalidElementId.
 -or-
 When setting this property: The profile is not a valid tread profile symbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The run type has no tread so the data being set is not applicable.

