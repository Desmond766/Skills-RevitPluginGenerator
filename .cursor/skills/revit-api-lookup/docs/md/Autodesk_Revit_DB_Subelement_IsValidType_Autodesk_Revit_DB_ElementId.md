---
kind: method
id: M:Autodesk.Revit.DB.Subelement.IsValidType(Autodesk.Revit.DB.ElementId)
source: html/b9ab1dbf-2b7b-398a-6682-e2cce94e4352.htm
---
# Autodesk.Revit.DB.Subelement.IsValidType Method

Checks if given type is valid for this subelement.

## Syntax (C#)
```csharp
public bool IsValidType(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the type to check.

## Returns
True if subelement can have a type assigned and this type is valid for this subelement, false otherwise.

## Remarks
A type is valid for a subelement if it can be assigned to the subelement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

