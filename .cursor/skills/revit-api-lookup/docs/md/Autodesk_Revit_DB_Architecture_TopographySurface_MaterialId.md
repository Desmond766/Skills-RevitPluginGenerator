---
kind: property
id: P:Autodesk.Revit.DB.Architecture.TopographySurface.MaterialId
source: html/d3404230-355c-c1d3-abe9-a66a7eefcdc2.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.MaterialId Property

The id of the material applied to this element.

## Syntax (C#)
```csharp
public ElementId MaterialId { get; set; }
```

## Remarks
This applies to TopographySurface and SiteSubRegion elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The materialId cannot map to a valid material element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

