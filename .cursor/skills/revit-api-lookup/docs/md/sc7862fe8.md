---
kind: property
id: P:Autodesk.Revit.DB.BaseImportOptions.ReferencePoint
source: html/deaf1d27-87a7-f330-f1ef-8eb3d212de32.htm
---
# Autodesk.Revit.DB.BaseImportOptions.ReferencePoint Property

The 3D point in the document where the imported instance will be inserted.
 If not explicitly set, the instance will be inserted at the document origin.

## Syntax (C#)
```csharp
public XYZ ReferencePoint { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

