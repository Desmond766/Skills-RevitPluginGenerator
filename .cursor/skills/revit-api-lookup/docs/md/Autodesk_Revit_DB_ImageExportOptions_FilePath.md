---
kind: property
id: P:Autodesk.Revit.DB.ImageExportOptions.FilePath
source: html/f771e862-4b30-98aa-63a7-af382b1d6d72.htm
---
# Autodesk.Revit.DB.ImageExportOptions.FilePath Property

The file name and path for the exported file.

## Syntax (C#)
```csharp
public string FilePath { get; set; }
```

## Remarks
If ExportRange is SetOfViews, the name of each view or sheet will be
 appended to the name provided for each exported file.
 This field is ignored if used to save an image to a project as a new view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The input file path is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

