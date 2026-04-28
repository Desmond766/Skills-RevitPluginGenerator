---
kind: property
id: P:Autodesk.Revit.DB.MaterialNode.MaterialId
source: html/39cd7c35-da9d-8248-92b8-beae06d63018.htm
---
# Autodesk.Revit.DB.MaterialNode.MaterialId Property

The Id of the element assocated with this material in the model.

## Syntax (C#)
```csharp
public ElementId MaterialId { get; }
```

## Remarks
It is possible that no specific material is applied to a face, in which case
 the default material is used, and this property returns an InvalidElementId.

