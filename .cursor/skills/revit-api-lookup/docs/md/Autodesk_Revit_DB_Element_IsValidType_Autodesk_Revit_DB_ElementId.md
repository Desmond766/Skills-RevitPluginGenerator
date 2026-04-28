---
kind: method
id: M:Autodesk.Revit.DB.Element.IsValidType(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/c3ca4ee5-c2b3-beb3-ee51-cc6cafc82c93.htm
---
# Autodesk.Revit.DB.Element.IsValidType Method

**中文**: 构件、图元、元素

Checks if given type is valid for this element.

## Syntax (C#)
```csharp
public bool IsValidType(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the type to check.

## Returns
True if element can have a type assigned and this type is valid for this element, false otherwise.

## Remarks
A type is valid for an element if it can be assigned to the element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

