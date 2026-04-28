---
kind: method
id: M:Autodesk.Revit.DB.Location.Rotate(Autodesk.Revit.DB.Line,System.Double)
zh: 旋转
source: html/ed4de043-9a60-f6cd-c09b-b13c4612b343.htm
---
# Autodesk.Revit.DB.Location.Rotate Method

**中文**: 旋转

Rotate the element within the project by a specified angle around a given axis.

## Syntax (C#)
```csharp
public bool Rotate(
	Line axis,
	double angle
)
```

## Parameters
- **axis** (`Autodesk.Revit.DB.Line`) - An unbounded line that represents the axis of rotation.
- **angle** (`System.Double`) - The angle, in radians, by which the element is to be rotated around the specified axis.

## Returns
If the element is rotate successfully then the method returns True, otherwise False.

## Remarks
The rotate method is used to rotate an element within the project. Other elements may also
be rotated when this element is rotated because they are dependent upon the element being rotated. An
unbounded line for the axis can be created by using the Application.Create object and its methods.

