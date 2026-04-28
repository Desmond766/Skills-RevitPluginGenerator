---
kind: method
id: M:Autodesk.Revit.DB.ExternalFileUtils.IsExternalFileReference(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/e3fd1d77-a4ec-e5fe-191a-6cf338dcc0b1.htm
---
# Autodesk.Revit.DB.ExternalFileUtils.IsExternalFileReference Method

Determines whether the given element represents an external file.

## Syntax (C#)
```csharp
public static bool IsExternalFileReference(
	Document aDoc,
	ElementId elemId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - A Revit Document.
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The element to be checked for an external file reference.

## Returns
True if the given element represents an external file; false otherwise.

## Remarks
CAD imports are not external file references, as their
 data is brought fully into Revit. No connection is maintained
 to the original file. A link may be an external resource without being an external file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elemId does not exist in the document
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

