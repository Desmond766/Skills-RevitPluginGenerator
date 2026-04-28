---
kind: method
id: M:Autodesk.Revit.DB.Element.GetGeometryObjectFromReference(Autodesk.Revit.DB.Reference)
zh: 构件、图元、元素
source: html/536b3d7a-ec8d-29f6-5957-751468c98dd0.htm
---
# Autodesk.Revit.DB.Element.GetGeometryObjectFromReference Method

**中文**: 构件、图元、元素

Retrieve one geometric primitive contained in the element given a reference.

## Syntax (C#)
```csharp
public GeometryObject GetGeometryObjectFromReference(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - The geometric object referenced by this instance will be retrieved from the model.

## Returns
The geometric object referenced by the input reference.

## Remarks
It will return the last geometric object in the path.
 Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if related geometric object could not be found in the model.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id of this element is not same as that referenced by reference
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element id held by the input reference is not same as the id of this element.
 The geometric information could not be taken for this element.

