---
kind: method
id: M:Autodesk.Revit.DB.IFC.IExporterIFC.ExportIFC(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.IFC.ExporterIFC,Autodesk.Revit.DB.View)
source: html/8810ec8c-1aff-871b-b882-b0e5853376ae.htm
---
# Autodesk.Revit.DB.IFC.IExporterIFC.ExportIFC Method

The method that Revit will invoke to perform an export to IFC.

## Syntax (C#)
```csharp
void ExportIFC(
	Document document,
	ExporterIFC exporter,
	View filterView
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to export.
- **exporter** (`Autodesk.Revit.DB.IFC.ExporterIFC`) - The IFC exporter object.
- **filterView** (`Autodesk.Revit.DB.View`) - The view whose filter visibility settings govern the export.

## Remarks
There will be a transaction group opened for the document. Any changes made to the document
 must be temporary, as the transaction group will automatically be rolled back at the end.

