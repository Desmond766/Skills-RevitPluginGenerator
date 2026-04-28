---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFC.SetCurrentExportedDocument(Autodesk.Revit.DB.Document)
source: html/f0af06ac-6928-c772-54b8-46070927d5e1.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.SetCurrentExportedDocument Method

Sets the exporter to process a particular document during export.

## Syntax (C#)
```csharp
public void SetCurrentExportedDocument(
	Document pDocument
)
```

## Parameters
- **pDocument** (`Autodesk.Revit.DB.Document`) - The document being processed.

## Remarks
This is intended for use in federated export.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

