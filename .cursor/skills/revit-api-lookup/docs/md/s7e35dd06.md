---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterUtilities.IsParameterApplicable(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.ElementId)
source: html/b8d82e63-1ecd-75c8-d28e-e03d9cc0675c.htm
---
# Autodesk.Revit.DB.ParameterFilterUtilities.IsParameterApplicable Method

Used to determine whether the element supports the given parameter.

## Syntax (C#)
```csharp
public static bool IsParameterApplicable(
	Element element,
	ElementId parameter
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to query for support of the given parameter.
- **parameter** (`Autodesk.Revit.DB.ElementId`) - The parameter for which to query support.

## Returns
True if the element supports the given parameter, false otherwise.

## Remarks
This operation is supported for external (e.g., shared, project)
 parameters only.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

