---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.IsADirectContext3DHandleCategory(Autodesk.Revit.DB.ElementId)
source: html/0a68f628-9ef8-8c2e-3075-e3730b35fbb9.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils.IsADirectContext3DHandleCategory Method

Checks whether the provided category ID is one of the categories used by DirectContext3D handle elements.

## Syntax (C#)
```csharp
public static bool IsADirectContext3DHandleCategory(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category ID to check.

## Returns
True, if the category is valid for DirectContext3D handle elements, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

