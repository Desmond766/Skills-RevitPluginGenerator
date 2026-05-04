---
kind: method
id: M:Autodesk.Revit.DB.ElementType.IsSimilarType(Autodesk.Revit.DB.ElementId)
source: html/bd1e5459-4909-dc8a-46fd-54540fe1961e.htm
---
# Autodesk.Revit.DB.ElementType.IsSimilarType Method

Checks if given type is similar to this type.

## Syntax (C#)
```csharp
public bool IsSimilarType(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the type to check.

## Returns
True if given type is similar to this type, false otherwise.

## Remarks
Two types are similar if elements that have one type could be assigned the other type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

