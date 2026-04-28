---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.GetDirectContext3DHandleInstances(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/0ba98534-f7ef-e97b-bc83-69549c523406.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.GetDirectContext3DHandleInstances Method

Returns all DirectContext3D handle instances of the given category in the document.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetDirectContext3DHandleInstances(
	Document aDocument,
	ElementId handleCategory
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document.
- **handleCategory** (`Autodesk.Revit.DB.ElementId`) - A category of DirectContext3D handles.

## Returns
The set of DirectContext3D handle instances of the given category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the category ID handleCategory is not valid for DirectContext3D handles.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

