---
kind: method
id: M:Autodesk.Revit.DB.DisplacementPath.IsValidReference(Autodesk.Revit.DB.DisplacementElement,Autodesk.Revit.DB.Reference)
source: html/f3c1aeed-e6e3-77cd-1c03-21280f06f755.htm
---
# Autodesk.Revit.DB.DisplacementPath.IsValidReference Method

Does the specified pick represent an edge or a curve belonging to one of the displaced elements.

## Syntax (C#)
```csharp
public static bool IsValidReference(
	DisplacementElement displacementElement,
	Reference reference
)
```

## Parameters
- **displacementElement** (`Autodesk.Revit.DB.DisplacementElement`) - A DisplacementElement.
- **reference** (`Autodesk.Revit.DB.Reference`) - A pick.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

