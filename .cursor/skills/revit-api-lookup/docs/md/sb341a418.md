---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.OpenIFCDocument(System.String)
source: html/596a3b91-4647-a3b6-818f-17f722f13c53.htm
---
# Autodesk.Revit.ApplicationServices.Application.OpenIFCDocument Method

Opens an IFC document from disk using default options.

## Syntax (C#)
```csharp
public Document OpenIFCDocument(
	string fileName
)
```

## Parameters
- **fileName** (`System.String`) - The IFC file to be opened.

## Returns
The newly created document containing the IFC file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - If 'fileName' is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - If Nothing nullptr a null reference ( Nothing in Visual Basic) is passed as 'fileName'
 -or-
 A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - If the file specified by 'fileName' cannot be found.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If Revit is missing document templates or if the file cannot be opened.

