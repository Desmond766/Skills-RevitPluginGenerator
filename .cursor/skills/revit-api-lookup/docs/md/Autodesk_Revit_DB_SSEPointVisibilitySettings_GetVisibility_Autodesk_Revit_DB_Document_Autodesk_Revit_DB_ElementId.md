---
kind: method
id: M:Autodesk.Revit.DB.SSEPointVisibilitySettings.GetVisibility(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/d255a3cc-ed2d-5f00-3fa7-9b2688cc464a.htm
---
# Autodesk.Revit.DB.SSEPointVisibilitySettings.GetVisibility Method

Gets the SSE point visibility for the given category.

## Syntax (C#)
```csharp
public static bool GetVisibility(
	Document document,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category id.

## Returns
The visibility of the given category. True means the SSE points are visible.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The category is not valid for SSE.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

