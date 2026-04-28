---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationType.IsAllowedReferenceCategory(Autodesk.Revit.DB.ElementId)
source: html/44d8f0d4-67f2-3c2a-0941-350401e9ec9b.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationType.IsAllowedReferenceCategory Method

Checks if the reference category can be used with multi-reference annotations.

## Syntax (C#)
```csharp
public bool IsAllowedReferenceCategory(
	ElementId referenceCategoryId
)
```

## Parameters
- **referenceCategoryId** (`Autodesk.Revit.DB.ElementId`) - The reference category to check.

## Returns
True when the reference category can be used by multi-reference annotations.

## Remarks
Only Structural Rebar is allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

