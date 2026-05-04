---
kind: method
id: M:Autodesk.Revit.DB.ExportUtils.GetGBXMLDocumentId(Autodesk.Revit.DB.Document)
source: html/9b234d89-aa16-cb64-b1c9-dfbe672f4961.htm
---
# Autodesk.Revit.DB.ExportUtils.GetGBXMLDocumentId Method

Retrieves the GUID representing this document in exported gbXML files.

## Syntax (C#)
```csharp
public static Guid GetGBXMLDocumentId(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The value of the GUID representing this document in gbXML export.

## Remarks
This id can be used to cross-reference different gbXML exports from the same document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

