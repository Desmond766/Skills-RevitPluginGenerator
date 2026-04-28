---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition.DepthParamId
source: html/e9620a9a-6d57-1a05-7eb8-7493d5327bcb.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition.DepthParamId Property

Id of the parameter driving the multiplanar depth.
 The depth is measured center-to-center of the bar.
 A valid shape parameter must be assigned to DepthParamId before
 the MultiplanarDefinition can be used in RebarShape creation.

## Syntax (C#)
```csharp
public ElementId DepthParamId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

