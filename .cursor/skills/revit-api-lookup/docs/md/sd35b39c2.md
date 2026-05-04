---
kind: property
id: P:Autodesk.Revit.DB.IndependentTag.TagOrientation
zh: 标记、打标、标签
source: html/d9d43a13-a972-3b69-2484-b6e336e9a0c5.htm
---
# Autodesk.Revit.DB.IndependentTag.TagOrientation Property

**中文**: 标记、打标、标签

The tag orientation of the tag's head, such as horizontal or vertical.

## Syntax (C#)
```csharp
public TagOrientation TagOrientation { get; set; }
```

## Remarks
TagOrientation for the supported orientations.
 Tags from types that have rotate with component turned on ignore the TagOrientation property.
 Tags that are not in tag mode ignores the TagOrientation property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

