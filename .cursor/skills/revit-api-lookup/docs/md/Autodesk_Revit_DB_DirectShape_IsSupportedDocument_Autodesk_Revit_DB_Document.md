---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.IsSupportedDocument(Autodesk.Revit.DB.Document)
source: html/8651e9ac-f5cf-840b-d271-c8db2a244377.htm
---
# Autodesk.Revit.DB.DirectShape.IsSupportedDocument Method

Tests whether a DirectShape or a DirectShapeType may be created in this document.

## Syntax (C#)
```csharp
public static bool IsSupportedDocument(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to be tested.

## Returns
True if a DirectShape or a DirectShapeType object can be created in this document, false otherwise.

## Remarks
Some types of Document, such as 2D families, can't support DirectShape functionality.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

