---
kind: property
id: P:Autodesk.Revit.DB.ImageTypeOptions.PageNumber
source: html/33b28f56-d107-868c-3554-85fe06c32397.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.PageNumber Property

The page in the file to be used for the image

## Syntax (C#)
```csharp
public int PageNumber { get; set; }
```

## Remarks
The default value of this property is 1. This default is appropriate for most file types.
 This should be used for files, such as PDF files, that can have multiple pages.
 Valid values range from 1 to the number of pages in the file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for pageNumber is not positive.

