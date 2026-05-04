---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.SetFamilyName(System.String)
source: html/9a54477b-177f-5f9a-4c17-4e66741fc103.htm
---
# Autodesk.Revit.DB.DirectShapeType.SetFamilyName Method

Sets the family name for the DirectShapeType.

## Syntax (C#)
```csharp
public void SetFamilyName(
	string name
)
```

## Parameters
- **name** (`System.String`) - Family name for the DirectShapeType.

## Remarks
By default the family name is either Direct Shape or a category-specific name. When a
 category-specific name is used the family name cannot be set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element type name was empty, contained invalid characters, or was invalid for the specific element type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The given DirectShapeType has a category which does not support a custom family name.

