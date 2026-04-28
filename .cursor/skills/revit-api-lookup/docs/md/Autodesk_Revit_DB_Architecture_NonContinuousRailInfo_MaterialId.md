---
kind: property
id: P:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.MaterialId
source: html/19ca7c1d-bcb8-dc0c-908a-da31bf61682c.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.MaterialId Property

The material id associated with the non-continuous rail, or invalidElementId if none.

## Syntax (C#)
```csharp
public ElementId MaterialId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The materialId is not a valid value to be used as a non-continuous rail material Id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

