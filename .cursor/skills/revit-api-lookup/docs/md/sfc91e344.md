---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.IsValidTypeId(Autodesk.Revit.DB.ElementId)
source: html/3720858e-aa72-b1b8-a9e6-7f6dc5a83a76.htm
---
# Autodesk.Revit.DB.DirectShape.IsValidTypeId Method

Tests the type id to make sure it satisfies the following conditions
 It is a valid element id.It corresponds to a valid DirectShapeType.The DirectShapeType has the same category assigned.
 Additionally, this functions tests that the current type id in this DirectShape is invalid.
 The type id is initialized to invalidElementId by the create functions. Once it is set, it may no longer be changed.

## Syntax (C#)
```csharp
public bool IsValidTypeId(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Type id to be tested.

## Returns
False unless typeId satisfies the conditions listed above and the type id of this object was not set previously.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

