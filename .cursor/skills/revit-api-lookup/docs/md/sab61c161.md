---
kind: property
id: P:Autodesk.Revit.DB.Document.MassDisplayTemporaryOverride
zh: 文档、文件
source: html/c1ad0cf9-2063-7a9b-f087-fc1e4e8b7158.htm
---
# Autodesk.Revit.DB.Document.MassDisplayTemporaryOverride Property

**中文**: 文档、文件

This setting controls temporary display in views of objects with mass category or subcategories.

## Syntax (C#)
```csharp
public MassDisplayTemporaryOverrideType MassDisplayTemporaryOverride { get; set; }
```

## Remarks
This setting is temporary and is not stored in the document.
 The mass display overrides allow mass category and certain mass subcategories
 to be displayed in all views, regardless of the visibility settings of that view.
 The settings that show certain mass subcategories will also force the other mass
 subcategories to be hidden.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The MassDisplayTemporaryOverrideType::Enum value is not in the proper range.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

