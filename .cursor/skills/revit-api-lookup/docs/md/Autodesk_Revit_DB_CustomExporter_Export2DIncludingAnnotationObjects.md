---
kind: property
id: P:Autodesk.Revit.DB.CustomExporter.Export2DIncludingAnnotationObjects
source: html/1a22bfd6-bb08-c368-f981-d02151986b5c.htm
---
# Autodesk.Revit.DB.CustomExporter.Export2DIncludingAnnotationObjects Property

This flag sets the exporter of 2D views to either include or exclude
 output of annotation objects
 when the model is being processed by the export context.

## Syntax (C#)
```csharp
public bool Export2DIncludingAnnotationObjects { get; set; }
```

## Remarks
A convenient way of determining whether an element category is annotation is using [!:Autodesk::Revit::DB::Category::CategoryType] .

