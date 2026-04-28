---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.IsADirectContext3DHandleInstance(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/8569d33b-bf63-1e48-886a-f3fdf0462ea0.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.IsADirectContext3DHandleInstance Method

Checks whether the provided Element ID corresponds to a DirectContext3D handle instance element.

## Syntax (C#)
```csharp
public static bool IsADirectContext3DHandleInstance(
	Document aDocument,
	ElementId elementId
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The ID of the element to check.

## Returns
True, if the element is a valid DirectContext3D handle instance, false otherwise.

## Remarks
DirectContext3D handle instances are DirectShapes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - aDocument is not a project document.
 -or-
 elementId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

