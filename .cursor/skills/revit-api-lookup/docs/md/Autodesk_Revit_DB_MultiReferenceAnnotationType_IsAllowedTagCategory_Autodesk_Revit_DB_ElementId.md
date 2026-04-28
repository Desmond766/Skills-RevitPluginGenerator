---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationType.IsAllowedTagCategory(Autodesk.Revit.DB.ElementId)
source: html/2bff739f-d084-8596-0633-28013e778e6c.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationType.IsAllowedTagCategory Method

Returns true if tag types belonging to this category can be used with multi-reference annotation types.

## Syntax (C#)
```csharp
public static bool IsAllowedTagCategory(
	ElementId tagCategoryId
)
```

## Parameters
- **tagCategoryId** (`Autodesk.Revit.DB.ElementId`) - The tag category to test.

## Remarks
Only Structural Rebar Tags are allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

