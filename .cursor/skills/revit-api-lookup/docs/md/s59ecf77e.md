---
kind: property
id: P:Autodesk.Revit.DB.CustomExporter.IncludeGeometricObjects
source: html/2ce1075e-380e-01e7-6459-b7467c2a2414.htm
---
# Autodesk.Revit.DB.CustomExporter.IncludeGeometricObjects Property

This flag sets the exporter to either include or exclude
 output of geometric objects such as faces and curves
 when the model is being processed by the export context.

## Syntax (C#)
```csharp
public bool IncludeGeometricObjects { get; set; }
```

## Remarks
If geometric objects are to be excluded, the context will not
 receive any of the calls to related to Faces or Curves. However, the
 objects will be still processed by Revit resulting in exporting their
 tessellated geometry in form of polymeshes or lines, respectivelly. Regardless of the value of this property, the export context
 must always implement the methods related to receiving of geometric
 objects (e.g. OnFaceStart, OnFaceEnd, OnCurve, etc.), even though
 the methods may never be invoked. Setting this property to False allows clients to significantly speed up
 the export process. If the export context does not need to examine geometric
 objects, it is recommended setting this property to False, which will make
 the export process faster even when compared with export during which
 notifications about geometric objects are sent, but ignored by the context.

