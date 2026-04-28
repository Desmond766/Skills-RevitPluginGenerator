---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.MiddleSupportType
source: html/be91b3a0-047b-bf7f-27e4-3a22c1930735.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.MiddleSupportType Property

The type of middle supports used in the stair.

## Syntax (C#)
```csharp
public ElementId MiddleSupportType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: supportType is not a valid middle support type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs type has no middle support so the data being set is not applicable.

