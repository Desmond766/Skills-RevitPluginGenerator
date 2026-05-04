---
kind: property
id: P:Autodesk.Revit.DB.CustomExporter.Export2DGeometricObjectsIncludingPatternLines
source: html/34ed2a39-a5e6-6ef1-1f6d-cceebd2bae7f.htm
---
# Autodesk.Revit.DB.CustomExporter.Export2DGeometricObjectsIncludingPatternLines Property

This flag sets the exporter of 2D views to either include or exclude
 output of face pattern lines as part of geometric objects
 when the model is being processed by the export context.

## Syntax (C#)
```csharp
public bool Export2DGeometricObjectsIncludingPatternLines { get; set; }
```

## Remarks
This flag is ignored if view has Wireframe display style.
 This flag is ignored unless property "IncludeGeometricObjects" is set to true.

