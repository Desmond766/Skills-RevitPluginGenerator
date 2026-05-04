---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.OpenIFCDocument(System.String,Autodesk.Revit.DB.IFC.IFCImportOptions)
source: html/84e92ca4-6c6a-af82-454e-1c0b7b145398.htm
---
# Autodesk.Revit.ApplicationServices.Application.OpenIFCDocument Method

Opens an IFC document from disk using custom options.

## Syntax (C#)
```csharp
public Document OpenIFCDocument(
	string fileName,
	IFCImportOptions importOptions
)
```

## Parameters
- **fileName** (`System.String`) - The IFC file to be opened.
- **importOptions** (`Autodesk.Revit.DB.IFC.IFCImportOptions`) - The options for this import.

## Returns
The newly created document containing the IFC file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - If 'fileName' is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - If the file specified by 'fileName' cannot be found.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If Revit is missing document templates or if the file cannot be opened.

