---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.String,Autodesk.Revit.DB.NavisworksExportOptions)
zh: 导出、输出
source: html/1b9538a9-a76b-0a40-2aed-e02f6974a43a.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Exports a Revit project to the Navisworks .nwc format.

## Syntax (C#)
```csharp
public void Export(
	string folder,
	string name,
	NavisworksExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - The name of the folder for the exported file.
- **name** (`System.String`) - The name of the exported file. If it doesn't end in '.nwc', this extension will be added automatically.
- **options** (`Autodesk.Revit.DB.NavisworksExportOptions`) - Options which control the contents of the export.

## Remarks
This is an optional functionality that does not have to be installed. The method "OptionalFunctionalityUtils.isNavisworksExporterAvailable()" can be called to check if the exporter is present.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - NullOrEmpty
 -or-
 Contains invalid characters.
 -or-
 The input options were not valid. Check the exception message for specific details.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Export is temporarily disabled.
 -or-
 Exporting is not allowed in the current application mode.
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The folder does not exist.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - The export operation is cancelled in event handler.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - A Navisworks Exporter is not available in the installed Revit.

