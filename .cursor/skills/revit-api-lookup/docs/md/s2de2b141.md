---
kind: method
id: M:Autodesk.Revit.DB.ImageTypeOptions.IsValid(Autodesk.Revit.DB.Document)
source: html/47f3832b-9cf5-4628-214d-7e7e7d705393.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.IsValid Method

If true the ImageTypeOptions can be used to create or reload an ImageType.

## Syntax (C#)
```csharp
public bool IsValid(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
Returns True if the options can be used to create or reload an ImageType. False otherwise.

## Remarks
This method returns true if all the following checks are true:
 The Path points to a file that is a supported image file type. The Path points to a file that is not encrypted, which can happen for PDF files. The Path points to a file that contains the specified PageNumber. Only imported images are allowed in family documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

