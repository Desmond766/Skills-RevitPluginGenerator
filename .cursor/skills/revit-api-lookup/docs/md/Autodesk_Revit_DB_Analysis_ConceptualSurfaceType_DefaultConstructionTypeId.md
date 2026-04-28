---
kind: property
id: P:Autodesk.Revit.DB.Analysis.ConceptualSurfaceType.DefaultConstructionTypeId
source: html/7d39cf33-6710-6bf9-8e13-8bc0a5766a53.htm
---
# Autodesk.Revit.DB.Analysis.ConceptualSurfaceType.DefaultConstructionTypeId Property

The element id of the user specified ConceptualConstructionType to be used by default on creation for mass faces of this mass subcategory.

## Syntax (C#)
```csharp
public ElementId DefaultConstructionTypeId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The input element is not a constructionType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

