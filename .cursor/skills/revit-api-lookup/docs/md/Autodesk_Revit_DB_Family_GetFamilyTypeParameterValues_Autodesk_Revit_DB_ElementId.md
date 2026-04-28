---
kind: method
id: M:Autodesk.Revit.DB.Family.GetFamilyTypeParameterValues(Autodesk.Revit.DB.ElementId)
zh: 族
source: html/a9c8ff23-17ec-1b87-e58a-4be589217766.htm
---
# Autodesk.Revit.DB.Family.GetFamilyTypeParameterValues Method

**中文**: 族

Returns all applicable values for a FamilyType parameter of this family.

## Syntax (C#)
```csharp
public ISet<ElementId> GetFamilyTypeParameterValues(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - A valid Id of a FamilyType parameter defined for this family.

## Returns
Ids of all applicable ElementType and NestedFamilyTypeReference elements.

## Remarks
The values are Element Ids of all family types that match
 the category specified by the definition of the given parameter.
 The elements are either of class ElementType or
 NestedFamilyTypeReference . The second variant is
 for the types that are nested in families and thus are not
 accessible otherwise. If there are no applicable types of such category the returned
 collection will be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given parameterId does not represent a valid FamilyType parameter of this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

