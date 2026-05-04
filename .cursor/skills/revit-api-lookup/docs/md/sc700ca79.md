---
kind: property
id: P:Autodesk.Revit.DB.WallSweepInfo.MaterialId
source: html/18f06a02-b0d6-40cf-3682-a88db9fb086b.htm
---
# Autodesk.Revit.DB.WallSweepInfo.MaterialId Property

The element id of the material used to create the sweep or reveal.

## Syntax (C#)
```csharp
public ElementId MaterialId { get; set; }
```

## Remarks
This value is not used when creating standalone wall sweeps. The material id of the
 wall sweep's type is used instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

