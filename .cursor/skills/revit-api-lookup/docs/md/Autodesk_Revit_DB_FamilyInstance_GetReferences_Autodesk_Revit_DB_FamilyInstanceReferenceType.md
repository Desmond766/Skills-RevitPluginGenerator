---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetReferences(Autodesk.Revit.DB.FamilyInstanceReferenceType)
zh: 族实例
source: html/a8a7dc74-db8e-a7b6-a9c8-869397cca6b4.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetReferences Method

**中文**: 族实例

Gets family instance references corresponding to the reference planes or reference lines of the given reference type in the instance's family.

## Syntax (C#)
```csharp
public IList<Reference> GetReferences(
	FamilyInstanceReferenceType referenceType
)
```

## Parameters
- **referenceType** (`Autodesk.Revit.DB.FamilyInstanceReferenceType`) - The family reference type.

## Returns
Returns all the family instance references corresponding to reference planes and reference lines of the given reference type.
 Returns null if there are no family instance references of the given reference type, or if the input reference type is FamilyInstanceReferenceType.NotAReference.

## Remarks
Reference planes from the instance's family that have their "Is Reference" property set to "Not a Reference" do not create references in the family instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

