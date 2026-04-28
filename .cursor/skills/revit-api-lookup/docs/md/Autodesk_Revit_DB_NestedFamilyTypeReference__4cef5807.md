---
kind: type
id: T:Autodesk.Revit.DB.NestedFamilyTypeReference
source: html/ff71e3b0-4300-7d04-1356-a045b9a90407.htm
---
# Autodesk.Revit.DB.NestedFamilyTypeReference

A proxy element representing a nested family type.

## Syntax (C#)
```csharp
public class NestedFamilyTypeReference : Element
```

## Remarks
This element represents a value of a FamilyType Parameter of a Loaded Family.
 Each such element corresponds to a nested FamilyType Element in the original
 Family Document where the family was defined. This element stores only basic information about the nested FamilyType,
 such as the name of the Type, name of the Family, and a Category. These elements are very low-level and thus bypassed by standard element
 filters. However, it is possible to obtain a set of applicable elements
 of this class for a FamilyType parameter of a family by calling
 [!:Autodesk::Revit::DB::Family::GetFamilyTypeParameterValues]

