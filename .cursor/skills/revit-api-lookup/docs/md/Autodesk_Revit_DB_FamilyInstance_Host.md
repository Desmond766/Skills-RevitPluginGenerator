---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.Host
zh: 族实例
source: html/69f30141-bd3b-8bdd-7a63-6353d4d495f9.htm
---
# Autodesk.Revit.DB.FamilyInstance.Host Property

**中文**: 族实例

If the instance is contained within another element, this property returns the containing
element. An instance that is face hosted will return the element containing the face.

## Syntax (C#)
```csharp
public Element Host { get; }
```

## Remarks
An example of an instance that is contained is a window. In this case the host property
would return the wall in which the window is contained. Another example is an instance that is hosted 
to a planar or curved face in a Mass element will return the Mass element.

