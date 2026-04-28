---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetReferenceType(Autodesk.Revit.DB.Reference)
zh: 族实例
source: html/0405fced-1ac6-a6a9-9f59-21eb81ca2241.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetReferenceType Method

**中文**: 族实例

Gets the type of the reference plane or reference line in the instance's family corresponding to the given family instance reference.

## Syntax (C#)
```csharp
public FamilyInstanceReferenceType GetReferenceType(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - The family instance reference.

## Returns
Returns the type of the reference plane or reference line in the instance's family corresponding to the given family instance reference.
 Returns FamilyInstanceReferenceType.NotAReference if the instance reference doesn't correspond to a reference plane or line in the family.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

