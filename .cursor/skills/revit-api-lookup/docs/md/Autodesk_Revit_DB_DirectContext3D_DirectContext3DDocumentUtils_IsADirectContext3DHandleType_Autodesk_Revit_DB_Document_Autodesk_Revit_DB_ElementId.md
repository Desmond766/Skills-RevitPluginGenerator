---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.IsADirectContext3DHandleType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/730e510c-758c-aff9-4224-0a88dd47b8fe.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.IsADirectContext3DHandleType Method

Checks whether the provided Element ID corresponds to a DirectContext3D handle type element.

## Syntax (C#)
```csharp
public static bool IsADirectContext3DHandleType(
	Document aDocument,
	ElementId elementId
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The ID of the element to check.

## Returns
True, if the element is a valid DirectContext3D handle type, false otherwise.

## Remarks
DirectContext3D handle types are DirectShapeTypes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - aDocument is not a project document.
 -or-
 elementId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

