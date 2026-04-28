---
kind: method
id: M:Autodesk.Revit.DB.SSEPointVisibilitySettings.SetVisibility(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/0e276f4e-febe-a078-cc7c-228c1cdb01dd.htm
---
# Autodesk.Revit.DB.SSEPointVisibilitySettings.SetVisibility Method

Sets the SSE point visibility for the given category.

## Syntax (C#)
```csharp
public static void SetVisibility(
	Document document,
	ElementId categoryId,
	bool isVisible
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category id.
- **isVisible** (`System.Boolean`) - The visibility of the given category. True means the SSE points are visible.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The category is not valid for SSE.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

