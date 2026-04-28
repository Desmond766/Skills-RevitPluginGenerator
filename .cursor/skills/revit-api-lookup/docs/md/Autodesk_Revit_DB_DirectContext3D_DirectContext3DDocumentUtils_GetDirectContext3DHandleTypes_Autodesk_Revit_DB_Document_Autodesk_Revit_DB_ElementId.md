---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.GetDirectContext3DHandleTypes(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/673192fe-125b-a53e-be55-95e3301a0f22.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.GetDirectContext3DHandleTypes Method

Returns all DirectContext3D handle types of the given category in the document.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetDirectContext3DHandleTypes(
	Document aDocument,
	ElementId handleCategory
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document.
- **handleCategory** (`Autodesk.Revit.DB.ElementId`) - A category of DirectContext3D handles.

## Returns
The set of DirectContext3D handle types of the given category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the category ID handleCategory is not valid for DirectContext3D handles.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

