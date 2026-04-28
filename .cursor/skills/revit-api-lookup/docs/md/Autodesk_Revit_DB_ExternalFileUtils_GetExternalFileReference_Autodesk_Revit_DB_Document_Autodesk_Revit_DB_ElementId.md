---
kind: method
id: M:Autodesk.Revit.DB.ExternalFileUtils.GetExternalFileReference(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/edede302-83dc-c285-17ea-5d0a168a94dd.htm
---
# Autodesk.Revit.DB.ExternalFileUtils.GetExternalFileReference Method

Gets the external file referencing data for the given element.

## Syntax (C#)
```csharp
public static ExternalFileReference GetExternalFileReference(
	Document aDoc,
	ElementId elemId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit Document.
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The element whose external file reference we want.

## Returns
An object containing path and type information for the given element's external file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elemId does not exist in the document
 -or-
 elemId does not represent an external file reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

