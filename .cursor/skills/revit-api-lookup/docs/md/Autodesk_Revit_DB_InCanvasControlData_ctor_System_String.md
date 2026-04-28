---
kind: method
id: M:Autodesk.Revit.DB.InCanvasControlData.#ctor(System.String)
source: html/3ab7de26-5e32-b3c7-0d35-5e739aad614c.htm
---
# Autodesk.Revit.DB.InCanvasControlData.#ctor Method

Constructs an InCanvasControlData with specific values assigned.

## Syntax (C#)
```csharp
public InCanvasControlData(
	string imagePath
)
```

## Parameters
- **imagePath** (`System.String`) - File path with the image to be used.
 This must be an absolute path to a location on disk.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The file format specified by imagePath is an unsupported format - only *.bmp files are supported.
 -or-
 The file path specified by imagePath is not absolute.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The file specified by imagePath doesn't exist.

