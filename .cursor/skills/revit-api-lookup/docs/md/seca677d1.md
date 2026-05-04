---
kind: property
id: P:Autodesk.Revit.DB.ImageTypeOptions.SourceType
source: html/1d275efe-88ad-da80-d321-b31884f1c369.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.SourceType Property

Indicates whether the image type is a link or an import.

## Syntax (C#)
```csharp
public ImageTypeSource SourceType { get; set; }
```

## Remarks
Use this property with the method ImageType::Create to create a linked image type.
 Use this property with the method ImageType::ReloadFrom to convert an import image type to a link and vice versa.
 Valid values are 'Import' and 'Link'.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The ImageType source is not correct. Only Link or Import values are allowed.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

